namespace StudentSchedule.API.Domain.Models;

public class Semester
{
    private List<Course> _courses; //One to many
    
    public long Id { get; private set; }

    public IReadOnlyList<Course> Courses
    {
        get => _courses;
        private set => _courses = value.ToList();
    }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">The semester's ID.</param>
    /// <param name="title">Semester's title</param>
    /// <param name="startDate">Starting date of the semester.</param>
    /// <param name="endDate">End date of the semester.</param>
    public Semester(long id, string title, DateTime startDate, DateTime endDate)
    {
        Id = id;
        Title = title;
        
        StartDate = startDate;
        EndDate = endDate;
        
        _courses = new List<Course>();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="title">Semester's title.</param>
    /// <param name="startDate">Starting date of the semester.</param>
    /// <param name="endDate">Ending date of the semester.</param>
    public Semester(string title, DateTime startDate, DateTime endDate)
    {
        Title = title;
        
        StartDate = startDate;
        EndDate = endDate;
        
        _courses = new List<Course>();
    }
    
    /// <summary>
    /// Adds a course to the semester.
    /// </summary>
    /// <param name="course">The course to be added.</param>
    /// <exception cref="ArgumentException">If the course already exists in this semester.</exception>
    public void AddCourse(Course course)
    {
        if (_courses.Contains(course)) throw new ArgumentException("Course already exists in semester.");
        
        _courses.Add(course);
    }
    
    /// <summary>
    /// Removes a course from the semester.
    /// </summary>
    /// <param name="course">The course to be removed.</param>
    public void RemoveCourse(Course course)
    {
        _courses.Remove(course);
    }
}