using Microsoft.EntityFrameworkCore;
using StudentSchedule.API.Data;
using StudentSchedule.API.Domain.Models;
using StudentSchedule.API.Exception;
using StudentSchedule.API.Services.IServices;

namespace StudentSchedule.API.Services;

public class SemesterService : ISemesterService
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

    public async Task<Semester> AddSemesterAsync(string title, DateTime startDate, DateTime endDate)
    {
        if (String.IsNullOrEmpty(title)) 
            throw new ArgumentException("Title cannot be null or empty.");
        if (startDate == null || endDate == null)
            throw new ArgumentException("Neither starting nor ending date are allowed to be null."); 
        if (startDate > endDate) 
            throw new ArgumentException("Starting date cannot be after ending date.");
        
        var semester = new Semester(title, startDate, endDate);
        
        var addTask = await _context.Semesters.AddAsync(semester); // We want to keep track of the entity so we can return it with it's Id.
        await _context.SaveChangesAsync();
        
        return addTask.Entity;
    }

    public async Task UpdateSemesterAsync(Semester semester)
    {
        _context.Semesters.Update(semester);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSemesterAsync(long id)
    {
        var semester = await GetSemesterAsync(id);
        _context.Semesters.Remove(semester);
        await _context.SaveChangesAsync();
    }
}