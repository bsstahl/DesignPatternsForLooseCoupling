namespace CreateCateringFile;

internal class Meeting
{
    readonly List<MeetingDay> _meetingDays = new();

    internal Meeting(string sourceFileRow, DateTime firstDayOfMonth) 
        => this.Parse(sourceFileRow, firstDayOfMonth);

    internal int StartDay { get; set; }
    internal int DayCount { get; set; }
    internal Single StartHour { get; set; }
    internal Single Length { get; set; }
    internal string Location { get; set; } = String.Empty;

    internal IEnumerable<MeetingDay> MeetingDays => _meetingDays;

    internal void WriteCateringOutput(System.IO.StreamWriter outputWriter)
    {
        foreach (var meetingDate in _meetingDays)
            if (meetingDate.IsCatered)
                outputWriter.WriteLine($"{meetingDate.StartDateTime:d},{this.Location}");
    }

    private void Parse(string sourceFileRow, DateTime firstDayOfMonth)
    {
        var items = sourceFileRow.Split(',');
        this.StartDay = Int32.Parse(items[0]);
        this.DayCount = Int32.Parse(items[1]);
        this.StartHour = Single.Parse(items[2]);
        this.Length = Single.Parse(items[3]);
        this.Location = items[4];

        for (int i = 0; i < this.DayCount; i++)
        {
            var startDateTime = firstDayOfMonth.AddDays(i + this.StartDay - 1).Date.AddHours(this.StartHour);
            var endDateTime = startDateTime.AddHours(this.Length);
            _meetingDays.Add(new MeetingDay(startDateTime, endDateTime));
        }
    }
}
