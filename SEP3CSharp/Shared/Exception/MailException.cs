namespace Shared.Exception;


public class MailException : ArgumentException
{
    public MailException() : base("Mail is already used")
    {
    }

    public MailException(string? message) : base(message)
    {
    }

    public MailException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
}