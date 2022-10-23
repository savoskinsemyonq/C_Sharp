namespace PrincessProblem.model;

public class Hall
{
    private readonly Contender[] _allContenders;

    public Hall(Contender[] contenders)
    {
        _allContenders = contenders;
    }

    public Contender[] ReturnListContenders(int contendersNumberWhoVisitedPrincess)
    {
        return _allContenders[..contendersNumberWhoVisitedPrincess];
    }

    public Contender PeekContender(int visitNumber)
    {
        return _allContenders[visitNumber];
    }

    public bool IsContenderVisitedPrincess(Contender contender, int contendersNumberWhoVisitedPrincess)
    {
        var whoVisited = _allContenders[..(contendersNumberWhoVisitedPrincess + 1)];
        return Array.Exists(whoVisited, cont => cont.Name.Equals(contender.Name));
    }

    public int GetContenderScore(string contenderName, int contendersNumberWhoVisitedPrincess)
    {
        var whoVisited = _allContenders[..contendersNumberWhoVisitedPrincess];
        var contender = Array.Find(whoVisited, cont => cont.Name.Equals(contenderName));
        if (contender != null)
        {
            return contender.Score;
        }

        throw new Exception("Trying get contender score, who didn't meet princess");
    }
}