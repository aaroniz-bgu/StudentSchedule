
using Microsoft.AspNetCore.Mvc;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Services.IServices;

namespace StudentSchedule.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _service;
    
    public CourseController(ICourseService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetCoursesAsync()
    {
        var courses = await _service.GetCoursesAsync();
        return Ok(courses);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetCourseAsync(long id)
    {
        var course = await _service.GetCourseAsync(id);
        return Ok(course);
    }
    
    [HttpPost]
    public async Task<ActionResult> AddCourseAsync(string title, string description, DateTime startDate, DateTime endDate)
    {
        var newCourse = await _service.AddCourseAsync(title, description, startDate, endDate);
        return Ok(newCourse);
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdateCourseAsync(Course course)
    {
        await _service.UpdateCourseAsync(course);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCourseAsync(long id)
    {
        await _service.DeleteCourseAsync(id);
        return Ok();
    }
}