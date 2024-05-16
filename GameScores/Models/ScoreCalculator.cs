
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ScoreCalculator : IScoreCalculator {

    public ScoreCalculator() { }

    public SortedSet<(string, int)> CalculateScore(List<Match> matches) {
        Dictionary<string, int> mergedResults = mergeResults(matches);
        SortedSet<(string, int)> leagueResults = sortDictionary(mergedResults);
        return leagueResults;
    }    

    private Dictionary<string, int> mergeResults(List<Match> matches) {
        Dictionary<string, int> teamPoints = new Dictionary<string, int>();
        foreach (var match in matches)
        {
            // Team local exists, add points to its total
            if (teamPoints.ContainsKey(match.TeamLocal))
            {
                teamPoints[match.TeamLocal] += match.LocalPoints;
            }
            else 
            {
                teamPoints[match.TeamLocal] = match.LocalPoints;
            }
            // visitor team exists, add points to its total
            if (teamPoints.ContainsKey(match.TeamVisitor))
            {
                teamPoints[match.TeamVisitor] += match.VisitorPoints;
            }
            else
            {
                teamPoints[match.TeamVisitor] = match.VisitorPoints;
            }
        }
        return teamPoints;
    }
    private SortedSet<(string, int)> sortDictionary(Dictionary<string, int> mergedResults)
    {
        SortedSet<(string, int)> leagueResults = new SortedSet<(string, int)>(Comparer<(string Team, int Points)>.Create((x, y) => {
            int result = y.Points.CompareTo(x.Points);
            if (result == 0)
            {
                result = x.Team.CompareTo(y.Team);
            }
            return result;
        }));

        // Add teams and their total points to the sorted set
        foreach (var entry in mergedResults)
        {
            leagueResults.Add((entry.Key, entry.Value));
        }
        return leagueResults;
    }

}