using System.Runtime.Serialization;

namespace Shared.Exception;

public class TimeException : NotSupportedException
{
    public TimeException() : base("Time is not correct")
    {
    }

    protected TimeException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public TimeException(string? message) : base(message)
    {
    }

    public TimeException(string? message, string? paramName, System.Exception? innerException) : base(message, paramName, innerException)  
    {
    }
}