namespace PrincessProblem.model;

public class Hall
{
    private int _contendersNumberWhoVisitedPrincess;
    
    private readonly Contender[] _allContenders;
    
    public Hall(Contender[] contenders)
    {
        _allContenders = contenders;
        _contendersNumberWhoVisitedPrincess = 0;
    }

    public void RememberNumberContenders(int contendersNumberWhoVisitedPrincess)
    {
        _contendersNumberWhoVisitedPrincess = contendersNumberWhoVisitedPrincess;
    }

    public Contender[] ReturnListContenders()
    {
        return _allContenders[.._contendersNumberWhoVisitedPrincess];
    }

    public Contender PeekContender(int visitNumber)
    {
        return _allContenders[visitNumber];
    }

    public int GetContendersNumberWhoVisitedPrincess()
    {
        return _contendersNumberWhoVisitedPrincess;
    }

    public bool IsContenderVisitedPrincess(Contender contender)
    {
        return Array.IndexOf(_allContenders, contender) <= _contendersNumberWhoVisitedPrincess;
    }
}