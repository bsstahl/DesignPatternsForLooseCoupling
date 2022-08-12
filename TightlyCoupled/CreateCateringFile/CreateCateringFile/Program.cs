namespace CreateCateringFile;

class Program
{
    static void Main(string[] args)
    {
        var argumentPairs = new ArgumentCollection(args);
        string inputFile = argumentPairs["-s"] ?? "input.csv";
        string outputFile = argumentPairs["-t"] ?? "output.csv";

        using var outputWriter = new StreamWriter(outputFile);
        var month = new Month(inputFile);
        month.WriteCateringOutput(outputWriter);
        outputWriter.Flush();
    }
}
