using Microsoft.EntityFrameworkCore;
using StudentSchedule.API.Domain.Models;

namespace StudentSchedule.API.Data;
/// <summary>
/// The context isn't abstracted away nor wrapped inside a repository for several design reasons.
/// It is possible and can be done quickly, but it is not recommended.
/// See also:
/// 1. https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-7.0#definition
/// 2. https://www.reddit.com/r/dotnet/comments/16obtab/usage_of_uow_with_repository_pattern_and_dbcontext/
/// 3. https://stackoverflow.com/q/13180501/19275130
/// </summary>
public sealed class AppDbContext : DbContext
{
    
    //TODO add all the DbSets
    public DbSet<Semester> Semesters { get; private set; }
    public DbSet<Course> Courses { get; private set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //Hey hey TODO add all the ensure created etc...
        //Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}