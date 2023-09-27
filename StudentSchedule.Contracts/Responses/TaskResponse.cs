namespace StudentSchedule.Contracts.Responses;

public record TaskResponse(
    long CourseId,
    long Id, 
    int Type,
    string Title,
    string Description,
    DateTime DueDate,
    int Progress);