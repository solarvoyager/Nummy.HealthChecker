using Nummy.HealthChecker.Entites;

namespace Nummy.HealthChecker.Utils;

public class NummyHealthCheckerOptions
{
    /// <summary>
    /// Endpoint path. Default: /nummy/health
    /// </summary>
    public string Path { get; set; } = NummyConstants.DefaultCheckUrl;

    /// <summary>
    /// Main check function.
    /// Returns NummyHealthResult with IsHealthy = true (healthy), IsHealthy = false (unhealthy).
    /// </summary>
    public Func<IServiceProvider, CancellationToken, Task<NummyHealthResult>> CheckAsync { get; set; }
        = DefaultCheckAsync;
    
    private static Task<NummyHealthResult> DefaultCheckAsync(
        IServiceProvider sp,
        CancellationToken ct)
    {
        return Task.FromResult(new NummyHealthResult
        {
            IsHealthy = true,
            Message = "OK"
        });
    }
}