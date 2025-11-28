namespace Nummy.CodeLogger.Utils.Exceptions;

internal class ApplicationIdValidationException()
    : NummyCodeLoggerException($"{nameof(NummyCodeLoggerOptions.ApplicationId)} must have a valid Guid value. Make sure to it copied from the Nummy.");