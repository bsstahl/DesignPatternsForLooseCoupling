using Catering.Common.Interfaces;
using Catering.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Catering.Business
{
    public class Engine
    {
        readonly IServiceProvider _serviceProvider;
        public Engine(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateData()
        {
            #region Calculate start and end dates of next month

            var dataDate = DateTime.Now.AddMonths(1);
            var start = new DateTime(dataDate.Year, dataDate.Month, 1);
            var end = start.AddMonths(1).AddDays(-1);

            #endregion

            #region Retrieve the data from the repository

            IMeetingRepository repo = _serviceProvider.GetService<IMeetingRepository>();
            var meetings = repo.GetMeetings(start, end);

            #endregion

            #region Determine if catering is required for any day in any meeting

            var strategy = _serviceProvider.GetService<ICateringStrategy>();
            var results = new List<CateringEvent>();
            foreach (var meeting in meetings)
            {
                for (int i = 0; i < meeting.NumberOfDays; i++)
                {
                    var startDateTime = new DateTime(start.Year, start.Month, meeting.StartDay)
                        .AddDays(i)
                        .AddHours(meeting.StartHour);

                    if (strategy.ShouldMeetingBeCatered(startDateTime, meeting.LengthHours))
                        results.Add(meeting.AsCateringEvent(start.Year, start.Month));
                }
            }

            #endregion

            #region TODO: Output results to Catering Repository

            // Your mission, should you choose to accept it, is to continue the process
            // of refactoring this application by implementing an output repository.
            // I recommend starting by simply using the file system and creating a file output
            // that matches the output of the original tightly-coupled application.  If you are
            // then feeling ambitious, you could create additional repositories that output the
            // data to a database, an XML or JSON file, or even to Twitter if you feel the need.

            #endregion
        }
    }
}
