using System.Net;

namespace ScoreCard.Domain.Exceptions;

public class ResumDomainException: DomainException
{
    public ResumDomainException()
    {
    }

    public ResumDomainException(string message)
        : base(message)
    {
    }

    public ResumDomainException(string message, HttpStatusCode? httpStatusCode)
        : base(message, httpStatusCode)
    {
    }

    public ResumDomainException(string message, Exception exception)
        : base(message, exception)
    {
    }

    public ResumDomainException(string message, HttpStatusCode? httpStatusCode, Exception exception)
        : base(message, httpStatusCode, exception)
    {
    }
    
}