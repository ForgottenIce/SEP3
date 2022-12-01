using System.Data;

namespace Shared.Exceptions;

public class InvalidAgeException : ArgumentException
{
    public InvalidAgeException() : base("Age is invalid")
    {
    }

    public InvalidAgeException(string? message) : base(message)
    {
    }

    public InvalidAgeException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
}