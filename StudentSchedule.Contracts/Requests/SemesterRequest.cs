namespace StudentSchedule.Contracts.Requests;

/// <summary>
/// Request entity when engaging with the API regarding a semester.
/// </summary>
/// <param name="id">The identifier of a semester, should be -1 if it is a create request.</param>
/// <param name="Title">Descriptive title of the semester.</param>
/// <param name="StartDate">The stating date of the semester.</param>
/// <param name="EndDate">The ending date of the semester.</param>
public record SemesterRequest(long Id, string Title, DateTime StartDate, DateTime EndDate);