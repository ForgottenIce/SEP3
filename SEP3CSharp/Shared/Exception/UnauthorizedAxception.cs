namespace Shared.Exception;

public class UnauthorizedException:ArgumentException {
    
    public UnauthorizedException() : base("Unauthorized action") {
    }

    public UnauthorizedException(string? message) : base(message) {
    }

    public UnauthorizedException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}
