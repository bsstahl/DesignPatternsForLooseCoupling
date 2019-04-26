using System;
using System.Collections.Generic;
using Catering.Common.Entities;
using Catering.Common.Interfaces;

namespace Catering.Business
{
    public static class MeetingExtensions
    {
        public static CateringEvent AsCateringEvent(this Meeting meeting, int yearNumber, int monthNumber)
        {
            return new CateringEvent()
            {
                CateringDate = new DateTime(yearNumber, monthNumber, meeting.StartDate.Day),
                City = meeting.Location
            };
        }

        public static IEnumerable<CateringEvent> SelectCateringEvents(this IEnumerable<Meeting> meetings, ICateringStrategy strategy, DateTime start)
        {
            var results = new List<CateringEvent>();
            foreach (var meeting in meetings)
            {
                for (int i = 0; i < meeting.NumberOfDays; i++)
                {
                    var startDateTime = new DateTime(start.Year, start.Month, meeting.StartDate.Day)
                        .AddDays(i)
                        .AddHours(meeting.StartHour);

                    if (strategy.ShouldMeetingBeCatered(startDateTime, meeting.LengthHours))
                        results.Add(meeting.AsCateringEvent(start.Year, start.Month));
                }
            }

            return results;
        }
    }
}
