using Microsoft.Extensions.DependencyInjection;
using Nummy.CodeLogger.Data.Services;
using Nummy.CodeLogger.Utils;

namespace Nummy.CodeLogger.Extensions;

public static class NummyCodeLoggerServiceExtension
{
    public static IServiceCollection AddNummyCodeLogger(this IServiceCollection services,
        Action<NummyCodeLoggerOptions> options)
    {
        var codeLoggerOptions = new NummyCodeLoggerOptions();
        options.Invoke(codeLoggerOptions);

        NummyValidators.ValidateNummyCodeLoggerOptions(codeLoggerOptions);

        services.Configure(options);

        services.AddHttpContextAccessor();

        services.AddSingleton<INummyCodeLoggerService, NummyCodeLoggerService>();

        services.AddHttpClient(NummyConstants.ClientName, config =>
        {
            config.BaseAddress = new Uri(codeLoggerOptions.NummyServiceUrl!);
            config.Timeout = new TimeSpan(0, 0, 30);
            config.DefaultRequestHeaders.Clear();
        });

        return services;
    }
}