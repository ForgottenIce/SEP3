namespace Shared.Exception;

public class WrongUsernameException: ArgumentException {
    
    public WrongUsernameException() : base("Username dose not match a user") {
    }

    public WrongUsernameException(string? message) : base(message) {
    }

    public WrongUsernameException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }

}