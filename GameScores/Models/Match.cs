namespace GameScores.Models;
public class Match {
    public string TeamLocal { get; private set; }
    public int LocalScore { get; private set; }
    public string TeamVisitor { get; private set; }
    public int VisitorScore { get; private set; }
    public int VisitorPoints { get;  set; }
    public int LocalPoints { get;  set; }

    public Match(string teamLocal, int localScore, string teamVisitor, int visitorScore)
    {
        this.TeamLocal = teamLocal;
        this.LocalScore = localScore;
        this.TeamVisitor = teamVisitor;
        this.VisitorScore = visitorScore;       
    }
   
}