using System.Net;

namespace BlogPostWebAPI.Common.Exceptions;

public class StatusCodeException : Exception
{
    public new string Message { get; set; } 
    public HttpStatusCode StatusCode { get; set; }

    public StatusCodeException(HttpStatusCode code, string message)
    {
        Message = message; 
        StatusCode = code;
    }
}