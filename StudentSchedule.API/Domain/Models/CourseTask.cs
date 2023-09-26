namespace StudentSchedule.API.Domain.Models;

public class CourseTask : Progressable
{
    public long Id { get; private set; }
    public TaskType Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; } //TODO Check legality of changing DueDate in service.
    public Course Course { get; private set; }
    
    public CourseTask(
        long id,
        string title, string description, 
        DateTime dueDate, 
        TaskType type, Course course)
    {
        Id = id;
        
        Title = title;
        Description = description;
        
        DueDate = dueDate;
        
        Course = course;
        Type = type;
    }
}