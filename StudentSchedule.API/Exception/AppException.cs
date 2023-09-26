namespace StudentSchedule.API.Exception;

public class AppException : System.Exception
{
    public int StatusCode { get; set; }
    
    public AppException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}