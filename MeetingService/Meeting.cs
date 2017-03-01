using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingService
{
    public class Meeting
    {
        public int StartDay { get; set; }
        public int NumberOfDays { get; set; }
        public Single StartHour { get; set; }
        public Single LengthHours { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"{this.StartDay},{this.NumberOfDays},{this.StartHour},{this.LengthHours},{this.Location}";
        }
    }
}
