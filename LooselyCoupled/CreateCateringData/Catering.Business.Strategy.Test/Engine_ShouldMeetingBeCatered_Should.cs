using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catering.Business.Strategy.Test
{
    [TestClass]
    public class Engine_ShouldMeetingBeCatered_Should
    {
        public TestContext TestContext { get; set; }

        #region Saturday Tests

        [TestMethod]
        public void ReturnFalseIfMeetingStartsAfterLunchOnSaturday()
        {
            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/22/2023 14:00"); // Saturday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnFalseIfMeetingEndsAtStartOfLunchOnSaturday()
        {
            bool expected = false;
            DateTime startDateTime = DateTime.Parse("7/22/2023 08:30"); // Saturday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnTrueIfMeetingStartsDuringLunchOnSaturday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/22/2023 12:30"); // Saturday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnTrueIfMeetingStartsAtEndOfLunchOnSaturday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/22/2023 13:30"); // Saturday
            Single meetingLengthHours = 2.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnTrueIfMeetingRunsThroughLunchOnSaturday()
        {
            bool expected = true;
            DateTime startDateTime = DateTime.Parse("7/22/2023 10:00"); // Saturday
            Single meetingLengthHours = 5.0f;

            var target = new Strategy.Engine();
            var actual = target.ShouldMeetingBeCatered(startDateTime, meetingLengthHours);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Sunday Tests

        // TODO: Sunday Tests

        #endregion

        #region Weekday Tests

        // TODO: Weekday Tests

        #endregion  
    }
}
