using GrpcService.Services;
using KOF.RouteMap.Application;
using Microsoft.OpenApi.Models;
using System.Reflection;
using KOF.RouteMap.Infrastructure;
using KOF.RouteMap.Domain.Tenant;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureEndpointDefaults(defaults =>
                  defaults.Protocols = HttpProtocols.Http2);

    //options.ListenAnyIP(5036);
    //options.ListenAnyIP(7117, listenOptions =>
    //{
    //    listenOptions.Protocols = HttpProtocols.Http2;
    //});

    //options.ListenAnyIP(7118, listenOptions =>
    //{
    //    listenOptions.Protocols = HttpProtocols.Http;
    //});
});

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

builder.Services.AddInfrastructure(builder.Configuration, builder.Environment.ContentRootPath);

builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;
}).AddJsonTranscoding();
builder.Services.AddGrpcSwagger();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    c.IncludeGrpcXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
app.MapGrpcService<GreeterService>();
app.MapGrpcService<VisitPlanService>();

app.Run();