namespace lab1.model;

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

    public Contender? ChooseContenderStrategy()
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

            var successThreshold = 24 + (numContendersVisited - 25) / 2;
            if (countSuccessCompare > successThreshold )
            {
                chosenContender = HallOfContenders.AllContenders[numContendersVisited];
                HallOfContenders.NumberContendersVisitedPrincess = numContendersVisited+1;
                Happiness = PrincessFriend.HelpCountHappiness(chosenContender);
                return chosenContender;
            }
            numContendersVisited++;
        }
        //not find contender
        HallOfContenders.NumberContendersVisitedPrincess = HallOfContenders.AllContenders.Length;
        chosenContender = null;
        Happiness = 10; 
        return chosenContender;
    }
}