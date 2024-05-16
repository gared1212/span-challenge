using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IEntryReader
{
     public int GetNumberEntries();
     public List<Match> GetMatches(int matches);

}

