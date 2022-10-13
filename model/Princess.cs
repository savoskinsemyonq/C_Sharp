namespace PrincessProblem.model;

public class Princess
{
    private readonly Friend _princessFriend;

    private readonly Hall _hallOfContenders;
    
    private const int HappinessIfNoContender = 10;
    
    private const int ThresholdGoodContender = 51;

    private const int NumberAllContenders = 100;
    
    public int Happiness { get; private set; }
    
    public Princess(Hall hall, Friend friend)
    {
        _hallOfContenders = hall;
        _princessFriend = friend;
    }

    public IContender? ChooseContender()
    {
        //25 contenders skipped
        var numContendersVisited = 25;
        _hallOfContenders.RememberNumberContenders(numContendersVisited);
        IContender? chosenContender;
        while (_hallOfContenders.GetContendersNumberWhoVisitedPrincess() < NumberAllContenders)
        {
            numContendersVisited = _hallOfContenders.GetContendersNumberWhoVisitedPrincess();
            var countSuccessCompare = 0;
            for (var i = 0; i < numContendersVisited; i++)
            {
                var winner = _princessFriend.CompareContenders(_hallOfContenders.PeekContender(i), _hallOfContenders.PeekContender(numContendersVisited));
                if (winner == _hallOfContenders.PeekContender(numContendersVisited))
                {
                    countSuccessCompare++;
                }
            }
            //magic threshold for choose good contender
            var successThreshold = 24 + (numContendersVisited - 25) / 2;
            if (countSuccessCompare > successThreshold)
            {
                chosenContender = _hallOfContenders.PeekContender(numContendersVisited);
                _hallOfContenders.RememberNumberContenders(numContendersVisited + 1);
                return chosenContender;
            }
            _hallOfContenders.RememberNumberContenders(numContendersVisited + 1);
        }
        //not find contender
        _hallOfContenders.RememberNumberContenders(numContendersVisited);
        chosenContender = null;
        return chosenContender;
    }
    
    public void CountHappiness(IContender? chosenContender)
    {
        if (chosenContender is null)
        {
            Happiness = HappinessIfNoContender;
        }
        else if(chosenContender is Contender contender)
        {
            Happiness=contender.Score < ThresholdGoodContender ? 0 : contender.Score;
        }
        else
        {
            throw new Exception("Princess choose bad contender and can't count happiness!");
        }
    }
}