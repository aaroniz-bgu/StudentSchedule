using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSchedule.API.Domain.Models;

namespace StudentSchedule.API.Data.Configuration;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(e => e.Description).IsRequired();
        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.Duration).IsRequired();
        builder.Property(e => e.Building).IsRequired();
        builder.Property(e => e.Room).IsRequired();
        builder.Property(e => e.Seat).IsRequired();
    }
}