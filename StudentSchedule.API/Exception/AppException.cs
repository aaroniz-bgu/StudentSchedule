namespace StudentSchedule.API.Exception;

public class AppException : System.Exception
{
    public int StatusCode { get; protected set; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="statusCode">HTTPStatus code.</param>
    /// <param name="message">Message describing the exception occured.</param>
    public AppException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="statusCode">HTTPStatus code.</param>
    /// <param name="exception">Inner exception.</param>
    public AppException(int statusCode, System.Exception exception) : base(exception.Message, exception)
    {
        StatusCode = statusCode;
    }
}