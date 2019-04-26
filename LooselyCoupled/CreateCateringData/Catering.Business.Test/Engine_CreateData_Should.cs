using System;
using System.Collections.Generic;
using Catering.Common.Interfaces;
using Catering.Common.Entities;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using System.Linq;

namespace Catering.Business.Test
{
    public class Engine_CreateData_Should
    {
        [Fact]
        public void CallTheCateringStrategyOncePerMeetingDay()
        {
            var container = new ServiceCollection();

            var strategy = new Mock<ICateringStrategy>();
            container.AddSingleton<ICateringStrategy>(strategy.Object);

            var repo = new Mock<IMeetingRepository>();
            var meetings = (null as IEnumerable<Meeting>).Create();
            repo.Setup(r => r.GetMeetings(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(meetings);
            container.AddSingleton<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData();

            int expected = meetings.Sum(m => m.NumberOfDays);
            strategy.Verify(s => s.ShouldMeetingBeCatered(It.IsAny<DateTime>(), It.IsAny<float>()), Times.Exactly(expected));
        }


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
