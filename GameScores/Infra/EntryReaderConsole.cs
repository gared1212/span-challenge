namespace GameScores.Infra;
using System.Text.RegularExpressions;




public class EntryReaderConsole : IEntryReader
{
    public List<Models.Match> GetMatches(int numberMatches)
    {
        List<Models.Match> matches = new List<Models.Match>();
        int attempts = 0;
        Regex regex = new Regex(@"^.+\s\d+,.+\s\d+$");
        Console.WriteLine($"Please provide the {numberMatches} match(es) in the next format: 'Good Team FC 2, BadTeam 3'");
        do
        {
            Console.WriteLine("Provide Match # "+ (matches.Count + 1));
            string? entriesString = Console.ReadLine();
            entriesString = entriesString == null ? "" : entriesString.Trim();
            if (regex.Match(entriesString).Success)
            {
                matches.Add(normalizeMatch(entriesString));
                attempts = 0;                
            } 
            else
            {
                Console.WriteLine($"Not a valid Entry '{entriesString}'. Format is incorrect for a match.");
                attempts++;                
            }
        } while (numberMatches > matches.Count && attempts < 2);
        if (attempts > 1)
        {
            Console.WriteLine("Number of attempts exceeded - Closing the app");
        }
        return matches;
    }

    public int GetNumberEntries()
    {
        int entries = 0;
        int attempts = 0;
        do
        {
            Console.WriteLine("Provide the number of entries to be captured in the League - Just the number e.g.: 5");
            string? entriesString = Console.ReadLine();
            if (!int.TryParse(entriesString, out entries))
            {
                Console.WriteLine($"Not a Valid Number '{entriesString}'. Format is incorrect.");
                attempts++;
            }
        } while (entries <= 0 && attempts < 2);
        if (attempts > 1)
        {
            Console.WriteLine("Number of attempts exceeded - Closing the app");
        }
        return entries;
    }

    private Models.Match normalizeMatch(String match) {
        string[] results = match.Split(',');
        return new Models.Match(getTeam(results[0]), getScore(results[0]), getTeam(results[1]), getScore(results[1]));     
    }

    private string getTeam(string result)
    {
        int index = result.LastIndexOf(' ');
        return result.Substring(0, index).Trim();
        
    }

    private int getScore(string result)
    {
        int index = result.LastIndexOf(' ');
        int score = 0;
        if (int.TryParse(result.Substring(index + 1).Trim(), out score))
        {
            return score;
        }
        else
        {
            throw new ArgumentException("Not able to process the score");
        }
    }
}

