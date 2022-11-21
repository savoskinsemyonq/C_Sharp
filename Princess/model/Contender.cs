namespace PrincessProblem.model;

public class Contender : IContender
{
    public Contender(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public int Score { get; }
    public string Name { get; }
}