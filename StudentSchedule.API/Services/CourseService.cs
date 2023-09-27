using StudentSchedule.API.Data;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Services.IServices;

namespace StudentSchedule.API.Services;

public class CourseService : ICourseService
{
    private readonly IServiceGatherer _gatherer;
    private readonly AppDbContext _context;
    
    public CourseService(IServiceGatherer gatherer, AppDbContext context)
    {
        _gatherer = gatherer;
        _context = context;
        
        _gatherer.Join(this);
    }
    
    public Task<List<Course>> GetCoursesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Course> GetCourseAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Course> AddCourseAsync(string title, string description, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCourseAsync(Course course)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCourseAsync(long id)
    {
        throw new NotImplementedException();
    }
}