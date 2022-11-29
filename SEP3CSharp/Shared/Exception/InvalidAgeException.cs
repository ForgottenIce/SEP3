namespace Shared.Exception;

public class InvalidAgeException : System.Exception
{
    public InvalidAgeException() : base("Age is invalid")
    {
    }

    public InvalidAgeException(string? message) : base(message)
    {
    }

    public InvalidAgeException(string message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException)
    {
    }
}