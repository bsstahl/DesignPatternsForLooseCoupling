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

        // TODO: Sunday Tests

        #endregion

        #region Weekday Tests

        // TODO: Weekday Tests

        #endregion

        #region Exposing Bug Raised by hakanson in GitHub Issue #1

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
        public void ReturnFalseIfMeetingStartsBeforeLunchOnSundayButDuringWeekdayLunchHours()
        {
            var weekdayLunchHours = new Single[] { 11f, 11.5f, 12f };
            var weekendLunchHours = new Single[] { 11.5f, 12.0f, 12.5f, 13f, 13.5f };

            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/23/2023 11:00"); // Sunday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine(weekdayLunchHours, weekendLunchHours);
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}
