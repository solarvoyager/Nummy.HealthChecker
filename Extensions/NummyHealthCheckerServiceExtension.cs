using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nummy.HealthChecker.Utils;

namespace Nummy.HealthChecker.Extensions;

public static class NummyHealthCheckerServiceExtension
{
    public static IServiceCollection AddNummyHealthChecker(this IServiceCollection services,
        Action<NummyHealthCheckerOptions> options)
    {
        var codeLoggerOptions = new NummyHealthCheckerOptions();
        options.Invoke(codeLoggerOptions);

        NummyValidators.ValidateNummyHealthCheckerOptions(codeLoggerOptions);

        services.Configure(options);
        
        return services;
    }
    
    public static IEndpointConventionBuilder MapNummyHealthChecker(this IEndpointRouteBuilder endpoints)
    {
        var opts = endpoints.ServiceProvider
            .GetRequiredService<IOptions<NummyHealthCheckerOptions>>()
            .Value;

        var path = string.IsNullOrWhiteSpace(opts.Path)
            ? NummyConstants.DefaultCheckUrl
            : opts.Path;

        return endpoints.MapGet(path, async context =>
        {
            var options = context.RequestServices
                .GetRequiredService<IOptions<NummyHealthCheckerOptions>>()
                .Value;

            var result = await options.CheckAsync(
                context.RequestServices,
                context.RequestAborted);

            context.Response.StatusCode = result.IsHealthy ? 200 : 503;
            context.Response.ContentType = "application/json";

            var response = new
            {
                status = result.IsHealthy ? "Healthy" : "Unhealthy",
                message = result.Message,
                details = result.Details
            };

            await context.Response.WriteAsJsonAsync(response);
        });
    }
}