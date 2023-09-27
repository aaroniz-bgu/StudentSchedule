using StudentSchedule.API.Domain.Models;

namespace StudentSchedule.API.Services.IServices;

public interface ITaskService
{
    Task<List<CourseTask>> GetTasksAsync();
    Task<CourseTask> GetTaskAsync(long id);
    Task<CourseTask> GetTaskEagerlyAsync(long id);
    Task<CourseTask> AddTaskAsync(long courseId, string title, string description, DateTime deadline, int type);
    Task UpdateTaskAsync(CourseTask updated);
    Task UpdateTaskProgressAsync(long id, int progress);
    Task DeleteTaskAsync(long id);
}