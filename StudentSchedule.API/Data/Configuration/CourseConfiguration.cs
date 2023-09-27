using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSchedule.API.Domain.Models;

namespace StudentSchedule.API.Data.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder
            .HasMany(e => e.Tasks)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasMany(e => e.Lessons)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasMany(e => e.Exams)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.Title).IsRequired();
    }
}