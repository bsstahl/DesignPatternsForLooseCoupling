using Catering.Common.Extensions;
using Catering.Common.Interfaces;
using System;

namespace Catering.Business;

public class Engine: IOrchestrationEngine
{
    readonly IMeetingReadRepository _meetingRepo;
    readonly ICateringStrategy _strategy;
    readonly ICateringEventWriteRepository _cateringEventRepo;

    public Engine(IMeetingReadRepository meetingRepo, ICateringStrategy strategy, ICateringEventWriteRepository cateringEventRepo)
    {
        _meetingRepo = meetingRepo;
        _strategy = strategy;
        _cateringEventRepo = cateringEventRepo;
    }

    public void CreateData()
    {
        // Calculate start and end dates of next month
        var start = DateTime.Now.FirstDayOfNextMonth();
        var end = DateTime.Now.LastDayOfNextMonth();

        // Retrieve the data from the repository
        var meetings = _meetingRepo.GetMeetings(start, end);

        // Determine if catering is required for any day in any meeting
        var cateringEvents = meetings.SelectCateringEvents(_strategy);

        // Output results to Catering Repository
        _cateringEventRepo.WriteCateringEvents(cateringEvents);
    }
}
