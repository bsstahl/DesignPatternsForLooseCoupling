using System;
using Catering.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Catering.Business.Test
{
    public class Engine_CreateData_Should
    {
        // We can now do interaction testing with the Repository but still
        // have no good way to test the actual Business Rules since the only
        // way the results ever leave the Business engine is when they
        // are written out in the results.

        [Fact]
        public void RetrieveTheMeetingsFromTheMeetingRepositoryExactlyOnce()
        {
            var container = new ServiceCollection();

            var repo = new Mock<IMeetingRepository>();
            container.AddSingleton<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData();

            repo.Verify(r => r.GetMeetings(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Exactly(1));
        }

        [Fact]
        public void PassTheFirstDayOfNextMonthAsTheStartDateToTheMeetingRepository()
        {
            var container = new ServiceCollection();

            var repo = new Mock<IMeetingRepository>();
            container.AddSingleton<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData();

            repo.Verify(r => r.GetMeetings(DateTime.Now.FirstDayOfNextMonth(), It.IsAny<DateTime>()), Times.Once);
        }

        [Fact]
        public void PassTheLastDayOfNextMonthAsTheEndDateToTheMeetingRepository()
        {
            var container = new ServiceCollection();

            var repo = new Mock<IMeetingRepository>();
            container.AddSingleton<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData();

            repo.Verify(r => r.GetMeetings(It.IsAny<DateTime>(), DateTime.Now.LastDayOfNextMonth()), Times.Once);
        }
    }
}
