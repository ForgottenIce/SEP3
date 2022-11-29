namespace Shared.Exception;

public class UserNotFoundException: ArgumentException {
    
    public UserNotFoundException() : base("User was not found") {
    }

    public UserNotFoundException(string? message) : base(message) {
    }

    public UserNotFoundException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}