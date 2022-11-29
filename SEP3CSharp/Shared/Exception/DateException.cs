using System.Runtime.Serialization;

namespace Shared.Exception;

public class DateException : NotSupportedException
{
    public DateException() : base("Date is not correct")
    {
    }

    protected DateException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public DateException(string? message) : base(message)
    {
    }

    public DateException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException)
    {
    }
}