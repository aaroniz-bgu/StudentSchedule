namespace StudentSchedule.API.Domain.Models;

public class Exam
{
    public long Id { get; private set; }
    public Course Course { get; private set; }
    private string Description { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public string Building { get; set; }
    public string Room { get; set; }
    public string Seat { get; set; }

    public Exam(
        long id,
        Course course,
        string description,
        DateTime date, int duration,
        string building, string room, string seat)
    {
        Id = id;
        Course = course;
        Description = description;
        
        Date = date;
        Duration = duration;
        
        Building = building;
        Room = room;
        Seat = seat;
    }
}