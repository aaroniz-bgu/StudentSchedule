using Microsoft.EntityFrameworkCore;
using StudentSchedule.API.Data;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Exception;
using StudentSchedule.API.Services.IServices;

namespace StudentSchedule.API.Services;

public class TaskService : ITaskService
{
    private readonly IServiceGatherer _gatherer;
    private readonly AppDbContext _context;
    
    public TaskService(IServiceGatherer gatherer, AppDbContext context)
    {
        _gatherer = gatherer;
        _context = context;
        
        _gatherer.Join(this);
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

    public Task<CourseTask> AddTaskAsync(long courseId, string title, string description, DateTime deadline, int type)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTaskAsync(CourseTask updated)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTaskProgressAsync(long id, int progress)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTaskAsync(long id)
    {
        throw new NotImplementedException();
    }
}