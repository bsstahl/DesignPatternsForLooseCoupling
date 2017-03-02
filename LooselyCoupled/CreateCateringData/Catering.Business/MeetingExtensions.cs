using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Common.Entities;

namespace Catering.Business
{
    public static class MeetingExtensions
    {
        public static CateringEvent AsCateringEvent(this Meeting meeting, int yearNumber, int monthNumber)
        {
            return new CateringEvent()
            {
                CateringDate = new DateTime(yearNumber, monthNumber, meeting.StartDay),
                City = meeting.Location
            };
        }
    }
}
