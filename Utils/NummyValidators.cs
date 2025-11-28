using Nummy.HealthChecker.Utils.Exceptions;

namespace Nummy.HealthChecker.Utils;

internal static class NummyValidators
{
    public static void ValidateNummyHealthCheckerOptions(NummyHealthCheckerOptions options)
    {
        if (options.CheckPeriodSeconds < 5)
            throw new NummyCheckPeriodSecondsValidationException();
    }
}