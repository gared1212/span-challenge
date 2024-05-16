using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class EntryReaderConsole : IEntryReader
{
    public List<Match> GetMatches(int numberMatches)
    {
        List<Match> matches = new List<Match>();
        int attempts = 0;
       
        Console.WriteLine($"Please provide the {numberMatches} match(es) in the next format: Good Team FC 2, BadTeam 3 - Team name plus the score comma separated");
        do
        {
            Regex regex = new Regex(@"^.+\s\d+,.+\s\d+$");
            string? entriesString = Console.ReadLine();            
            if (regex.Match(entriesString == null ? "" : entriesString.Trim()).Success)
            {
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

}

