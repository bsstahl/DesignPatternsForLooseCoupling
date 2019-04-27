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
        private readonly IServiceProvider _serviceProvider;
        public Engine(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateData(DateTime start, DateTime end)
        {
            // Retrieve the data from the repository
            var repo = _serviceProvider.GetService<IMeetingRepository>();
            var meetings = repo.GetMeetings(start, end);

            // Determine if catering is required for any day in any meeting
            var strategy = _serviceProvider.GetService<ICateringStrategy>();
            var cateringEvents = meetings.SelectCateringEvents(strategy);

            // TODO: Output results to Catering Repository
        }

    }
}
