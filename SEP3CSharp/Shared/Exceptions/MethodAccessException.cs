namespace Shared.Exceptions;

public class MethodAccessException:ArgumentException {
    
    public MethodAccessException() : base("invalid attempt to access a method") {
    }

    public MethodAccessException(string? message) : base(message) {
    }

    public MethodAccessException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}