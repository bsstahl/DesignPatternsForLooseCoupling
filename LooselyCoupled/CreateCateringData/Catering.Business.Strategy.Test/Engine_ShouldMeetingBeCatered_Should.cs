using System;
using Xunit;

namespace Catering.Business.Strategy.Test
{
    public class Engine_ShouldMeetingBeCatered_Should
    {
        #region Saturday Tests

        [Fact]
        public void ReturnFalseIfMeetingStartsAfterLunchOnSaturday()
        {
            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/22/2023 14:00"); // Saturday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnFalseIfMeetingEndsAtStartOfLunchOnSaturday()
        {
            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/22/2023 08:30"); // Saturday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnTrueIfMeetingStartsDuringLunchOnSaturday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/22/2023 12:30"); // Saturday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnTrueIfMeetingStartsAtEndOfLunchOnSaturday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/22/2023 13:30"); // Saturday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnTrueIfMeetingRunsThroughLunchOnSaturday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/22/2023 10:00"); // Saturday
            Single meetingLengthHours = 5.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        #endregion

        #region Sunday Tests

        [Fact]
        public void ReturnFalseIfMeetingStartsAfterLunchOnSunday()
        {
            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/23/2023 14:00"); // Sunday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnFalseIfMeetingEndsAtStartOfLunchOnSunday()
        {
            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/23/2023 08:30"); // Sunday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnTrueIfMeetingStartsDuringLunchOnSunday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/23/2023 12:30"); // Sunday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnTrueIfMeetingStartsAtEndOfLunchOnSunday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/23/2023 13:30"); // Sunday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnTrueIfMeetingRunsThroughLunchOnSunday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/23/2023 10:00"); // Sunday
            Single meetingLengthHours = 5.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }


        #endregion

        #region Weekday Tests

        [Fact]
        public void ReturnFalseIfMeetingStartsAfterLunchOnMonday()
        {
            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/24/2023 13:00"); // Monday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnFalseIfMeetingEndsAtStartOfLunchOnTuesday()
        {
            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/25/2023 09:00"); // Tuesday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnTrueIfMeetingStartsDuringLunchOnWednesday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/26/2023 12:00"); // Wednesday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnTrueIfMeetingStartsAtEndOfLunchOnThursday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/27/2023 12:30"); // Thursday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnTrueIfMeetingRunsThroughLunchOnFriday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/28/2023 10:00"); // Friday
            Single meetingLengthHours = 5.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }


        #endregion

        #region Exposing Bug Raised by Kevin Hakanson in GitHub Issue #1

        // Issue is only visible when: 
        //   * It is a weekend
        //   * It is not during weekend lunch hours 
        //   * But it is during weekday lunch hours
        // https://github.com/bsstahl/DesignPatternsForLooseCoupling/issues/1

        [Fact]
        public void ReturnFalseIfMeetingStartsAfterLunchOnSaturdayButDuringWeekdayLunchHours()
        {
            var weekdayLunchHours = new Single[] { 11f, 11.5f, 12f, 12.5f };
            var weekendLunchHours = new Single[] { 10.5f, 11f, 11.5f, 12.0f };

            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/22/2023 12:30"); // Saturday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine(weekdayLunchHours, weekendLunchHours);
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnFalseIfMeetingEndsBeforeLunchOnSundayButDuringWeekdayLunchHours()
        {
            var weekdayLunchHours = new Single[] { 11f, 11.5f, 12f };
            var weekendLunchHours = new Single[] { 11.5f, 12.0f, 12.5f, 13f, 13.5f };

            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/23/2023 09:30"); // Sunday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine(weekdayLunchHours, weekendLunchHours);
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}
