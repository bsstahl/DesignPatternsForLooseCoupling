using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCateringFile
{
    internal class Month : System.IO.StreamReader
    {
        DateTime _firstDayOfMonth;

        internal Month(string inputFile) 
            : base(inputFile)
        {
            _firstDayOfMonth = GetFirstDayOfTheMonth(inputFile);
        }

        internal void WriteCateringOutput(System.IO.StreamWriter outputFile)
        {
            while (!this.EndOfStream)
            {
                var meeting = new Meeting(this.ReadLine(), _firstDayOfMonth);
                meeting.WriteCateringOutput(outputFile);
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
