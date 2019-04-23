using System;
using System.Linq;
using Xunit;

namespace Catering.Data.MeetingFile.Test
{
    public class Repository_GetMeetings_Should
    {
        string _testFilePath = @"..\..\..\..\..\..\data\April2017.csv";

        [Fact]
        public void ReturnTheCorrectNumberOfMeetings()
        {
            var target = new Catering.Data.MeetingFile.Repository(_testFilePath);
            var actual = target.GetMeetings(DateTime.MinValue, DateTime.MaxValue);
            Assert.Equal(73, actual.Count());
        }

        [Fact]
        public void ReturnTheCorrectNumberOfMeetingsAfterTheStartDate()
        {
            var target = new Catering.Data.MeetingFile.Repository(_testFilePath);
            var actual = target.GetMeetings(DateTime.Parse("2017-04-20"), DateTime.MaxValue);
            Assert.Equal(27, actual.Count());
        }

        [Fact]
        public void ReturnTheCorrectNumberOfMeetingsPriorToTheEndDate()
        {
            var target = new Catering.Data.MeetingFile.Repository(_testFilePath);
            var actual = target.GetMeetings(DateTime.MinValue, DateTime.Parse("2017-04-20"));
            Assert.Equal(46, actual.Count());
        }

        [Fact]
        public void ReturnTheCorrectNumberOfMeetingsBetweenDates()
        {
            var target = new Catering.Data.MeetingFile.Repository(_testFilePath);
            var actual = target.GetMeetings(DateTime.Parse("2017-04-10"), DateTime.Parse("2017-04-20"));
            Assert.Equal(25, actual.Count());
        }

        [Fact]
        public void ReturnsAMeetingMatchingTheFirstMeetingInTheFile()
        {
            // Checking all properties to confirm that this is the correct meeting
            // If we had a primary key, checking that would be enough for this test
            var target = new Catering.Data.MeetingFile.Repository(_testFilePath);
            var actual = target.GetMeetings(DateTime.MinValue, DateTime.MaxValue);

            Assert.Contains(actual, m =>
                m.StartDate == DateTime.Parse("2017-04-01") &&
                m.NumberOfDays == 2 &&
                m.StartHour == 10 &&
                m.LengthHours == 4 &&
                m.Location.ToLower() == "dallas tx");
        }

        [Fact]
        public void ReturnsAMeetingMatchingTheLastMeetingInTheFile()
        {
            // Checking all properties to confirm that this is the correct meeting
            // If we had a primary key, checking that would be enough for this test
            var target = new Catering.Data.MeetingFile.Repository(_testFilePath);
            var actual = target.GetMeetings(DateTime.MinValue, DateTime.MaxValue);

            Assert.Contains(actual, m =>
                m.StartDate == DateTime.Parse("2017-04-30") &&
                m.NumberOfDays == 2 &&
                m.StartHour == 9 &&
                m.LengthHours == 3 &&
                m.Location.ToLower() == "houston tx");
        }

        [Fact]
        public void ReturnsAMeetingMatchingAMeetingInTheMiddleOfTheFile()
        {
            // Checking all properties to confirm that this is the correct meeting
            // If we had a primary key, checking that would be enough for this test
            var target = new Catering.Data.MeetingFile.Repository(_testFilePath);
            var actual = target.GetMeetings(DateTime.MinValue, DateTime.MaxValue);

            Assert.Contains(actual, m =>
                m.StartDate == DateTime.Parse("2017-04-18") &&
                m.NumberOfDays == 1 &&
                m.StartHour == 12 &&
                m.LengthHours == 1 &&
                m.Location.ToLower() == "miami fl");
        }
    }
}
