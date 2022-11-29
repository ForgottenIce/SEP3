namespace Shared.Exception;

public class MethodAccessException:ArgumentException {
    
    public UserNotFoundException() : base("invalid attempt to access a method") {
    }

    public UserNotFoundException(string? message) : base(message) {
    }

    public UserNotFoundException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}