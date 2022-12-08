namespace Shared.Exceptions;

public class NullException: ArgumentException
{
    public NullException() : base("Must fill in the forms")
    {
    }

    public NullException(string? message) : base(message)
    {
    }

    public NullException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}