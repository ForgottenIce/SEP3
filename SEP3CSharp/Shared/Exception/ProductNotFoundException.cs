namespace Shared.Exception;

public class ProductNotFoundException : ArgumentException {
    
    public ProductNotFoundException() : base("No product was found.") {
    }

    public ProductNotFoundException(string? message) : base(message) {
    }

    public ProductNotFoundException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
}