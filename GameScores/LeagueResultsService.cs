using Microsoft.Extensions.Logging;
using GameScores.Infra;
using GameScores.Models;
using GameScores.Services;


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
        if (entries == 0){return 1;}
        matches = reader.GetMatches(entries);
        if (matches.Count == 0) { return 1; }
        scoreCalculator.calculateMatchPoints(matches);
        var leagueResults = scoreCalculator.CalculateTotalLeagueRaking(matches);
        return 0;
    }
   



}