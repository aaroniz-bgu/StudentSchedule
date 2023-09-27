namespace StudentSchedule.API.Exception;

public class AppException : System.Exception
{
    public int StatusCode { get; protected set; }
    
    public AppException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public AppException(int statusCode, System.Exception exception) : base(exception.Message, exception)
    {
        StatusCode = statusCode;
    }
}