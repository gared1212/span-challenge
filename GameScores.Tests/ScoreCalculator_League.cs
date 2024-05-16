namespace GameScores.Tests;
using Xunit;
using GameScores.Models;
using GameScores.Services;



public class ScoreCalculator_League
{
    [Fact]
    void MatchesFormat_CalculateTiePosition_ReturnAlphabetical() { 
        var scoreCalculator = new ScoreCalculator();
        var matches = new List<Match>();
        matches.Add(new Match("Lions", 1, "Snakes", 4));
        matches.Add(new Match("Lions", 4, "Snakes", 1));
        scoreCalculator.calculateMatchPoints(matches);
        var result = scoreCalculator.CalculateTotalLeagueRaking(matches);
        Assert.Equal("Lions", result.First<(string team,int point)>().team);
    }
    [Fact]
    void MatchesFormat_CalculateDrawMatch_ReturnByPoints()
    {
        var scoreCalculator = new ScoreCalculator();
        var matches = new List<Match>();
        matches.Add(new Match("Lions", 1, "Atletico san Pancho", 1));
        matches.Add(new Match("Lions", 0, "Atletico san Pancho", 2));
        matches.Add(new Match("snakes", 0, "Atletico san Pancho", 2));
        scoreCalculator.calculateMatchPoints(matches);
        var result = scoreCalculator.CalculateTotalLeagueRaking(matches);
        Assert.Equal("Atletico san Pancho", result.First<(string team, int point)>().team);
    }

}

