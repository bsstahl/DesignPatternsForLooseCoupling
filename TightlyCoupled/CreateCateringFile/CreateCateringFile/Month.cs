using System;

namespace CreateCateringFile;

internal class Month : System.IO.StreamReader
{
    readonly DateTime _firstDayOfMonth;

    internal Month(string inputFile) : base(inputFile) 
        => _firstDayOfMonth = this.GetFirstDayOfTheMonth(inputFile);

    internal void WriteCateringOutput(System.IO.StreamWriter outputFile)
    {
        while (!this.EndOfStream)
        {
            var meeting = new Meeting(this.ReadLine() ?? String.Empty, _firstDayOfMonth);
            meeting.WriteCateringOutput(outputFile);
        }
    }

    private DateTime GetFirstDayOfTheMonth(string inputFile)
    {
        string fileName = System.IO.Path.GetFileNameWithoutExtension(inputFile);
        string monthName = fileName.Substring(0, 3);
        string yearText = fileName.Substring(fileName.Length - 4, 4);
        return DateTime.Parse($"01-{monthName}-{yearText}");
    }
}
