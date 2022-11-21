namespace PrincessProblem.model;

public class Hall
{
    private readonly ContendersGenerator _contendersGenerator;
    private Contender[] _allContenders;

    public Hall(ContendersGenerator contendersGenerator)
    {
        _contendersGenerator = contendersGenerator;
        СontendersNumberWhoVisitedPrincess = Constants.NumberSkippedContenders;
    }

    private int СontendersNumberWhoVisitedPrincess { get; set; }

    public void GenerateContenders()
    {
        _allContenders = _contendersGenerator.GenerateContenders();
    }

    public void PrintListVisitedContenders()
    {
        Console.WriteLine("Список участвовавших в отборе!");
        foreach (var contender in _allContenders[..СontendersNumberWhoVisitedPrincess])
            Console.WriteLine($"Имя: {contender.Name} и насколько он хорош: {contender.Score}");
    }

    public IContender PeekContender(int visitNumber)
    {
        if (visitNumber <= СontendersNumberWhoVisitedPrincess) return _allContenders[visitNumber];

        throw new Exception("Princess trying to peek contender, who didn't visit princess!");
    }

    public IContender VisitContender(int visitNumber)
    {
        if (visitNumber == СontendersNumberWhoVisitedPrincess)
        {
            СontendersNumberWhoVisitedPrincess++;
            return _allContenders[visitNumber];
        }

        throw new Exception("Princess trying to visit contender out of turn!");
    }

    public bool IsContenderVisitedPrincess(IContender contender)
    {
        var whoVisited = _allContenders[..СontendersNumberWhoVisitedPrincess];
        return Array.Exists(whoVisited, cont => cont.Name.Equals(contender.Name));
    }

    public int GetContenderScore(string contenderName)
    {
        var whoVisited = _allContenders[..СontendersNumberWhoVisitedPrincess];
        var contender = Array.Find(whoVisited, cont => cont.Name.Equals(contenderName));
        if (contender != null) return contender.Score;

        throw new Exception("Trying get contender score, who didn't meet princess");
    }
}