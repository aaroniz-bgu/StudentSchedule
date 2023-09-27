namespace StudentSchedule.API.Domain.Models;

public class CourseTask : Progressable
{
    public long Id { get; private set; }
    public TaskType Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; } //TODO Check legality of changing DueDate in service.
    public Course Course { get; private set; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">Course's identifier key.</param>
    /// <param name="title">Course's title, cannot be null or empty.</param>
    /// <param name="description">Course's description, cannot be null or empty.</param>
    /// <param name="dueDate">Task's deadline.</param>
    /// <param name="type">Look at TaskType enum for more details.<seealso cref="TaskType"/></param>
    /// <param name="course">The course that this task was given at.</param>
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
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">Course's identifier key.</param>
    /// <param name="title">Course's title, cannot be null or empty.</param>
    /// <param name="description">Course's description, cannot be null or empty.</param>
    /// <param name="dueDate">Task's deadline.</param>
    /// <param name="type">Look at TaskType enum for more details.<seealso cref="TaskType"/></param>
    public CourseTask(
        long id,
        string title, string description, 
        DateTime dueDate, 
        TaskType type)
    {
        Id = id;
        
        Title = title;
        Description = description;
        
        DueDate = dueDate;
        
        Course = null;
        Type = type;
    }
    
    /// <summary></summary>
    /// <param name="title">Course's title, cannot be null or empty.</param>
    /// <param name="description">Course's description, cannot be null or empty.</param>
    /// <param name="dueDate">Task's deadline.</param>
    /// <param name="type">Look at TaskType enum for more details.<seealso cref="TaskType"/></param>
    /// <param name="course">The course that this task was given at.</param>
    public CourseTask(
        string title, string description, 
        DateTime dueDate, 
        TaskType type, Course course)
    {
        Title = title;
        Description = description;
        
        DueDate = dueDate;
        
        Course = course;
        Type = type;
    }
}