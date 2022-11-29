namespace Shared.Exception;

public class ToLargeAmountException: ArgumentException {
    
    public ToLargeAmountException() : base("The amount ordered is bigger then our stock") {
    }

    public ToLargeAmountException(string? message) : base(message) {
    }

    public ToLargeAmountException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }   
    
}