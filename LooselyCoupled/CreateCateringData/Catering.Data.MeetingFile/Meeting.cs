using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.MeetingFile
{
    public class Meeting : Catering.Common.Entities.Meeting
    {
        public Meeting(string dataRow, DateTime firstDayOfMonth)
        {
            Load(dataRow, firstDayOfMonth);
        }

        private void Load(string dataRow, DateTime firstDayOfMonth)
        {
            var items = dataRow.Split(',');
            this.StartDay = Int32.Parse(items[0]);
            this.NumberOfDays = Int32.Parse(items[1]);
            this.StartHour = Single.Parse(items[2]);
            this.LengthHours = Single.Parse(items[3]);
            this.Location = items[4];

            for (int i = 0; i < this.NumberOfDays; i++)
            {
                var startDateTime = firstDayOfMonth.AddDays(i + this.StartDay - 1).Date.AddHours(this.StartHour);
                var endDateTime = startDateTime.AddHours(this.LengthHours);
            }
        }
    }
}
