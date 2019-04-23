using System;
using Catering.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Catering.Business.Test
{
    public class Engine_CreateData_Should
    {
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
