using System;
using System.Collections.Generic;

namespace Catering.Common.Interfaces
{
    public interface IMeetingReadRepository
    {
        IEnumerable<Entities.Meeting> GetMeetings(DateTime start, DateTime end);
    }
}
