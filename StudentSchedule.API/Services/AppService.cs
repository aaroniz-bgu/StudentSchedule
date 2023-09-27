using StudentSchedule.API.Services.IServices;

namespace StudentSchedule.API.Services;

public class AppService : IAppService
{
    protected IServiceGatherer _gatherer { get; private set; }

    public void AddGatherer(IServiceGatherer gatherer)
    {
        _gatherer = gatherer;
    }
}