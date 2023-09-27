using StudentSchedule.API.Services.IServices;

namespace StudentSchedule.API.Services;

public class ServiceGatherer : IServiceGatherer
{
    public ICourseService CourseService { get; private set; }
    public ISemesterService SemesterService { get; private set; }
    public ITaskService TaskService { get; private set; }
    
    
    public void Join(ICourseService courseService)
    {
        CourseService = courseService;
        TaskService = taskService;
    }
}