namespace StudentSchedule.API.Services.IServices;

public interface IServiceGatherer
{
    ICourseService CourseService { get; }
    ISemesterService SemesterService { get; }
    ITaskService TaskService { get; }
}