# SpecFlow.Gherkin
SpecFlow Gherkin

### docker-compose.yml
```yaml
version: '3.4'

services:
    sql_server:
        image: mcr.microsoft.com/mssql/server:latest
        ports:
            - "1433:1433"
        environment:
            SA_PASSWORD: 'P@ssword'
            ACCEPT_EULA: 'Y'
```

### PowerShell
```shell
docker-compose up --build
```

### appsettings.Development.json
```json
"ConnectionStrings": {
    "CustomerBase": {
      "ConnectionString": "Server=localhost,1433;Database=CustomerBase;User ID=sa;Password=P@ssword"
    }
  }
```

### Startup.cs
```csharp
public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddSqlServer(
                    name: "CustomerBase",
                    connectionString: Configuration["ConnectionStrings:CustomerBase:ConnectionString"],
                    tags: new string[] { "sqlserver" });
        }
```
