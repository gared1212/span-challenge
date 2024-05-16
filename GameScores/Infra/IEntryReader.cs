namespace GameScores.Infra;
using GameScores.Models;
public interface IEntryReader
{
     public int GetNumberEntries();
     public List<Match> GetMatches(int matches);

}

