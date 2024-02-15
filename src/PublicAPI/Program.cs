using FluentValidation.AspNetCore;
using KOF.RouteMap.API.Filters;
using KOF.RouteMap.Application;
using KOF.RouteMap.Application.VisitPlan.GraphQLQueries;
using KOF.RouteMap.Application.VisitPlan.GraphQLServices;
using KOF.RouteMap.Domain.Tenant;
using KOF.RouteMap.Infrastructure;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();

#region TenantResolution

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITenant>(sp =>
{
    var tenantIdString = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Request.Query["TenantId"];

    return tenantIdString != StringValues.Empty && 
        int.TryParse(tenantIdString, out var tenantId)
        ? new Tenant(tenantId)
        : null;
});

#endregion

builder.Services.AddInfrastructure(builder.Configuration,builder.Environment.ContentRootPath);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Superheroes Coca Cola",
        Description = "Demo API - Clean Architecture Solution in .NET 8 for KOF",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);


builder.Services.AddApplicationInsightsTelemetry(builder.Configuration);

builder.Logging.AddApplicationInsights(
        configureTelemetryConfiguration: (config) =>
        config.ConnectionString = "InstrumentationKey=" + builder.Configuration["ApplicationInsights:InstrumentationKey"],
        configureApplicationInsightsLoggerOptions: (options) => { });

builder.Logging.AddFilter("KOF Log Category", LogLevel.Trace);

builder.Services.AddTransient<VisitPlanGraphQLService>();
builder.Services
    .AddGraphQLServer()
    //.RegisterDbContext<ApplicationDbContext>()
    //.RegisterDbContext<ApplicationDbContext>(DbContextKind.Pooled)
    .RegisterService<VisitPlanGraphQLService>()
    .AddQueryType<VisitPlanQuery>()
    .AddSorting()
    .AddFiltering();

Console.WriteLine("Enabling CORS");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowEverything", 
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();

// Seed Data
//using (var scope = app.Services.CreateScope())
//{
//    var scopeProvider = scope.ServiceProvider;
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//    await ApplicationDbContextSeed.SeedSampleDataAsync(dbContext);
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.InjectStylesheet("/swagger-ui/custom.css");
    });
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowEverything");
app.UseRouting();
app.MapControllers();
app.MapGraphQL();
app.Run();

