
public class Match {
    public string TeamLocal { get; private set; }
    public int LocalScore { get; private set; }
    public string TeamVisitor { get; private set; }
    public int VisitorScore { get; private set; }
    public int VisitorPoints { get; private set; }
    public int LocalPoints { get; private set; }

    public Match(string teamLocal, int localScore, string teamVisitor, int visitorScore)
    {
        this.TeamLocal = teamLocal;
        this.LocalScore = localScore;
        this.TeamVisitor = teamVisitor;
        this.VisitorScore = visitorScore;
        calculatePoints();

    }

    private void calculatePoints()
    {
        if (LocalScore == VisitorScore)
        {
            VisitorPoints = 1;
            LocalPoints = 1;
        }
        else if (LocalScore > VisitorScore)
        {
            LocalPoints = 3;
            VisitorPoints = 0;
        } else
        {
            LocalPoints = 0;
            VisitorPoints = 3;
        }
    }
}