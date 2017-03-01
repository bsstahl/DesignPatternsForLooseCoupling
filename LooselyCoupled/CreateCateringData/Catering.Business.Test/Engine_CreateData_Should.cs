using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Framework.DependencyInjection;
using Catering.Common.Interfaces;
using Moq;

namespace Catering.Business.Test
{
    [TestClass]
    public class Engine_CreateData_Should
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void RetrieveTheMeetingsFromTheMeetingRepositoryExactlyOnce()
        {
            var container = new ServiceCollection();

            var repo = new Mock<IMeetingRepository>();
            container.AddInstance<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData();

            repo.Verify(r => r.GetMeetings(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Exactly(1));
        }

        [TestMethod]
        public void PassTheFirstDayOfNextMonthAsTheStartDateToTheMeetingRepository()
        {
            var container = new ServiceCollection();

            var repo = new Mock<IMeetingRepository>();
            container.AddInstance<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData();

            repo.Verify(r => r.GetMeetings(DateTime.Now.FirstDayOfNextMonth(), It.IsAny<DateTime>()), Times.Once);
        }

        [TestMethod]
        public void PassTheLastDayOfNextMonthAsTheEndDateToTheMeetingRepository()
        {
            var container = new ServiceCollection();

            var repo = new Mock<IMeetingRepository>();
            container.AddInstance<IMeetingRepository>(repo.Object);

            var target = new Catering.Business.Engine(container.BuildServiceProvider());
            target.CreateData();

            repo.Verify(r => r.GetMeetings(It.IsAny<DateTime>(), DateTime.Now.LastDayOfNextMonth()), Times.Once);
        }

    }
}
