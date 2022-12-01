namespace Shared.Exception;

public class WarehouseNotFoundException: ArgumentException {
    
    public WarehouseNotFoundException() : base("No warehouse found") {
    }

    public WarehouseNotFoundException(string? message) : base(message) {
    }

    public WarehouseNotFoundException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException)
    {}
    }