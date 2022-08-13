using Catering.Common.Entities;
using Catering.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catering.Business
{
    public static class MeetingExtensions
    {
        public static CateringEvent AsCateringEvent(this Meeting meeting, int dayIndex)
        {
            return new CateringEvent()
            {
                CateringDate = meeting.StartDate.Date.AddDays(dayIndex),
                City = meeting.Location
            };
        }

        public static IEnumerable<CateringEvent> SelectCateringEvents(this IEnumerable<Meeting> meetings, ICateringStrategy strategy)
        {
            var results = new List<CateringEvent>();
            foreach (var meeting in meetings)
            {
                for (int i = 0; i < meeting.NumberOfDays; i++)
                {
                    var startDateTime = meeting.StartDate.Date
                        .AddDays(i)
                        .AddHours(meeting.StartHour);

                    if (strategy.ShouldMeetingBeCatered(startDateTime, meeting.LengthHours))
                        results.Add(meeting.AsCateringEvent(i));
                }
            }

            return results;
        }
    }
}
