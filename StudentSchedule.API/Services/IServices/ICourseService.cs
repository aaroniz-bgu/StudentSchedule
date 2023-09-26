using StudentSchedule.API.Domain.Models;

namespace StudentSchedule.API.Services.IServices;

public interface ICourseService
{
    Task<List<Course>> GetCoursesAsync();
    Task<Course> GetCourseAsync(long id);
    Task<Course> AddCourseAsync(string title, string description, DateTime startDate, DateTime endDate);
    Task UpdateCourseAsync(Course course);
    Task DeleteCourseAsync(long id);
}