using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Business.Test
{
    public static class Extensions
    {
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