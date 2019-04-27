using Catering.Common.Entities;
using System;

namespace Catering.Common.Builders
{
    public class MeetingBuilder: Meeting
    {
        public Meeting Build()
        {
            return this;
        }

        public new MeetingBuilder NumberOfDays(int numberOfDays)
        {
            base.NumberOfDays = numberOfDays;
            return this;
        }

        public new MeetingBuilder LengthHours(int lengthHours)
        {
            base.LengthHours = lengthHours;
            return this;
        }

        public new MeetingBuilder Location(string location)
        {
            base.Location = location;
            return this;
        }

        public new MeetingBuilder StartDate(DateTime startDate)
        {
            base.StartDate = startDate;
            return this;
        }

        public new MeetingBuilder StartHour(float startHour)
        {
            base.StartHour = startHour;
            return this;
        }

    }
}
