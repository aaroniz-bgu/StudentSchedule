using Microsoft.AspNetCore.Mvc;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Services.IServices;
using StudentSchedule.Contracts.Requests;
using StudentSchedule.Contracts.Responses;

namespace StudentSchedule.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SemesterController : ControllerBase
{
    private const long CreationalRequestId = -1;
    
    private readonly ISemesterService _service;
    
    public SemesterController(ISemesterService service)
    {
        _service = service;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetSemesters()
    {
        var semesters = await _service.GetSemestersAsync();
        var response = semesters.Select(ConvertResponse).ToList();
        return Ok(response);
    }
    
    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetSemester(int id)
    {
        var semester = await _service.GetSemesterAsync(id);
        var response = ConvertResponse(semester);
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddSemester(SemesterRequest request)
    {
        if(request.Id != CreationalRequestId)
        {
            return BadRequest("Id must be -1 for a create request.");
        }
        
        var semester = await _service.AddSemesterAsync(request.Title, request.StartDate, request.EndDate);
        var response = ConvertResponse(semester);
        return CreatedAtAction(nameof(GetSemester), new { id = semester.Id }, response);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateSemester(SemesterRequest request)
    {
        var semester = ConvertRequest(request);
        await _service.UpdateSemesterAsync(semester);
        return Ok();
    }
    
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteSemester(long id)
    {
        await _service.DeleteSemesterAsync(id);
        return NoContent();
    }
    
    //TODO: Replace with designated mapper
    private Semester ConvertRequest(SemesterRequest request)
    {
        return new Semester(request.Id, request.Title, request.StartDate, request.EndDate);
    }
    private SemesterResponse ConvertResponse(Semester semester)
    {
        return new SemesterResponse(semester.Id, semester.Title, semester.StartDate, semester.EndDate);
    }
}