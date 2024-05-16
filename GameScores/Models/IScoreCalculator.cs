

public interface IScoreCalculator
{
    public SortedSet<(string, int)> CalculateScore(List<Match> matches);
}
    
    

