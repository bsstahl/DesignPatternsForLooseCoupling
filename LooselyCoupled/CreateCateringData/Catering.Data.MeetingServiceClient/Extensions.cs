using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Common.Entities;

namespace Catering.Data.MeetingServiceClient
{
    public static class Extensions
    {
        public static Meeting AsEntity(this MeetingService.Meeting meeting)
        {
            return new Meeting()
            {
                StartDay = meeting.StartDay,
                NumberOfDays = meeting.NumberOfDays,
                StartHour = meeting.StartHour,
                LengthHours = meeting.LengthHours,
                Location = meeting.Location
            };
        }

        public static IEnumerable<Meeting> AsEntityCollection(this IEnumerable<MeetingService.Meeting> meetings)
        {
            var result = new List<Meeting>();
            foreach (var meeting in meetings)
                result.Add(meeting.AsEntity());
            return result;
        }
    }
}
