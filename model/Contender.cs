namespace lab1.model;

public class Contender : IContender
{
    public string Name { get; private set; } 
    int IContender.Score { get; set; }

    public Contender(string name, int score)
    {
        Name = name;
        ((IContender)this).Score = score;
    }
}