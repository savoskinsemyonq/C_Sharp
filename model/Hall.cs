namespace PrincessProblem.model;

public class Hall
{
    public int ContendersNumberWhoVisitedPrincess { get; private set; }
    
    public Contender[] AllContenders { get; private set; }
    
    public Hall(Contender[] contenders)
    {
        AllContenders = contenders;
        ContendersNumberWhoVisitedPrincess = 0;
    }

    public void RememberNumberContenders(int contendersNumberWhoVisitedPrincess)
    {
        ContendersNumberWhoVisitedPrincess=contendersNumberWhoVisitedPrincess;
    }

    public Contender[] ReturnListContenders()
    {
        return AllContenders[..ContendersNumberWhoVisitedPrincess];
    }
}