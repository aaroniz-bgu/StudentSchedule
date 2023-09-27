using Microsoft.AspNetCore.Mvc;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Services.IServices;
using StudentSchedule.Contracts.Requests;

namespace StudentSchedule.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SemesterController : ControllerBase
{
    private const long CreationalRequestId = -1;
    
    private readonly ISemesterService _semesterService;
    
    public SemesterController(ISemesterService semesterService)
    {
        _semesterService = semesterService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetSemesters()
    {
        var semesters = await _semesterService.GetSemestersAsync();
        return Ok(semesters);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetSemester(int id)
    {
        var semester = await _semesterService.GetSemesterAsync(id);
        return Ok(semester);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddSemester(SemesterRequest request)
    {
        if(request.Id != CreationalRequestId) BadRequest("Id should be -1 for a create request.");
        
        var semester = await _semesterService.AddSemesterAsync(request.Title, request.StartDate, request.EndDate);
        
        return CreatedAtAction(nameof(GetSemester), new { id = semester.Id }, semester);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateSemester(SemesterRequest request)
    {
        var semester = ConvertRequest(request);
        await _semesterService.UpdateSemesterAsync(semester);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteSemester(long id)
    {
        await _semesterService.DeleteSemesterAsync(id);
        return NoContent();
    }
    
    //TODO: Replace with designated mapper
    public Semester ConvertRequest(SemesterRequest request) => new Semester(request.Id, request.Title, request.StartDate, request.EndDate);
}