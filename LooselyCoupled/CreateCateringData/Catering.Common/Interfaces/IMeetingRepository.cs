using System;
using System.Collections.Generic;

namespace Catering.Common.Interfaces
{
    public interface IMeetingRepository
    {
        IEnumerable<Entities.Meeting> GetMeetings(DateTime start, DateTime end);
    }
}
