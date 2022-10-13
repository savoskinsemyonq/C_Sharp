namespace PrincessProblem.model;

public class Contender : IContender
{
    public string Name { get;  private set; } 
    
    public int Score { get; private set; }

    public Contender(string name, int score)
    {
        Name = name;
        Score = score;
    }
}