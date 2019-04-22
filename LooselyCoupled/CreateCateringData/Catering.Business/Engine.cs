using System;
using Catering.Common.Extensions;
using Catering.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Catering.Common.Entities;

namespace Catering.Business
{
    public class Engine
    {
        public Engine()
        {
        }

        public void CreateData()
        {
            // Calculate start and end dates of next month
            var start = DateTime.Now.FirstDayOfNextMonth();
            var end = DateTime.Now.LastDayOfNextMonth();
            
            // Retrieve the data from the repository
            var repo = new Catering.Data.MeetingFile.Repository(@"..\..\..\..\..\data\April2017.csv");
            var meetings = repo.GetMeetings(start, end);

            // TODO: Determine if catering is required for any day in any meeting


            // TODO: Output results to Catering Repository
        }
    }
}
