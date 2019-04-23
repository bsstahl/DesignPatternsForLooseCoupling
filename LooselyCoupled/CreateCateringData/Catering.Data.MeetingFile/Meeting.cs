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
            var startDay = Int32.Parse(items[0]);

            this.StartDate = firstDayOfMonth.AddDays(startDay - 1).Date;
            this.NumberOfDays = Int32.Parse(items[1]);
            this.StartHour = Single.Parse(items[2]);
            this.LengthHours = Single.Parse(items[3]);
            this.Location = items[4];
        }

        public DateTime StartDateTime
        {
            get => this.StartDate.AddHours(this.StartHour);
        }
    }
}
