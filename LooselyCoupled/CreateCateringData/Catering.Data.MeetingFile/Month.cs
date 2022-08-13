using System;
using System.Collections.Generic;

namespace Catering.Data.MeetingFile
{
    internal class Month : List<Meeting>
    {
        string _inputFilePath;
        DateTime _firstDayOfMonth;

        internal Month(string inputFilePath)
        {
            _inputFilePath = inputFilePath;
            _firstDayOfMonth = GetFirstDayOfTheMonth(inputFilePath);
            this.Load();
        }

        internal void Load()
        {
            using (var stream = new System.IO.StreamReader(_inputFilePath))
            {
                while (!stream.EndOfStream)
                {
                    this.Add(new Meeting(stream.ReadLine(), _firstDayOfMonth));
                }
            }
        }

        private DateTime GetFirstDayOfTheMonth(string inputFile)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(inputFile);
            int fnLength = fileName.Length;

            string monthName = fileName.Substring(0, 3);
            string yearText = fileName.Substring(fnLength - 4, 4);
            string firstOfMonthText = $"01-{monthName}-{yearText}";

            return DateTime.Parse(firstOfMonthText);
        }

    }
}
