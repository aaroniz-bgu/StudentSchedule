using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSchedule.API.Domain.Models;

namespace StudentSchedule.API.Data.Configuration;

public class TaskConfiguration : IEntityTypeConfiguration<CourseTask>
{
    public void Configure(EntityTypeBuilder<CourseTask> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(t => t.Title).IsRequired();
        builder.Property(t => t.Description).IsRequired();
        builder.Property(t => t.DueDate).IsRequired();
        builder.Property(t => t.Type).IsRequired();
        builder.Property(t => t.Progress).IsRequired();
    }
}