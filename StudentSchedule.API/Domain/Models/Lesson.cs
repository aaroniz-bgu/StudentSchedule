namespace StudentSchedule.API.Domain.Models;

public class Lesson
{
    private bool _reoccurring = true;
    
    public long Id { get; private set; }
    public Course Course { get; private set; }
    public string Teacher { get; set; }
    public string Module { get; set; }
    public string Building { get; set; }
    public string Room { get; set; }
    public bool Reoccurring { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    
    public Lesson(
        long id,
        Course course,
        string teacher, string module,
        string building, string room,
        bool reoccurring, DateTime start, DateTime end)
    {
        Id = id;
        Course = course;
        
        Teacher = teacher;
        Module = module;
        
        Building = building;
        Room = room;
        
        //checked in the service, no logic here.
        Reoccurring = reoccurring;
        Start = start;
        End = end;
    }
    
    //EF wants.... "EF GETS!", you damn right! Ef gets.
    public Lesson(
        long id,
        string teacher, string module,
        string building, string room,
        bool reoccurring, DateTime start, DateTime end)
    {
        Id = id;
        
        Teacher = teacher;
        Module = module;
        
        Building = building;
        Room = room;
        
        //checked in the service, no logic here.
        Reoccurring = reoccurring;
        Start = start;
        End = end;
    }
}