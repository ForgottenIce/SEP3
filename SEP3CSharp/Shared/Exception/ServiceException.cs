namespace Shared.Exception;

public class ServiceException: ArgumentException {
    
    public ServiceException() : base("Service not available") {
    }

    public ServiceException(string? message) : base(message) {
    }

    public ServiceException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
}
