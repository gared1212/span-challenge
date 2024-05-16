namespace GameScores.Tests;
using Xunit;
using GameScores.Models;
using GameScores.Services;



public class ScoreCalculator_Matches
{
    [Fact]
    void MatchesFormat_CalculateOneVisitorWon_ReturnVisitorPointsThree() { 
        var scoreCalculator = new ScoreCalculator();
        var matches = new List<Match>();
        matches.Add(new Match("Lions", 1, "Snakes", 4));
        scoreCalculator.calculateMatchPoints(matches);
        Assert.Equal(3, matches[0].VisitorPoints);
    }
    [Fact]
    void MatchesFormat_CalculateDrawMatch_ReturnVisitorPointsThree()
    {
        var scoreCalculator = new ScoreCalculator();
        var matches = new List<Match>();
        matches.Add(new Match("Lions", 1, "Atletico san Pancho", 1));
        scoreCalculator.calculateMatchPoints(matches);
        Assert.True(matches[0].VisitorPoints == 1 && matches[0].LocalPoints == 1);
    }

}

