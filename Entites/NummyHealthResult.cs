namespace Nummy.HealthChecker.Entites;

public sealed class NummyHealthResult
{
    public bool IsHealthy { get; set; }
    public string? Message { get; set; }
    public object? Details { get; set; }
}