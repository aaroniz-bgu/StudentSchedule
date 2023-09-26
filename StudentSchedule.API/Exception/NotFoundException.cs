namespace StudentSchedule.API.Exception;

public class NotFoundException : AppException
{
    public NotFoundException(string message) : base(StatusCodes.Status404NotFound, message)
    {
        //Hi
    }
}