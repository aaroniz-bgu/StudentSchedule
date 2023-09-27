using Microsoft.AspNetCore.Mvc;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Services.IServices;
using StudentSchedule.Contracts.Requests;
using StudentSchedule.Contracts.Responses;

namespace StudentSchedule.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _service;
    
    public TaskController(IServiceGatherer gatherer)
    {
        _service = gatherer.TaskService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetTasks()
    {
        var tasks = await _service.GetTasksAsync();
        var response = tasks.Select(ConvertResponse).ToList();
        return Ok(response);
    }
    
    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetTask(long id)
    {
        var task = await _service.GetTaskAsync(id);
        var response = ConvertResponse(task);
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddTask(long courseId, string title, string description, DateTime deadline, int type)
    {
        var task = await _service.AddTaskAsync(courseId, title, description, deadline, type);
        var response = ConvertResponse(task);
        return CreatedAtAction(nameof(GetTask), new { id = response.Id }, response);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateTask(TaskRequest request)
    {
        var task = ConvertRequest(request);
        await _service.UpdateTaskAsync(task);
        return Ok();
    }
    
    [HttpPut("progress/{id:long}/{progress:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateTaskProgress(long id, int progress)
    {
        await _service.UpdateTaskProgressAsync(id, progress);
        return Ok();
    }
    
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteTask(long id)
    {
        await _service.DeleteTaskAsync(id);
        return NoContent();
    }

    private CourseTask ConvertRequest(TaskRequest request)
    {
        return new CourseTask(
            request.Id,
            request.Title,
            request.Description,
            request.DueDate,
            (TaskType) request.Type
            );
    }
    
    private TaskResponse ConvertResponse(CourseTask task)
    {
        return new TaskResponse(
            task.Course.Id,
            task.Id,
            (int)task.Type,
            task.Title,
            task.Description,
            task.DueDate,
            task.Progress,
            task.IsCompleted
            );
    }
    
}