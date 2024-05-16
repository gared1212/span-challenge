
using Microsoft.Extensions.Logging;
using GameScores.Infra;
using GameScores.Services;

class App
{
    static int Main(string[] args)
    {
        ILogger logger =  App.CreateLogger();
        int executionResult = 0;
        var watch = System.Diagnostics.Stopwatch.StartNew();
        logger.LogInformation("Starting the app.");
        LeagueResultsService leagueResultsService = new LeagueResultsService(logger, new EntryReaderConsole(), new ScoreCalculator(), new OutputWriterConsole());
        watch.Stop();       
        long elapsedMs = watch.ElapsedMilliseconds;
        logger.LogInformation("App Started in {elapsedTime}ms.", elapsedMs);        
        try
        {
            executionResult = leagueResultsService.CalculateScore();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error executing the program - please reach out to Edgar Ramirez");
        }     
        return executionResult;
    }
    static ILogger CreateLogger(){
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger  logger = factory.CreateLogger("Score & Results");        
        return logger;
    }

}
