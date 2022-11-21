using Microsoft.Extensions.Hosting;

namespace PrincessProblem.model;

public class Princess : IHostedService
{
    private const int HappinessIfNoContender = 10;

    private const int HappinessIfFirst = 20;

    private const int HappinessIfThird = 50;

    private const int HappinessIfFifth = 100;

    private const int NumberAllContenders = 100;

    private readonly IHostApplicationLifetime _appLifetime;

    private readonly Hall _hallOfContenders;
    private readonly Friend _princessFriend;

    public Princess(Hall hall, Friend friend, IHostApplicationLifetime appLifetime)
    {
        _hallOfContenders = hall;
        _princessFriend = friend;
        _appLifetime = appLifetime;
    }

    public int Happiness { get; private set; }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Task.Run(RunAsync, cancellationToken);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
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
                if (winner == currentContender) countSuccessCompare++;
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
            switch (score)
            {
                case 100:
                    Happiness = HappinessIfFirst;
                    break;
                case 98:
                    Happiness = HappinessIfThird;
                    break;
                case 96:
                    Happiness = HappinessIfFifth;
                    break;
                default:
                    Happiness = 0;
                    break;
            }
        }
    }

    private void PrintPrincessHappiness()
    {
        Console.WriteLine("---");
        Console.WriteLine($"Принцесса счастлива на {Happiness}/100");
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
}