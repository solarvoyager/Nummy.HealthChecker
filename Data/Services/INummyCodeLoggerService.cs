using Nummy.CodeLogger.Data.Entitites;

namespace Nummy.CodeLogger.Data.Services;

public interface INummyCodeLoggerService
{
    Task LogErrorAsync(string title, string? description = null);
    Task LogErrorAsync(Exception ex);
    Task LogInfoAsync(string title, string? description = null);
    Task LogInfoAsync(Exception ex);
    Task LogWarningAsync(string title, string? description = null);
    Task LogWarningAsync(Exception ex);
    Task LogAsync(NummyCodeLogLevel logLevel, string title, string? description = null);
    Task LogAsync(NummyCodeLogLevel logLevel, Exception ex);
}