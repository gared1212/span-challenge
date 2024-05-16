namespace GameScores.Infra;

public interface IOutputWriter
{
    public void PublishResults(SortedSet<(string name, int points)> leagueResults);

}
