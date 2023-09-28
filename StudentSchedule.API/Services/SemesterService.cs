using Microsoft.EntityFrameworkCore;
using StudentSchedule.API.Data;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Exception;
using StudentSchedule.API.Services.IServices;

namespace StudentSchedule.API.Services;
//TODO-> This service doesn't need the gatherer but the gatherer needs it. Look into it.
public class SemesterService : AppService, ISemesterService
{
    private readonly AppDbContext _context;
    
    public SemesterService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Semester>> GetSemestersAsync()
    {
        var list = await _context.Semesters.AsNoTracking().ToListAsync();
        
        return list;
    }

    public async Task<Semester> GetSemesterAsync(long id)
    {
        var semester = await _context.Semesters.FindAsync(id);
        
        return semester ?? throw new NotFoundException($"Semester with id {id} was not found.");
    }
    
    public async Task<Semester> GetSemesterEagerlyAsync(long id)
    {
        var semester = await _context.Semesters
            .Include(s => s.Courses)
            .FirstOrDefaultAsync(s => s.Id == id);
        
        return semester ?? throw new NotFoundException($"Semester with id {id} was not found.");
    }

    public async Task<Semester> AddSemesterAsync(string title, DateTime startDate, DateTime endDate)
    {
        IsValidRequest(title, startDate, endDate);
        
        var semester = new Semester(title, startDate, endDate);
        
        var addTask = await _context.Semesters.AddAsync(semester); // We want to keep track of the entity so we can return it with it's Id.
        await _context.SaveChangesAsync();
        
        return addTask.Entity;
    }

    public async Task UpdateSemesterAsync(Semester updated)
    {
        IsValidRequest(updated);
        
        var semester = await GetSemesterEagerlyAsync(updated.Id);
        
        semester.Title = updated.Title;
        semester.StartDate = updated.StartDate;
        semester.EndDate = updated.EndDate;
        
        _context.Semesters.Update(semester);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSemesterAsync(long id)
    {
        var semester = await GetSemesterAsync(id);
        _context.Semesters.Remove(semester);
        await _context.SaveChangesAsync();
    } 
    
    /// <summary>
    /// Checks if the request is valid.
    /// </summary>
    /// <param name="title">The title of the request. Cannot be null/empty.</param>
    /// <param name="startDate">The starting date of the request. Cannot be later than <paramref name="endDate"/>/null.</param>
    /// <param name="endDate">The ending date of the request. Cannot be sooner than <paramref name="startDate"/>/null.</param>
    /// <exception cref="ArgumentException">Thrown when the request parameters are not valid.</exception>
    private void IsValidRequest(string title, DateTime startDate, DateTime endDate) 
    {
        if (string.IsNullOrEmpty(title)) 
            throw new ArgumentException("Title cannot be null or empty.");
        if (startDate == null || endDate == null)
            throw new ArgumentException("Neither starting nor ending date are allowed to be null."); 
        if (startDate > endDate) 
            throw new ArgumentException("Starting date cannot be after ending date.");
    }
    
    /// <summary>
    /// Checks if the request represented by a Semester object is valid.
    /// </summary>
    /// <param name="s">The Semester object representing the request.</param>
    private void IsValidRequest(Semester s) => IsValidRequest(s.Title, s.StartDate, s.EndDate);
}

/*
 * Would automatically traverse the relationship tree"
 * `Select(x => { Prop1 = x.Child.DeepChild.DeeperChild.DeeperChildProp });`
 */