using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCateringFile
{
    internal class MeetingDay
    {
        Single[] _lunchHours = new Single[] { 11f, 11.5f, 12f, 12.5f };
        Single[] _weekendLunchHours = new Single[] { 10.5f, 11f, 11.5f, 12f, 12.5f, 13f, 13.5f };

        internal DateTime StartDateTime { get; private set; }
        internal DateTime EndDateTime { get; private set; }
        internal Double TotalTime { get; private set; }

        internal bool IsWeekend { get; private set; }
        internal bool IsDuringLunch { get; private set; }
        internal bool IsCatered { get; private set; }
        
        internal MeetingDay(DateTime start, DateTime end)
        {
            this.StartDateTime = start;
            this.EndDateTime = end;
            this.TotalTime = EndDateTime.Subtract(StartDateTime).TotalHours;

            var dow = this.StartDateTime.Date.DayOfWeek;
            this.IsWeekend = (dow == DayOfWeek.Saturday || dow == DayOfWeek.Sunday);

            var mtgHours = new List<Single>();
            Single startHour = this.StartDateTime.Hour + (this.StartDateTime.Minute / 60);
            Single endHour = this.EndDateTime.Hour + (this.EndDateTime.Minute / 60);

            for (Single i = startHour; i < endHour; i = i + 0.5f)
                mtgHours.Add(i);

            var isDuringLunch = _lunchHours.Intersect(mtgHours).Any();
            var isDuringWeekendLunch = _weekendLunchHours.Intersect(mtgHours).Any();
            if (this.IsWeekend)
                this.IsDuringLunch = isDuringWeekendLunch;
            else
                this.IsDuringLunch = isDuringLunch;

            this.IsCatered = (this.IsDuringLunch && this.TotalTime > 1.0);
        }
    }
}
