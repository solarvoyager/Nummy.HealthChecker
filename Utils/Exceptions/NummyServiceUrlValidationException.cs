namespace Nummy.CodeLogger.Utils.Exceptions;

internal class NummyServiceUrlValidationException()
    : NummyCodeLoggerException($"{nameof(NummyCodeLoggerOptions.NummyServiceUrl)} must have a valid Uri value. Make sure to it copied from the Nummy.");