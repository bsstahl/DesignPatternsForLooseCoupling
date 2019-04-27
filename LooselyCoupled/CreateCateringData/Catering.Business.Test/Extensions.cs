using System;
using System.Collections.Generic;
using Catering.Common.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHelperExtensions;
using Catering.Common.Builders;

namespace Catering.Business.Test
{
    public static class Extensions
    {
        public static IEnumerable<Meeting> Create(this IEnumerable<Meeting> ignore)
        {
            return ignore.Create(25.GetRandom());
        }

        public static IEnumerable<Meeting> Create(this IEnumerable<Meeting> ignore, Int32 count)
        {
            var result = new List<Meeting>();
            for (int i = 0; i < count; i++)
            {
                result.Add((new MeetingBuilder()).Random().Build());
            }
            return result;
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

        public static MeetingBuilder Random(this MeetingBuilder builder)
        {
            return builder.NumberOfDays(5.GetRandom(1))
                .StartDate(DateTime.Now.AddDays(255.GetRandom()))
                .LengthHours(6.GetRandom(2))
                .Location(string.Empty.GetRandom())
                .StartHour(20.GetRandom(10));
        }

    }
}