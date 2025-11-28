using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Nummy.CodeLogger.Data.Entitites;
using Nummy.CodeLogger.Utils;

namespace Nummy.CodeLogger.Data.Services;

internal class NummyCodeLoggerService(
    IHttpClientFactory clientFactory,
    IHttpContextAccessor contextAccessor,
    IOptions<NummyCodeLoggerOptions> options
)
    : INummyCodeLoggerService
{
    private readonly HttpClient _client = clientFactory.CreateClient(NummyConstants.ClientName);

    public async Task LogErrorAsync(string title, string? description = null)
    {
        await LogAsync(NummyCodeLogLevel.Error, title, description);
    }

    public async Task LogErrorAsync(Exception ex)
    {
        await LogAsync(NummyCodeLogLevel.Error, ex);
    }

    public async Task LogInfoAsync(string title, string? description = null)
    {
        await LogAsync(NummyCodeLogLevel.Info, title, description);
    }

    public async Task LogInfoAsync(Exception ex)
    {
        await LogAsync(NummyCodeLogLevel.Info, ex);
    }

    public async Task LogWarningAsync(string title, string? description = null)
    {
        await LogAsync(NummyCodeLogLevel.Warning, title, description);
    }

    public async Task LogWarningAsync(Exception ex)
    {
        await LogAsync(NummyCodeLogLevel.Warning, ex);
    }

    public async Task LogAsync(NummyCodeLogLevel logLevel, string title, string? description = null)
    {
        var data = new NummyCodeLog
        {
            TraceIdentifier = contextAccessor.HttpContext.TraceIdentifier,
            ApplicationId = options.Value.ApplicationId,
            LogLevel = logLevel,
            Title = title,
            Description = description
        };

        await InsertLogAsync(data);
    }

    public async Task LogAsync(NummyCodeLogLevel logLevel, Exception ex)
    {
        var data = new NummyCodeLog
        {
            TraceIdentifier = contextAccessor.HttpContext.TraceIdentifier,
            ApplicationId = options.Value.ApplicationId,
            LogLevel = logLevel,
            Title = ex.Message,
            StackTrace = ex.StackTrace,
            InnerException = ex.InnerException?.ToString(),
            ExceptionType = ex.GetType().FullName,
            Description = ex.ToString()
        };

        await InsertLogAsync(data);
    }

    private async Task InsertLogAsync(NummyCodeLog data)
    {
        await _client.PostAsJsonAsync(NummyConstants.CodeLogAddUrl, data);
    }
}