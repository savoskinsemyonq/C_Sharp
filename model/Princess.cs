namespace PrincessProblem.model;

public class Princess
{
    private readonly Friend _princessFriend;

    private readonly Hall _hallOfContenders;

    private const int HappinessIfNoContender = 10;

    private const int ThresholdGoodContender = 51;

    private const int NumberAllContenders = 100;

    public int СontendersNumberWhoVisitedPrincess { get; private set; }

    public int Happiness { get; private set; }

    public Princess(Hall hall, Friend friend)
    {
        _hallOfContenders = hall;
        _princessFriend = friend;
        СontendersNumberWhoVisitedPrincess = 0;
    }

    public IContender? ChooseContender()
    {
        //25 contenders skipped
        СontendersNumberWhoVisitedPrincess = 25;
        IContender? chosenContender;
        while (СontendersNumberWhoVisitedPrincess < NumberAllContenders)
        {
            //new contender go to princess
            var countSuccessCompare = 0;
            for (var i = 0; i < СontendersNumberWhoVisitedPrincess; i++)
            {
                var winner = _princessFriend.CompareContenders(_hallOfContenders.PeekContender(i),
                    _hallOfContenders.PeekContender(СontendersNumberWhoVisitedPrincess),
                    СontendersNumberWhoVisitedPrincess);
                if (winner == _hallOfContenders.PeekContender(СontendersNumberWhoVisitedPrincess))
                {
                    countSuccessCompare++;
                }
            }

            //magic threshold for choose good contender
            var successThreshold = 24 + (СontendersNumberWhoVisitedPrincess - 25) / 2;
            if (countSuccessCompare > successThreshold)
            {
                chosenContender = _hallOfContenders.PeekContender(СontendersNumberWhoVisitedPrincess);
                СontendersNumberWhoVisitedPrincess += 1;
                return chosenContender;
            }

            СontendersNumberWhoVisitedPrincess += 1;
        }

        //not find contender
        СontendersNumberWhoVisitedPrincess = NumberAllContenders;
        chosenContender = null;
        return chosenContender;
    }

    public void CountHappiness(string? chosenContenderName)
    {
        if (chosenContenderName is null)
        {
            Happiness = HappinessIfNoContender;
        }
        else
        {
            var score = _hallOfContenders.GetContenderScore(chosenContenderName, СontendersNumberWhoVisitedPrincess);
            Happiness = score < ThresholdGoodContender ? 0 : score;
        }
    }
}