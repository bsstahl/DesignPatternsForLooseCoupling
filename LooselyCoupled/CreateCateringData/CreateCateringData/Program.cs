using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Common.Interfaces;

namespace CreateCateringData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1 -- Get Data

            // Calculate start and end dates of next month
            var dataDate = DateTime.Now.AddMonths(1);
            var start = new DateTime(dataDate.Year, dataDate.Month, 1);
            var end = start.AddMonths(1).AddDays(-1);

            // retrieve the data from the repository
            IMeetingRepository repo = new Catering.Data.MeetingServiceClient.Repository();
            var meetings = repo.GetMeetings(start, end);

        }
    }
}
