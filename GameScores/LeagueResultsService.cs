using Microsoft.Extensions.Logging;


public class LeagueResultsService {
    ILogger logger;
    IEntryReader reader;
    IScoreCalculator scoreCalculator;

    public LeagueResultsService(ILogger logger, IEntryReader reader, IScoreCalculator scoreCalculator){
        this.logger = logger;
        this.reader = reader;
        this.scoreCalculator = scoreCalculator;
    }

    public int CalculateScore(){
        int entries = 0;
        List<Match> matches = new List<Match>();
        entries = reader.GetNumberEntries();
        if (entries != 0)
        {
            matches = reader.GetMatches(entries);
            return 0;
        }        
        return 1;
    }
   



}