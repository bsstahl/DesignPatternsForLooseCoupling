using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Catering.Common.Interfaces;

namespace CreateCateringData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add dependencies to container
            var container = new ServiceCollection();
            container.AddTransient<IMeetingRepository>(s => 
                new Catering.Data.MeetingFile.Repository(@"..\..\..\..\..\..\data\April2017.csv"));

            // Call the orchestration logic
            var engine = new Catering.Business.Engine(container.BuildServiceProvider());
            engine.CreateData();
        }
    }
}
