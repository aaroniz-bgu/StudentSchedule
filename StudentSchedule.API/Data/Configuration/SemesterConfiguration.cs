using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSchedule.API.Domain.Models;

namespace StudentSchedule.API.Data.Configuration;

public class SemesterConfiguration : IEntityTypeConfiguration<Semester>
{
    public void Configure(EntityTypeBuilder<Semester> builder)
    {
        builder
            .HasMany(s => s.Courses)
            .WithOne(c => c.Semester)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(s => s.Id)
            .IsRequired();

        builder.HasKey(x => x.Id);
        
        builder
            .Property(x=>x.Id)
            .IsRequired()
            .IsUnicode()
            .ValueGeneratedOnAdd();
        builder
            .Property(x => x.Title)
            .IsRequired();
        builder
            .Property(x => x.StartDate)
            .IsRequired();
        builder
            .Property(x => x.EndDate)
            .IsRequired();
    }
}