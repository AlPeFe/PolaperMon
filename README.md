# PolaperMon

A lightweight health monitoring service built with .NET 10 and ASP.NET Core HealthChecks.

## Features

- **SQL Server Monitoring** - Database connectivity health checks
- **Disk Storage Monitoring** - Track available disk space with configurable thresholds
- **HTTP Endpoint Monitoring** - Monitor external APIs and services
- **Health Checks UI** - Built-in dashboard for visualizing health status
- **Windows Service** - Run as a native Windows service

## Endpoints

| Endpoint | Description |
|----------|-------------|
| `/health` | Full health check with JSON response |
| `/health/ready` | Readiness probe |
| `/healthchecks-ui` | Web dashboard |

## Configuration

Configure monitoring targets in `appsettings.json`:

```json
{
  "SqlServer": {
    "ConnectionString": "Server=localhost,1433;Database=master;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
  },
  "Disk": {
    "Drive": "/",
    "ThresholdMB": 1024
  },
  "EndpointSettings": {
    "Endpoints": [
      { "Name": "API Principal", "Url": "https://api.example.com/health" },
      { "Name": "Payment Service", "Url": "https://payments.example.com/status" }
    ]
  }
}
```

| Setting | Description |
|---------|-------------|
| `SqlServer:ConnectionString` | SQL Server connection string for DB health checks |
| `Disk:Drive` | Drive to monitor (e.g., `/` on Linux, `C:` on Windows) |
| `Disk:ThresholdMB` | Minimum free space in MB before reporting unhealthy |
| `EndpointSettings:Endpoints` | Array of external endpoints to monitor |

## Quick Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Run

```bash
dotnet restore
dotnet run --project PolaperMon
```

### Build

```bash
dotnet build
```

### Publish

```bash
dotnet publish -c Release -o ./publish
```

## Running as a Windows Service

PolaperMon is configured to run as a Windows Service. After publishing:

```powershell
sc create PolaperMon binPath="C:\path\to\publish\PolaperMon.exe"
sc start PolaperMon
```

## Tech Stack

- .NET 10 / ASP.NET Core
- [AspNetCore.HealthChecks](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks)
- Microsoft.Extensions.Hosting.WindowsServices

## License

MIT
