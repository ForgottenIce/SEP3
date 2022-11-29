namespace Shared.Exception;

public class UnauthorizedException:ArgumentException {
    
    public UserNotFoundException() : base("Unauthorized action") {
    }

    public UserNotFoundException(string? message) : base(message) {
    }

    public UserNotFoundException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}
}