using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Common.Interfaces
{
    public interface IMeetingRepository
    {
        IEnumerable<Entities.Meeting> GetMeetings(DateTime start, DateTime end);
    }
}
