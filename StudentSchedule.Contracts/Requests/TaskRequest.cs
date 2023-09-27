namespace StudentSchedule.Contracts.Requests;

public record TaskRequest(
    long CourseId,
    long Id, 
    int Type,
    string Title,
    string Description,
    DateTime DueDate
    );