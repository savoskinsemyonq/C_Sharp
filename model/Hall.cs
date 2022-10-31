namespace PrincessProblem.model;

public class Hall
{
    private readonly Contender[] _allContenders;

    public int СontendersNumberWhoVisitedPrincess { get; private set; }

    public Hall(Contender[] contenders)
    {
        _allContenders = contenders;
        СontendersNumberWhoVisitedPrincess = Constants.NumberSkippedContenders;
    }

    public IContender PeekContender(int visitNumber)
    {
        if (visitNumber - СontendersNumberWhoVisitedPrincess == 1)
        {
            СontendersNumberWhoVisitedPrincess++;
        }

        if (visitNumber <= СontendersNumberWhoVisitedPrincess)
        {
            return _allContenders[visitNumber];
        }

        throw new Exception("Princess trying to peek contender, who didn't visit princess!");
    }

    public bool IsContenderVisitedPrincess(IContender contender)
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