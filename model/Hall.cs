namespace lab1.model;

public class Hall
{
    public int NumberContendersVisitedPrincess { get; set; }
    public Contender[] AllContenders { get; private set; }
    public Hall(Contender[] contenders)
    {
        AllContenders = contenders;
        NumberContendersVisitedPrincess = 0;
    }

    public Contender[] ReturnListContenders()
    {
        return AllContenders[..NumberContendersVisitedPrincess];
    }
}