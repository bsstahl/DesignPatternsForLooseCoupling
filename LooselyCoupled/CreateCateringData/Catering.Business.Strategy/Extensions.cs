using System;
using System.Collections.Generic;

namespace Catering.Business.Strategy;

public static class Extensions
{
    public static Single AsHour(this DateTime value)
    {
        Single hour = value.Hour;
        Single minute = value.Minute;
        return (hour + (value.Minute / 60.0f));
    }

    public static List<Single> AsThirtyMinuteIntervals(this DateTime startDateTime, DateTime endDateTime)
    {
        var mtgHours = new List<Single>();
        Single startHour = startDateTime.AsHour();
        Single endHour = endDateTime.AsHour();
        for (Single i = startHour; i < endHour; i += 0.5f)
            mtgHours.Add(i);
        return mtgHours;
    }

}