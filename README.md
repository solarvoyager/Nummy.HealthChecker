# Nummy Health Checker package for .NET Core

[![NuGet Version](https://img.shields.io/nuget/v/Nummy.HealthChecker.svg)](https://www.nuget.org/packages/Nummy.HealthChecker/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Nummy.HealthChecker.svg)](https://www.nuget.org/packages/Nummy.HealthChecker/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## Overview

This is a .NET Core library for health checking in your application.

---

## Installation

[Nuget - Nummy.HealthChecker](https://www.nuget.org/packages/Nummy.HealthChecker)

or install the package via NuGet Package Manager Console:

```bash
Install-Package Nummy.HealthChecker
```

## Getting Started

#### 1. Run Nummy on your Docker

[Here is tutorial](https://github.com/solarvoyager/Nummy/blob/master/README.md)

#### 2. Add your application in Nummy

#### 3. Configure in your project

In your `Program.cs` file add the following line:

```csharp
using Nummy.HealthChecker.Extensions;
using Nummy.HealthChecker.Entites;
```

```csharp
// .. other configurations

// Register checker and configure the check
builder.Services.AddNummyHealthChecker(options =>
{
    options.Path = "nummy/health"; // default is nummy/health

    options.CheckAsync = async (sp, ct) =>
    {
        // Example: use services from DI
        // var db = sp.GetRequiredService<MyDbContext>();
        // await db.Database.ExecuteSqlRawAsync("SELECT 1", ct);

        // For now: simple “OK”
        return new NummyHealthResult
        {
            IsHealthy = true,
            Message = "Service is healthy"
        };
    };
});

// .. other configurations
var app = builder.Build();

// Map Health endpoint
app.MapNummyHealthChecker();
// Other endpoints, e.g. controllers
app.MapControllers();

// .. other configurations
```

#### 4. Now, your application is set up using the Nummy Health Checker.

You can see it's status in Nummy.

## License

This library is licensed under the MIT License.