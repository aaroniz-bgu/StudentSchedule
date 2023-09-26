namespace StudentSchedule.API.Domain.Models;

public class Assignment : Progressable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; } //TODO Check legality of changing DueDate in service.
    public Course Course { get; private set; }
    
    /// <summary>
    /// Default constructor of Assignment.
    /// </summary>
    /// <param name="title">Assignment's title.</param>
    /// <param name="description">Assignment's description.</param>
    /// <param name="dueDate">Due date of submission.</param>
    /// <param name="course">Course.</param>
    public Assignment(string title, string description, DateTime dueDate, Course course)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Course = course;
    }
}