using StudentSchedule.API.Data;
using StudentSchedule.API.Domain.Models;
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
    
    public Task<List<CourseTask>> GetTasksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CourseTask> GetTaskAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CourseTask> GetTaskEagerlyAsync(long id)
    {
        throw new NotImplementedException();
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