using StudentSchedule.API.Services.IServices;

namespace StudentSchedule.API.Services;

public class ServiceGatherer : IServiceGatherer
{
    public ICourseService CourseService { get; private set; }
    public ISemesterService SemesterService { get; private set; }
    public ITaskService TaskService { get; private set; }
    
    public ServiceGatherer(
        ICourseService courseService,
        ISemesterService semesterService,
        ITaskService taskService
        )
    {
        SemesterService = semesterService;
        CourseService = courseService;
        TaskService = taskService;
        
        semesterService.AddGatherer(this);
        courseService.AddGatherer(this);
        taskService.AddGatherer(this);
    }
}