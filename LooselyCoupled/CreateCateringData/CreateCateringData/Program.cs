using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Common.Interfaces;
using Microsoft.Framework.DependencyInjection;

namespace CreateCateringData
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceCollection();
            container.AddSingleton<IMeetingRepository>(c => 
                new Catering.Data.MeetingServiceClient.Repository());
            container.AddSingleton<ICateringStrategy>(c => 
                new Catering.Business.Strategy.Engine());

            var engine = new Catering.Business.Engine(container.BuildServiceProvider());
            engine.CreateData();
        }
    }
}
