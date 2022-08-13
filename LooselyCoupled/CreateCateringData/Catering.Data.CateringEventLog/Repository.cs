using System;
using System.Collections.Generic;
using System.Linq;
using Catering.Common.Entities;
using Catering.Common.Interfaces;

namespace Catering.Data.CateringEventLog
{
    public class Repository: ICateringEventWriteRepository
    {
        public void WriteCateringEvents(IEnumerable<CateringEvent> cateringEvents)
        {
            foreach (var cateringEvent in cateringEvents)
            {
                Console.WriteLine($"A catered event will be held in {cateringEvent.City} on {cateringEvent.CateringDate}");
            }
            Console.WriteLine($"\r\n{cateringEvents.Count()} catering events were written");
        }
    }
}
