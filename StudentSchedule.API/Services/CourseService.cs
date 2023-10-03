using Microsoft.EntityFrameworkCore;
using StudentSchedule.API.Data;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Exception;
using StudentSchedule.API.Services.IServices;

namespace StudentSchedule.API.Services;
//TODO-> This service uses the gatherer once, consider not using it but rather access data straight from the context.
public class CourseService : ICourseService
{
    private readonly AppDbContext _context;
    
    public CourseService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _context.Courses.Include(e => e.Semester).AsNoTracking().ToListAsync();
    }

    public async Task<Course> GetCourseAsync(long id)
    {
        return await _context.Courses.FindAsync(id) ?? throw new NotFoundException($"Course with {id} id was not found.");
    }
    
    public async Task<Course> GetCourseEagerlyAsync(long id)
    {
        return await _context.Courses
            .Include(e => e.Semester)
            .Include(e => e.Lessons)
            .Include(e => e.Tasks)
            .Include(e => e.Exams)
            .FirstOrDefaultAsync(e => e.Id == id) ?? throw new NotFoundException($"Course with {id} id was not found.");
    }

    public async Task<Course> AddCourseAsync(long semesterId, string title)
    {
        if(string.IsNullOrEmpty(title)) throw new ArgumentException("Title cannot be null or empty.");
        
        var semester = await _context.Semesters
                           .Include(e => e.Courses)
                           .FirstOrDefaultAsync(e => e.Id == semesterId) 
                       ?? throw new NotFoundException($"Semester with {semesterId} id was not found.");
        
        //Note to self, this adds the course to the semester as well automatically.
        var course = new Course(title, semester);
        
        var addTask = await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();

        return addTask.Entity;
    }

    public async Task UpdateCourseAsync(long id, string title)
    {
        if(string.IsNullOrEmpty(title)) throw new ArgumentException("Title cannot be null or empty.");
        
        var course = await GetCourseAsync(id);
        course.Title = title;
        
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCourseAsync(long id)
    {
        var course = await GetCourseAsync(id);
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
    }
}