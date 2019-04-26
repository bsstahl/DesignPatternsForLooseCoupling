using System;
using System.Collections.Generic;
using Catering.Common.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHelperExtensions;

namespace Catering.Business.Test
{
    public static class Extensions
    {
        public static IEnumerable<Meeting> Create(this IEnumerable<Meeting> ignore)
        {
            var result = new List<Meeting>();
            for (int i = 0; i < 25.GetRandom(); i++)
            {
                result.Add((new Meeting()).Create());
            }
            return result;
        }

        public static Meeting Create(this Meeting ignore)
        {
            return new Meeting()
            {
                StartDate = DateTime.Now.AddDays(255.GetRandom()),
                NumberOfDays = 5.GetRandom(1),
                LengthHours = 6.GetRandom(2),
                Location = string.Empty.GetRandom(),
                StartHour = 20.GetRandom(10)
            };
        }

        public static DateTime FirstDayOfNextMonth(this DateTime value)
        {
            DateTime result = value.Date;
            do
                result = result.AddDays(1);
            while (result.Day != 1);
            return result;
        }

        public static DateTime LastDayOfNextMonth(this DateTime value)
        {
            DateTime result = value.Date.FirstDayOfNextMonth();
            do
                result = result.AddDays(1);
            while (result.Day != 1);
            return result.AddDays(-1);
        }
    }
}