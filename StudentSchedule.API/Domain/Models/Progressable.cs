namespace StudentSchedule.API.Domain.Models;

public abstract class Progressable
{
    private const int DefaultMaxProgress = 100;
    public int Progress { get; internal set; } = 0;
    //Do not add a setter yet, if you do configure that for the context.
    public int MaxProgress { get; } = DefaultMaxProgress;
    public bool IsCompleted => Progress == MaxProgress;
}