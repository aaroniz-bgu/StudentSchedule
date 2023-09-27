namespace StudentSchedule.API.Services.IServices;

public interface IServiceGatherer
{
    ICourseService CourseService { get; }
    ISemesterService SemesterService { get; }
    
    void Join(ICourseService courseService);
    void Join(ISemesterService semesterService);

}