using System.Runtime.Serialization;

namespace ParseTree;

public class InvalidOperatorException : Exception
{
    public InvalidOperatorException()
    {
    }

    protected InvalidOperatorException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public InvalidOperatorException(string? message) : base(message)
    {
    }

    public InvalidOperatorException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}