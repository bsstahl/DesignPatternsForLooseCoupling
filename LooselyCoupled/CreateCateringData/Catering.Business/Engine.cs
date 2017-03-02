using System;
using Catering.Common.Extensions;
using Catering.Common.Interfaces;

namespace Catering.Business
{
    public class Engine
    {
        public void CreateData()
        {
            // Calculate start and end dates of next month
            var start = DateTime.Now.FirstDayOfNextMonth();
            var end = DateTime.Now.LastDayOfNextMonth();

            // Retrieve the data from the repository
            IMeetingRepository repo = new Catering.Data.MeetingServiceClient.Repository();
            var meetings = repo.GetMeetings(start, end);

            // Determine if catering is required for any day in any meeting
            ICateringStrategy strategy = new Catering.Business.Strategy.Engine();
            var cateringEvents = meetings.SelectCateringEvents(strategy, start);

            // Output results to Catering Repository
            #region Mission
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
