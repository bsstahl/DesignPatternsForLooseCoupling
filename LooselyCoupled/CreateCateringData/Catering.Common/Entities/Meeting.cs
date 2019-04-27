using System;

namespace Catering.Common.Entities
{
    public class Meeting
    {
        public DateTime StartDate { get; set; }
        public int NumberOfDays { get; set; }
        public Single StartHour { get; set; }
        public Single LengthHours { get; set; }
        public string Location { get; set; }
    }
}
