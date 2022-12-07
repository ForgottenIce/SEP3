namespace Shared.Exceptions;

public class DirectoryNotFoundException:ArgumentException {
    
    public DirectoryNotFoundException() : base("directory cannot be found") {
    }

    public DirectoryNotFoundException(string? message) : base(message) {
    }

    public DirectoryNotFoundException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}