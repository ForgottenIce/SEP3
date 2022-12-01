namespace Shared.Exceptions;
public class NotFoundException : Exception {
    public NotFoundException() : base("The requested resource was not found") {
    }

    public NotFoundException(string? message) : base(message) {
    }

    public NotFoundException(object obj) : base($"The requested {obj.GetType().Name} object was not found") {
    }

    public NotFoundException(string? message, Exception? innerException) : base(message, innerException) {
    }
}

