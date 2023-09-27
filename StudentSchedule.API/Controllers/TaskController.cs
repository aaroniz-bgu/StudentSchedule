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
    private readonly ITaskService _taskService;
    
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetTasks()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetTask(long id)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public async Task<ActionResult> AddTask(long courseId, string title, string description, DateTime deadline, int type)
    {
        throw new NotImplementedException();
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdateTask(TaskRequest request)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTask(long id)
    {
        throw new NotImplementedException();
    }
    
    private CourseTask ConvertRequest(TaskRequest request)
    {
        throw new NotImplementedException();
    }
    
    private TaskResponse ConvertResponse(CourseTask task)
    {
        throw new NotImplementedException();
    }
    
}