
using Microsoft.AspNetCore.Mvc;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Services.IServices;
using StudentSchedule.Contracts.Requests;
using StudentSchedule.Contracts.Responses;

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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetCourses()
    {
        var courses = await _service.GetCoursesAsync();
        var response = courses.Select(ConvertResponse).ToList();
        return Ok(response);
    }
    
    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetCourse(long id)
    {
        var course = await _service.GetCourseAsync(id);
        var response = ConvertResponse(course);
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddCourse(CourseRequest request)
    {
        var course = await _service.AddCourseAsync(request.SemesterId, request.Title);
        var response = ConvertResponse(course);
        return CreatedAtAction(nameof(GetCourse), new { id = response.Id },response);
    }
    
    [HttpPut("{id:long}/{title}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateCourse(long id, string title)
    {
        await _service.UpdateCourseAsync(id, title);
        return Ok();
    }
    
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCourse(long id)
    {
        await _service.DeleteCourseAsync(id);
        return NoContent();
    }

    private CourseResponse ConvertResponse(Course course)
    {
        /* TODO:
         * Since `course.Semester.Id` required, Semester must be loaded eagerly at service,
         * within any function that returns to the client.
         */
        return new CourseResponse(course.Semester.Id, course.Id, course.Title);
    }
}