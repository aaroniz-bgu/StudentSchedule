namespace StudentSchedule.API.Domain.Models;

public class Course
{
    private long _id;
    private List<Exam> _exams;
    private List<Lesson> _lessons;
    private List<CourseTask> _tasks;
    
    public long Id
    {
        get => _id;
        private set => _id = value;
    }
    public IReadOnlyList<Exam> Exams
    {
        get => _exams; 
        private set => _exams = value.ToList();
    }
    public IReadOnlyList<Lesson> Lessons
    {
        get => _lessons;
        private set => _lessons = value.ToList();
    }
    public IReadOnlyList<CourseTask> Tasks
    {
        get => _tasks;
        private set => _tasks = value.ToList();
    }
    
    public string Name { get; set; }
    public Semester Semester { get; private set; }
    
    public Course(long id, string name, Semester semester)
    {
        Id = id;
        Name = name;
        Semester = semester;
    }
    
    public Course(string name, Semester semester)
    {
        Name = name;
        Semester = semester;
    }
    
    public void AddExam(Exam exam)
    {
        _exams.Add(exam);
    }
    
    public void AddLesson(Lesson lesson)
    {
        _lessons.Add(lesson);
    }
    
    public void AddTask(CourseTask task)
    {
        _tasks.Add(task);
    }
    
    public bool RemoveExam(Exam exam)
    {
        return _exams.Remove(exam);
    }
    
    public bool RemoveLesson(Lesson lesson)
    {
        return _lessons.Remove(lesson);
    }
    
    public bool RemoveTask(CourseTask task)
    {
        return _tasks.Remove(task);
    }
}