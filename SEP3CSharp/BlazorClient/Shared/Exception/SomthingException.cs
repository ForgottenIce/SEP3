namespace BlazorClient.Shared.Exception;

public class  SomthingException : ArgumentException {
    
    public SomthingException() : base("There is no more stock") {
    }

    public SomthingException(string? message) : base(message) {
    }

    public SomthingException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
}
