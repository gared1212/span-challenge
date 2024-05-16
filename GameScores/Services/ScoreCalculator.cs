namespace GameScores.Services;

using GameScores.Models;

public class ScoreCalculator : IScoreCalculator {

    public ScoreCalculator() { }

    public void calculateMatchPoints(List<Match> matches) {
        foreach (Match match in matches) {
            calculatePoints(match);
        }
    }

    public SortedSet<(string, int)> CalculateTotalLeagueRaking(List<Match> matches) {
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

    private void calculatePoints(Match match)
    {
        if (match.LocalScore == match.VisitorScore)
        {
            match.VisitorPoints = 1;
            match.LocalPoints = 1;
        }
        else if (match.LocalScore > match.VisitorScore)
        {
            match.LocalPoints = 3;
            match.VisitorPoints = 0;
        }
        else
        {
            match.LocalPoints = 0;
            match.VisitorPoints = 3;
        }
    }

}