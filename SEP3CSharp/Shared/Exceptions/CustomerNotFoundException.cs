namespace Shared.Exceptions;

public class CustomerNotFoundException: ArgumentException {
    
    public CustomerNotFoundException() : base("Customer was not found") {
    }

    public CustomerNotFoundException(string? message) : base(message) {
    }

    public CustomerNotFoundException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}