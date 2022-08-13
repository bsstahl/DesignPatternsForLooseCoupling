using System;

namespace Catering.Common.Extensions;

public static class DateExtensions
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
