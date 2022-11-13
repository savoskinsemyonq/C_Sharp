using Microsoft.Extensions.Hosting;

namespace PrincessProblem.model;

public class Princess : IHostedService
{
    private readonly Friend _princessFriend;

    private readonly Hall _hallOfContenders;

    private readonly IHostApplicationLifetime _appLifetime;

    private const int HappinessIfNoContender = 10;

    private const int ThresholdGoodContender = 51;

    private const int NumberAllContenders = 100;

    public int Happiness { get; private set; }

    public Princess(Hall hall, Friend friend, IHostApplicationLifetime appLifetime)
    {
        _hallOfContenders = hall;
        _princessFriend = friend;
        _appLifetime = appLifetime;
    }

    public IContender? ChooseContender()
    {
        //contenders skipped
        var numberLastContender = Constants.NumberSkippedContenders;
        IContender? chosenContender;
        while (numberLastContender < NumberAllContenders)
        {
            //new contender go to princess
            var countSuccessCompare = 0;
            var currentContender = _hallOfContenders.VisitContender(numberLastContender);
            for (var i = 0; i < numberLastContender; i++)
            {
                var winner = _princessFriend.CompareContenders(_hallOfContenders.PeekContender(i),
                    currentContender);
                if (winner == currentContender)
                {
                    countSuccessCompare++;
                }
            }

            //magic threshold for choose good contender
            var successThreshold = 24 + (numberLastContender - 25) / 2;
            if (countSuccessCompare > successThreshold)
            {
                chosenContender = currentContender;
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

    private void PrintPrincessHappiness()
    {
        Console.WriteLine("---");
        Console.WriteLine($"Принцесса счастлива на {Happiness}/100");
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Task.Run(RunAsync, cancellationToken);
        return Task.CompletedTask;
    }

    public void RunAsync()
    {
        _hallOfContenders.GenerateContenders();
        var chosenContender = ChooseContender();
        CountHappiness(chosenContender?.Name);
        _hallOfContenders.PrintListVisitedContenders();
        PrintPrincessHappiness();
        _appLifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}