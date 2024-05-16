using GameScores.Models;

namespace GameScores.Services;

public interface IScoreCalculator
{
    public SortedSet<(string, int)> CalculateTotalLeagueRaking(List<Match> matches);
    public void calculateMatchPoints(List<Match> match);
}



