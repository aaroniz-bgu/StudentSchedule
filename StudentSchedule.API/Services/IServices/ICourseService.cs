using StudentSchedule.API.Domain.Models;

namespace StudentSchedule.API.Services.IServices;

public interface ICourseService : IAppService
{
    Task<List<Course>> GetCoursesAsync();
    Task<Course> GetCourseAsync(long id);
    Task<Course> GetCourseEagerlyAsync(long id);
    Task<Course> AddCourseAsync(long semesterId, string title);
    Task UpdateCourseAsync(long id, string title);
    Task DeleteCourseAsync(long id);
}