using Microsoft.EntityFrameworkCore;
using StudentSchedule.API.Data;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Exception;
using StudentSchedule.API.Services.IServices;

namespace StudentSchedule.API.Services;
//TODO-> This class has only one call to the gatherer look into eliminating it.
public class TaskService : AppService, ITaskService
{
    private readonly AppDbContext _context;
    
    public TaskService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<CourseTask>> GetTasksAsync()
    {
        return await _context.Tasks.AsNoTracking().ToListAsync();
    }

    public async Task<CourseTask> GetTaskAsync(long id)
    {
        var task = await _context.Tasks.FindAsync(id);
        return task ?? throw new NotFoundException($"Task with {id} id was not found.");
    }

    public async Task<CourseTask> GetTaskEagerlyAsync(long id)
    {
        return await _context.Tasks
            .Include(t => t.Course)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id) ?? throw new NotFoundException($"Task with {id} id was not found.");
    }

    public async Task<CourseTask> AddTaskAsync(long courseId, string title, string description, DateTime deadline, int type)
    {
        IsValidRequest(title, description, deadline, type);
        
        //Consider not using this, but rather access the course straight from the context:
        var course = await _gatherer.CourseService.GetCourseEagerlyAsync(courseId);
        
        var task = new CourseTask(title, description, deadline, (TaskType) type, course);
        
        var addTask = await _context.Tasks.AddAsync(task);
        
        await _context.SaveChangesAsync();
        
        return addTask.Entity; //Returned with auto-generated id.
    }

    public async Task UpdateTaskAsync(CourseTask updated)
    {
        IsValidRequest(updated);

        var task = await GetTaskEagerlyAsync(updated.Id);
        
        task.Title = updated.Title;
        task.Description = updated.Description;
        task.DueDate = updated.DueDate;
        task.Type = updated.Type;
        
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTaskProgressAsync(long id, int progress)
    {
        if (progress < 0)
        {
            throw new ArgumentException("Progress cannot be negative.");
        }
        
        var task = await GetTaskEagerlyAsync(id);

        if (progress > task.MaxProgress)
        {
            throw new ArgumentException("Progress cannot be greater than max progress.");
        }
        
        task.Progress = progress;
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(long id)
    {
        var task = await GetTaskAsync(id);
        _context.Tasks.Remove(task);
    }
    
    private void IsValidRequest(string title, string description, DateTime deadline, int type)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty or null.");
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty or null.");
        if (deadline < DateTime.Now)
            throw new ArgumentException("Deadline cannot be in the past.");
        if (type < 0 || type > 2)
            throw new ArgumentException("Type must be between 0 and 3.");
    }
    
    private void IsValidRequest(CourseTask task)
    {
        IsValidRequest(task.Title, task.Description, task.DueDate, (int) task.Type);
    }

}