using KOF.RouteMap.Application.Common.Interfaces;
using KOF.RouteMap.Infrastructure.Persistence;
using KOF.RouteMap.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace KOF.RouteMap.Infrastructure;

public static class DependencyInjection
{
    public const string CONTENT_ROOT_PLACE_HOLDER = "%CONTENTROOTPATH%";
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration,string path)
    {
        var useInMemoryDatabase = configuration.GetValue<bool>("UseInMemoryDatabase");
        if (useInMemoryDatabase)
        {
            services.AddDbContext<ApplicationDbPooledContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb"));
        }
        else
        {
            //var dbConnectionString = GetDbConnectionString(configuration.GetConnectionString("DefaultConnection"), path);

            #region RegisterSingletonContextFactory
                services.AddPooledDbContextFactory<ApplicationDbPooledContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                sqlOptions =>
                                {
                                    sqlOptions.EnableRetryOnFailure(
                                    maxRetryCount: 5,
                                    maxRetryDelay: TimeSpan.FromSeconds(10),
                                    errorNumbersToAdd: null);
                                    sqlOptions.MigrationsAssembly(typeof(ApplicationDbPooledContext).Assembly.FullName);
                                }));

            #endregion

            services.AddDbContext<ApplicationDbScopedContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                sqlOptions =>
                                {
                                    sqlOptions.EnableRetryOnFailure(
                                    maxRetryCount: 5,
                                    maxRetryDelay: TimeSpan.FromSeconds(10),
                                    errorNumbersToAdd: null);
                                    sqlOptions.MigrationsAssembly(typeof(ApplicationDbPooledContext).Assembly.FullName);
                                }));

        }
        //services.AddScoped<IDomainEventService, DomainEventService>();
        //services.AddTransient<IDateTime, DateTimeService>();

        #region RegisterScopedContextFactory
        services.AddScoped<ApplicationDbScopedFactory>();
        #endregion

        #region RegisterDbContext
        services.AddScoped<IApplicationDbPooledContext>(
            sp => sp.GetRequiredService<ApplicationDbScopedFactory>()
            .CreateDbContext());

        services.AddScoped<IApplicationDbScopedContext>(provider => 
        provider.GetRequiredService<ApplicationDbScopedContext>());
        #endregion

        return services;
    }

    public static string GetDbConnectionString(string connectionString, string contentRootPath)
    {
        if (contentRootPath.Contains("PublicAPI"))
        {
            contentRootPath = new StringBuilder(contentRootPath)
            .Replace(@"\PublicAPI", @"\Infrastructure\Database").ToString();
        }
        else 
        {
            contentRootPath = new StringBuilder(contentRootPath)
                .Replace(@"\GrpcService", @"\Infrastructure\Database").ToString();
        }


        if (connectionString is not null && connectionString.Contains(CONTENT_ROOT_PLACE_HOLDER))
        {
            connectionString = connectionString.Replace(CONTENT_ROOT_PLACE_HOLDER, contentRootPath);
        }
        return connectionString;
    }
}