namespace StudentSchedule.API.Domain.Models;

public abstract class Progressable
{
    private int _progress = 0;
    public int Progress
    {
        get => _progress;
        protected set
        {
            if (value > MaxProgress || value < 0) throw new ArgumentException("Progress cannot be greater than MaxProgress");
            
            _progress = value;
        }
    }
    protected const int DefaultMaxProgress = 100;
    protected int MaxProgress { get; } = DefaultMaxProgress;
    public bool IsCompleted => Progress == MaxProgress;
}