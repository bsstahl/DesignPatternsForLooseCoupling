using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Common.Interfaces
{
    public interface ICateringStrategy
    {
        bool ShouldMeetingBeCatered(DateTime startDateTime, Single meetingLengthHours);
    }
}
