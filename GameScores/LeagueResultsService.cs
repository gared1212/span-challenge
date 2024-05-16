using Microsoft.Extensions.Logging;
using GameScores.Infra;
using GameScores.Models;
using GameScores.Services;


public class LeagueResultsService {
    ILogger logger;
    IEntryReader reader;
    IScoreCalculator scoreCalculator;
    IOutputWriter writer;

    public LeagueResultsService(ILogger logger, IEntryReader reader, IScoreCalculator scoreCalculator, IOutputWriter writer) {
        this.logger = logger;
        this.reader = reader;
        this.scoreCalculator = scoreCalculator;
        this.writer = writer;   
    }

    public int CalculateScore() {
        int entries = 0;
        List<Match> matches = new List<Match>();
        entries = reader.GetNumberEntries();
        if (entries == 0){return 1;}
        matches = reader.GetMatches(entries);
        if (matches.Count == 0) { return 1; }
        scoreCalculator.calculateMatchPoints(matches);
        var leagueResults = scoreCalculator.CalculateTotalLeagueRaking(matches);
        writer.PublishResults(leagueResults);
        return 0;
    }
   



}