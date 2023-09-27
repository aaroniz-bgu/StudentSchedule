using StudentSchedule.API.Domain.Models;

namespace StudentSchedule.API.Services.IServices;

public interface ISemesterService
{
    Task<List<Semester>> GetSemestersAsync();
    Task<Semester> GetSemesterAsync(long id);
    Task<Semester> AddSemesterAsync(string title, DateTime startDate, DateTime endDate);
    Task UpdateSemesterAsync(Semester semester);
    Task DeleteSemesterAsync(long id);
}