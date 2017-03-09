using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingService
{
    public class Meeting
    {
        public DateTime StartDate { get; set; }
        public int NumberOfDays { get; set; }
        public Single StartHour { get; set; }
        public Single LengthHours { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"{this.StartDate.Day},{this.NumberOfDays},{this.StartHour},{this.LengthHours},{this.Location}";
        }
    }
}
