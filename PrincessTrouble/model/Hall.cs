namespace PrincessTrouble.model;

public class Hall
{
    private readonly IContendersGenerator _contendersGenerator;

    private Contender[] _allContenders;

    private int СontendersNumberWhoVisitedPrincess { get; set; }

    public Hall(IContendersGenerator contendersGenerator)
    {
        _contendersGenerator = contendersGenerator;
        СontendersNumberWhoVisitedPrincess = 0;
    }

    public void GenerateContenders()
    {
        _allContenders = _contendersGenerator.GenerateContenders();
    }

    public void SkipContenders(int numberSkippedContenders)
    {
        СontendersNumberWhoVisitedPrincess = numberSkippedContenders;
    }

    public void PrintListVisitedContenders()
    {
        Console.WriteLine("Список участвовавших в отборе!");
        foreach (var contender in _allContenders[..СontendersNumberWhoVisitedPrincess])
            Console.WriteLine($"Имя: {contender.Name} и насколько он хорош: {contender.Score}");
    }

    public IContender PeekContender(int visitNumber)
    {
        if (visitNumber < СontendersNumberWhoVisitedPrincess) return _allContenders[visitNumber];

        throw new Exception(Resourses.PeekContenderOutOfTurnException);
    }

    public IContender VisitContender(int visitNumber)
    {
        if (visitNumber == СontendersNumberWhoVisitedPrincess)
        {
            СontendersNumberWhoVisitedPrincess++;
            return _allContenders[visitNumber];
        }

        throw new Exception(Resourses.NobodyInHallException);
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

        throw new Exception(Resourses.GetScoreContenderWhoNotVisit);
    }
}