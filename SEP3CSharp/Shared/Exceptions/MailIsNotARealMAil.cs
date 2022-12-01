namespace Shared.Exceptions;

public class MailIsNotARealMAil: ArgumentException
{
    public MailIsNotARealMAil() : base("Mail is not a real mail")
    {
    }

    public MailIsNotARealMAil(string? message) : base(message)
    {
    }

    public MailIsNotARealMAil(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException) {
    }
    
}