using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Common.Entities;
using Catering.Common.Interfaces;

namespace Catering.Business.Strategy
{
    public class Engine : ICateringStrategy
    {
        Single[] _weekdayLunchHours = new Single[] { 11f, 11.5f, 12f, 12.5f };
        Single[] _weekendLunchHours = new Single[] { 10.5f, 11f, 11.5f, 12f, 12.5f, 13f, 13.5f };


        public bool ShouldMeetingBeCatered(DateTime startDateTime, Single meetingLengthHours)
        {
            DateTime endDateTime = startDateTime.AddHours(meetingLengthHours);

            var dow = startDateTime.Date.DayOfWeek;
            var isWeekend = (dow == DayOfWeek.Saturday || dow == DayOfWeek.Sunday);

            var mtgHours = new List<Single>();
            Single startHour = startDateTime.Hour + (startDateTime.Minute / 60);
            Single endHour = endDateTime.Hour + (endDateTime.Minute / 60);
            for (Single i = startHour; i < endHour; i = i + 0.5f)
                mtgHours.Add(i);

            var isDuringWeekdayLunch = _weekdayLunchHours.Intersect(mtgHours).Any();
            var isDuringWeekendLunch = _weekendLunchHours.Intersect(mtgHours).Any();

            bool isDuringLunch = (isDuringWeekdayLunch || (isWeekend && isDuringWeekendLunch));
            return (isDuringLunch && meetingLengthHours > 1.0);
        }
    }
}
