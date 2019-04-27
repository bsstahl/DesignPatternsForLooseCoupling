using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Catering.Common.Interfaces;
using Catering.Common.Extensions;

namespace CreateCateringData
{
    class Program
    {
        static void Main(string[] args)
        {
            var argumentPairs = new ArgumentCollection(args);

            // Get the start date specified in arguments or default to the 1st day of next month
            DateTime startDate = DateTime.Now.FirstDayOfNextMonth();
            if (argumentPairs.ContainsKey("-sd"))
                startDate = DateTime.Parse(argumentPairs["-sd"]);

            // Get the end date specified in arguments or default to the last day of next month
            DateTime endDate = DateTime.Now.LastDayOfNextMonth();
            if (argumentPairs.ContainsKey("-ed"))
                endDate = DateTime.Parse(argumentPairs["-ed"]);

            // Add dependencies to container
            var container = new ServiceCollection();

            // Source Data Repository -- Meeting Service
            container.AddSingleton<IMeetingRepository>(c =>
                new Catering.Data.MeetingServiceClient.Repository());

            // Catering Strategy Logic
            container.AddSingleton<ICateringStrategy>(c =>
                new Catering.Business.Strategy.Engine());


            // Call the orchestration logic
            var engine = new Catering.Business.Engine(container.BuildServiceProvider());
            engine.CreateData(startDate, endDate);
        }
    }
}
