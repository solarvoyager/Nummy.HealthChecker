namespace Nummy.HealthChecker.Utils.Exceptions;

internal class NummyCheckPeriodSecondsValidationException()
    : NummyHealthCheckerException($"{nameof(NummyHealthCheckerOptions.CheckPeriodSeconds)} can not be less than 5 seconds.");