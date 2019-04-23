using System;
using Catering.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Catering.Business.Test
{
    public class Engine_CreateData_Should
    {
        string _testFilePath = @"..\..\..\..\..\..\data\April2017.csv";

        // This is supposed to be testing the Business logic but is instead
        // testing all the way down to the data store -- Integration Tests

        [Fact(Skip = "No way to assert the proper result")]
        public void ProduceTheCorrectNumberOfCateringsBasedOnTheMeetingsFile()
        {
            var target = new Catering.Business.Engine(_testFilePath);
            target.CreateData();

            // I have no way to validate this test since it doesn't return
            // anything and at this point, CreateData doesn't even output anything
        }

    }
}
