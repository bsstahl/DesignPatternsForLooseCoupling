using Microsoft.Extensions.DependencyInjection;
using Catering.Business;
using Catering.Data.MeetingFile;
using Catering.Common.Interfaces;
using Catering.Data.CateringEventLog;
using Catering.Business.Strategy;

namespace CreateCateringData;

class Program
{
    static void Main(string[] args)
    {
        var argumentPairs = new ArgumentCollection(args);
        string inputFile = argumentPairs["-s"] ?? "input.csv";
        // string outputFile = argumentPairs["-t"] ?? "output.csv";

        // Add dependencies to container
        var serviceProvider = new ServiceCollection()
            .UseCateringBusinessEngine()
            .UseMeetingFileMeetingRepository(inputFile)
            .UseCateringEventLogRepository()
            .UseLunchtimeCateringStrategy()
            .BuildServiceProvider();

        // Retrieve the Orchestration Engine
        var engine = serviceProvider
            .GetRequiredService<IOrchestrationEngine>(); 

        // Call the orchestration logic
        engine.CreateData();
    }
}
