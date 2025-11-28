using Microsoft.Extensions.DependencyInjection;
using Nummy.HealthChecker.Data.Services;
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
        
        // todo

        return services;
    }
}