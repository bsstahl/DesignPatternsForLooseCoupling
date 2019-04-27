using System;
using System.Collections.Generic;
using Catering.Common.Interfaces;
using Catering.Common.Entities;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using System.Linq;
using Catering.Common.Builders;
using TestHelperExtensions;

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
            target.CreateData(DateTime.MinValue, DateTime.MaxValue);

            int expected = meetings.Sum(m => m.NumberOfDays);
            strategy.Verify(s => s.ShouldMeetingBeCatered(It.IsAny<DateTime>(), It.IsAny<float>()), Times.Exactly(expected));
        }

        [Fact]
        public void PassTheCorrectMeetingStartDateTimeToTheStrategy()
        {
            var container = new ServiceCollection();

            var strategy = new Mock<ICateringStrategy>();
            container.AddSingleton<ICateringStrategy>(strategy.Object);

            var repo = new Mock<IMeetingRepository>();
            var meeting = new MeetingBuilder().Random().NumberOfDays(1).Build();
            var meetings = new Meeting[] { meeting };

            repo.Setup(r => r.GetMeetings(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(meetings);
            container.AddSingleton<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData(DateTime.MinValue, DateTime.MaxValue);

            var expected = meeting.StartDate.Date.AddHours(meeting.StartHour);
            strategy.Verify(s => s.ShouldMeetingBeCatered(
                It.Is<DateTime>(p => p == expected),
                It.IsAny<float>()
                ), Times.Once);
        }

        [Fact]
        public void PassTheCorrectMeetingLengthHoursToTheStrategy()
        {
            var container = new ServiceCollection();

            var strategy = new Mock<ICateringStrategy>();
            container.AddSingleton<ICateringStrategy>(strategy.Object);

            var repo = new Mock<IMeetingRepository>();
            var meeting = new MeetingBuilder().Random().NumberOfDays(1).Build();
            var meetings = new Meeting[] { meeting };

            repo.Setup(r => r.GetMeetings(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(meetings);
            container.AddSingleton<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData(DateTime.MinValue, DateTime.MaxValue);

            var expected = meeting.LengthHours;
            strategy.Verify(s => s.ShouldMeetingBeCatered(
                It.IsAny<DateTime>(),
                It.Is<float>(p => p == expected)
                ), Times.Once);
        }

        [Fact]
        public void RetrieveTheMeetingsFromTheMeetingRepositoryExactlyOnce()
        {
            var container = new ServiceCollection();

            var repo = new Mock<IMeetingRepository>();
            container.AddSingleton<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData(DateTime.MinValue, DateTime.MaxValue);

            repo.Verify(r => r.GetMeetings(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Exactly(1));
        }

        [Fact]
        public void PassTheCorrectDateAsTheStartDateToTheMeetingRepository()
        {
            var expected = DateTime.Now.GetRandom();
            var container = new ServiceCollection();

            var repo = new Mock<IMeetingRepository>();
            container.AddSingleton<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData(expected, DateTime.MaxValue);

            repo.Verify(r => r.GetMeetings(expected, It.IsAny<DateTime>()), Times.Once);
        }

        [Fact]
        public void PassTheCorrectDateAsTheEndDateToTheMeetingRepository()
        {
            var expected = DateTime.Now.GetRandom();
            var container = new ServiceCollection();

            var repo = new Mock<IMeetingRepository>();
            container.AddSingleton<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData(DateTime.MinValue, expected);

            repo.Verify(r => r.GetMeetings(It.IsAny<DateTime>(), expected), Times.Once);
        }
    }
}
