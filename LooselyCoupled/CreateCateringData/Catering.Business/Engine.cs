using Catering.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Framework.DependencyInjection;

namespace Catering.Business
{
    public class Engine
    {
        IServiceProvider _serviceProvider;
        public Engine(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateData()
        {
            // Step 1 -- Get Data

            // Calculate start and end dates of next month
            var dataDate = DateTime.Now.AddMonths(1);
            var start = new DateTime(dataDate.Year, dataDate.Month, 1);
            var end = start.AddMonths(1).AddDays(-1);

            // retrieve the data from the repository
            IMeetingRepository repo = _serviceProvider.GetService<IMeetingRepository>();
            var meetings = repo.GetMeetings(start, end);

        }
    }
}
