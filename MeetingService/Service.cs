using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingService
{
    public class Service
    {
        const double _averageMeetingStartsPerDay = 1.5;
        string[] _locations = new string[] { "Phoenix AZ", "Tucson AZ", "Dallas TX", "Houston TX", "New Orleans LA", "Miami FL", "New York, NY", "Albany NY" };

        public IEnumerable<Meeting> GetMeetings(DateTime start, DateTime end)
        {
            return GenerateData(start, end);
        }

        private IEnumerable<Meeting> GenerateData(DateTime start, DateTime end)
        {
            var rnd = new Random();
            var result = new List<Meeting>();

            var nDays = end.Subtract(start).TotalDays;
            for (int i = 0; i <= nDays; i++)
            {
                var startCount = rnd.Next(2, 4);
                for (int j = 0; j < startCount; j++)
                {
                    result.Add(new Meeting()
                    {
                        StartDay = i + 1,
                        NumberOfDays = rnd.Next(1, 4),
                        StartHour = rnd.Next(9, 15),
                        LengthHours = rnd.Next(1, 5),
                        Location = _locations[rnd.Next(_locations.Length)]
                    });
                }
            }

            return result;
        }

    }
}
