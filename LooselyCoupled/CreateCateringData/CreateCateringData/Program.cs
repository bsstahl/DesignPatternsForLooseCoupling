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
            // TODO: Add dependencies to container

            // Call the orchestration logic
            var engine = new Catering.Business.Engine(@"..\..\..\..\..\data\April2017.csv");
            engine.CreateData();
        }
    }
}
