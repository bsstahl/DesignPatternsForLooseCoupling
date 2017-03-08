using System;
using System.Collections.Generic;
using Catering.Common.Interfaces;

namespace Catering.Data.MeetingFile
{
    public class Repository : IMeetingRepository
    {
        private string _inputFilePath;

        public Repository(string inputFilePath)
        {
            _inputFilePath = inputFilePath;
        }

        public IEnumerable<Common.Entities.Meeting> GetMeetings(DateTime start, DateTime end)
        {
            return new Month(_inputFilePath);
        }
    }
}
