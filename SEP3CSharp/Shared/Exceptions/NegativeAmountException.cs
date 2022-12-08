namespace Shared.Exceptions;

public class NegativeAmountException: ArgumentException {
    
    public NegativeAmountException() : base("You can't order a negative amount") {
    }

    public NegativeAmountException(string? message) : base(message) {
    }

    public NegativeAmountException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}