namespace Shared.Exceptions;

public class WrongPasswordException: ArgumentException {
    
    public WrongPasswordException() : base("Password dose not match the user") {
    }

    public WrongPasswordException(string? message) : base(message) {
    }

    public WrongPasswordException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }

    
}