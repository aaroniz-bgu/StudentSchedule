namespace StudentSchedule.Contracts.Responses;

public record SemesterResponse (long Id, string Title, DateTime StartDate, DateTime EndDate);