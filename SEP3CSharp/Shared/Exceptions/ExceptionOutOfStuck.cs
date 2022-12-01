namespace Shared.Exceptions;

public class ExceptionOutOfStuck: ArgumentException {
    
    public ExceptionOutOfStuck() : base("Out of stuck of" /* + Item*/) {
    }

    public ExceptionOutOfStuck(string? message) : base(message) {
    }

    public ExceptionOutOfStuck(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }   
}