using System.Runtime.Serialization;

namespace Shared.Exceptions;

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
}