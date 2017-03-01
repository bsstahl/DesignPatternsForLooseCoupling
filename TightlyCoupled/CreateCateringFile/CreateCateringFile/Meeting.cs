using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCateringFile
{
    internal class Meeting
    {
        List<MeetingDay> _meetingDays = new List<MeetingDay>();

        internal Meeting(string sourceFileRow, DateTime firstDayOfMonth)
        {
            Parse(sourceFileRow, firstDayOfMonth);
        }

        internal int StartDay { get; set; }
        internal int DayCount { get; set; }
        internal Single StartHour { get; set; }
        internal Single Length { get; set; }
        internal string Location { get; set; }

        internal IEnumerable<MeetingDay> MeetingDays
        {
            get { return _meetingDays; }
        }

        internal void WriteCateringOutput(System.IO.StreamWriter outputWriter)
        {
            foreach (var meetingDate in _meetingDays)
                if (meetingDate.IsCatered)
                    outputWriter.WriteLine($"{meetingDate.StartDateTime.ToString("d")},{this.Location}");
        }

        private void Parse(string sourceFileRow, DateTime firstDayOfMonth)
        {
            var items = sourceFileRow.Split(',');
            this.StartDay = Int32.Parse(items[0]);
            this.DayCount = Int32.Parse(items[1]);
            this.StartHour = Single.Parse(items[2]);
            this.Length = Single.Parse(items[3]);
            this.Location = items[4];

            for (int i = 0; i < this.DayCount; i++)
            {
                var startDateTime = firstDayOfMonth.AddDays(i + this.StartDay - 1).Date.AddHours(this.StartHour);
                var endDateTime = startDateTime.AddHours(this.Length);
                _meetingDays.Add(new MeetingDay(startDateTime, endDateTime));
            }
        }
    }
}
