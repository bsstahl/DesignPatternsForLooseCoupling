using System;
using System.Collections.Generic;
using Catering.Common.Entities;
using Catering.Common.Interfaces;

namespace Catering.Data.MeetingServiceClient
{
    public class Repository : IMeetingRepository
    {
        public IEnumerable<Meeting> GetMeetings(DateTime start, DateTime end)
        {
            var svc = new MeetingService.Service();
            var meetings = svc.GetMeetings(start, end);
            return meetings.AsEntityCollection();
        }
    }
}
