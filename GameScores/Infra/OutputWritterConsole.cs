namespace GameScores.Infra;


public class OutputWriterConsole : IOutputWriter
{
    public void PublishResults(SortedSet<(string name, int points)> leagueResults) {
        Console.WriteLine("\n\n#####################  League Results #####################");
        foreach (var team in leagueResults) {
            string suffix = team.points == 1 ? "pt" : "pts";
            Console.WriteLine($"{team.name}, {team.points} {suffix}");
        }
        Console.WriteLine("\n\n#####################                  #####################");
    }
}
