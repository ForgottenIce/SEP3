namespace Shared.Exception;

public class ServiceException: ArgumentException {
    
    public SomthingException() : base("Service not available") {
    }

    public SomthingException(string? message) : base(message) {
    }

    public SomthingException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
}
}