using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWindowsService();

var sql = builder.Configuration["SqlServer:ConnectionString"];
var drive = builder.Configuration["Disk:Drive"] ?? "/";
var threshold = long.Parse(builder.Configuration["Disk:ThresholdMB"] ?? "1024");
var endpoints = builder.Configuration.GetSection("EndpointSettings:Endpoints").Get<EndpointItem[]>();

var checks = builder.Services.AddHealthChecks()
    .AddSqlServer(sql ?? "", "sql-server")
    .AddDiskStorageHealthCheck(d => d.AddDrive(drive, threshold), "disco");

if (endpoints != null)
    foreach (var e in endpoints)
        checks.AddUrlGroup(new Uri(e.Url), e.Name);

builder.Services.AddHealthChecksUI(o => o.AddHealthCheckEndpoint("PolaperMon", "/health"))
    .AddInMemoryStorage();

var app = builder.Build();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecks("/health/ready");
app.MapHealthChecksUI();
app.Run();

record EndpointItem(string Name, string Url);
