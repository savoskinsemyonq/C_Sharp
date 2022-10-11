namespace PrincessProblem.model;

public class Princess
{
    private Friend PrincessFriend { get; set; }
    
    private Hall HallOfContenders { get; set; }
    
    public int Happiness { get; private set; }
    
    public Princess(Hall hall, Friend friend)
    {
        HallOfContenders = hall;
        PrincessFriend = friend;
    }

    public Contender? ChooseContender()
    {
        //25 contenders skipped
        var numContendersVisited = 25;
        Contender? chosenContender;
        while (numContendersVisited < HallOfContenders.AllContenders.Length)
        {
            var countSuccessCompare = 0;
            for (var i = 0; i < numContendersVisited; i++)
            {
                var winner = PrincessFriend.CompareContenders(HallOfContenders.AllContenders[i], HallOfContenders.AllContenders[numContendersVisited]);
                if (winner == HallOfContenders.AllContenders[numContendersVisited])
                {
                    countSuccessCompare++;
                }
            }
            //magic threshold for choose good contender
            var successThreshold = 24 + (numContendersVisited - 25) / 2;
            if (countSuccessCompare > successThreshold)
            {
                chosenContender = HallOfContenders.AllContenders[numContendersVisited];
                HallOfContenders.RememberNumberContenders(numContendersVisited + 1);
                return chosenContender;
            }
            numContendersVisited++;
        }
        //not find contender
        HallOfContenders.RememberNumberContenders(numContendersVisited);
        chosenContender = null;
        return chosenContender;
    }

    private const int HappinessIfNoContender = 10;
    
    private const int ThresholdGoodContender = 51;
    
    public void CountHappiness(IContender? chosenContender)
    {
        Happiness = chosenContender is null ? HappinessIfNoContender : chosenContender.Score < ThresholdGoodContender ? 0 : chosenContender.Score;
    }
}