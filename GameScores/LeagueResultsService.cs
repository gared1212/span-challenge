namespace GameScores;

using Microsoft.Extensions.Logging;
using System.IO;
public class LeagueResultsService {
    ILogger logger;
    public LeagueResultsService(ILogger logger){
        this.logger = logger;
    }

    public int CalculateScore(){
        string? line = Console.ReadLine();
        Console.WriteLine(line);
        return 0;
    }

}