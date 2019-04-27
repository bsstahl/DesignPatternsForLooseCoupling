using System;

namespace Catering.Common.Interfaces
{
    public interface ICateringStrategy
    {
        bool ShouldMeetingBeCatered(DateTime startDateTime, Single meetingLengthHours);
    }
}
