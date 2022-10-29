namespace PrincessProblem.model;

public class Hall
{
    private readonly Contender[] _allContenders;

    public int СontendersNumberWhoVisitedPrincess { get; private set; }

    public Hall(Contender[] contenders)
    {
        _allContenders = contenders;
    }

    public Contender PeekContender(int visitNumber)
    {
        if (visitNumber > СontendersNumberWhoVisitedPrincess)
        {
            СontendersNumberWhoVisitedPrincess = visitNumber;
        }

        return _allContenders[visitNumber];
    }

    public bool IsContenderVisitedPrincess(Contender contender)
    {
        var whoVisited = _allContenders[..(СontendersNumberWhoVisitedPrincess + 1)];
        return Array.Exists(whoVisited, cont => cont.Name.Equals(contender.Name));
    }

    public int GetContenderScore(string contenderName)
    {
        var whoVisited = _allContenders[..(СontendersNumberWhoVisitedPrincess + 1)];
        var contender = Array.Find(whoVisited, cont => cont.Name.Equals(contenderName));
        if (contender != null)
        {
            return contender.Score;
        }

        throw new Exception("Trying get contender score, who didn't meet princess");
    }
}