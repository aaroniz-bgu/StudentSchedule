namespace StudentSchedule.API.Services.IServices;

public interface IServiceGatherer
{
    ICourseService CourseService { get; }
    ISemesterService SemesterService { get; }
    ITaskService TaskService { get; }
    
    void Join(ICourseService courseService);
    void Join(ISemesterService semesterService);
    void Join(ITaskService taskService);
}