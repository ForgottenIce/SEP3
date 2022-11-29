namespace Shared.Exception;

public class DirectoryNotFoundException:ArgumentException {
    
    public UserNotFoundException() : base("directory cannot be found") {
    }

    public UserNotFoundException(string? message) : base(message) {
    }

    public UserNotFoundException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}