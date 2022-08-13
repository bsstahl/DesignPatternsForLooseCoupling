using System;
using System.Collections.Generic;
using System.Linq;
using Catering.Common.Interfaces;

namespace Catering.Business.Strategy;

public class LunchtimeCateringStrategy : ICateringStrategy
{
    readonly IEnumerable<Single> _defaultWeekdayLunchHours = new Single[] { 11f, 11.5f, 12f, 12.5f };
    readonly IEnumerable<Single> _defaultWeekendLunchHours = new Single[] { 10.5f, 11f, 11.5f, 12f, 12.5f, 13f, 13.5f };

    readonly IEnumerable<Single> _weekdayLunchHours;
    readonly IEnumerable<Single> _weekendLunchHours;

    public LunchtimeCateringStrategy(IEnumerable<Single> weekdayLunchHours, IEnumerable<Single> weekendLunchHours)
    {
        _weekdayLunchHours = weekdayLunchHours.Any() ? weekdayLunchHours : _defaultWeekdayLunchHours;
        _weekendLunchHours = weekendLunchHours.Any() ? weekendLunchHours : _defaultWeekendLunchHours;
    }

    public bool ShouldMeetingBeCatered(DateTime startDateTime, Single meetingLengthHours)
    {
        DateTime endDateTime = startDateTime.AddHours(meetingLengthHours);

        var dow = startDateTime.Date.DayOfWeek;
        var isWeekend = (dow == DayOfWeek.Saturday || dow == DayOfWeek.Sunday);

        var mtgHours = startDateTime.AsThirtyMinuteIntervals(endDateTime);

        var isDuringWeekdayLunchHours = _weekdayLunchHours.Intersect(mtgHours).Any();
        var isDuringWeekendLunchHours = _weekendLunchHours.Intersect(mtgHours).Any();

        var isDuringWeekdayLunch = !isWeekend && isDuringWeekdayLunchHours;
        var isDuringWeekendLunch = isWeekend && isDuringWeekendLunchHours;

        bool isDuringLunch = isDuringWeekdayLunch || isDuringWeekendLunch;

        return (isDuringLunch && meetingLengthHours > 1.0);
    }
}
