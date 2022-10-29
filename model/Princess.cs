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
        var numberLastContender = 25;
        IContender? chosenContender;
        while (numberLastContender < NumberAllContenders)
        {
            //new contender go to princess
            var countSuccessCompare = 0;
            for (var i = 0; i < numberLastContender; i++)
            {
                var winner = _princessFriend.CompareContenders(_hallOfContenders.PeekContender(i),
                    _hallOfContenders.PeekContender(numberLastContender));
                if (winner == _hallOfContenders.PeekContender(numberLastContender))
                {
                    countSuccessCompare++;
                }
            }

            //magic threshold for choose good contender
            var successThreshold = 24 + (numberLastContender - 25) / 2;
            if (countSuccessCompare > successThreshold)
            {
                chosenContender = _hallOfContenders.PeekContender(numberLastContender);
                return chosenContender;
            }

            numberLastContender += 1;
        }

        //not find contender
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
            var score = _hallOfContenders.GetContenderScore(chosenContenderName);
            Happiness = score < ThresholdGoodContender ? 0 : score;
        }
    }
}