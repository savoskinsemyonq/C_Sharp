using PrincessTrouble;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
using PrincessTrouble.model;

namespace PrincessTroubleTest;

public class PrincessTests
{
    private const int NumberOfContenders = 100;

    private const int HappinessIfNoContender = 10;

    private const int HappinessIfFirst = 20;

    private const int HappinessIfThird = 50;

    private const int HappinessIfAnother = 0;

    private const int HappinessIfFifth = 100;

    private ContendersGenerator _contendersGenerator;

    private Hall _hall;

    private Princess _princess;

    private Friend _friend;

    private IHostApplicationLifetime _appLifetime;

    private IContender? chosenContender;

    private Contender[] contenders;

    [SetUp]
    public void Setup()
    {
        _contendersGenerator = new ContendersGenerator();
        _hall = new Hall(_contendersGenerator);
        _friend = new Friend(_hall);
        _princess = new Princess(_hall, _friend, _appLifetime);
    }

    [Test]
    public void PrincessChoose_IfTheFifthContender_ShouldHaveHappiness100()
    {
        contenders = GenerateContendersForPrincessHappiness100();
        _hall.GenerateContenders(contenders);
        chosenContender = _princess.ChooseContender();
        _princess.CountHappiness(chosenContender?.Name);
        Assert.That(_princess.Happiness, Is.EqualTo(HappinessIfFifth));
    }

    [Test]
    public void PrincessChoose_IfTheThirdContender_ShouldHaveHappiness50()
    {
        contenders = GenerateContendersForPrincessHappiness50();
        _hall.GenerateContenders(contenders);
        chosenContender = _princess.ChooseContender();
        _princess.CountHappiness(chosenContender?.Name);
        Assert.That(_princess.Happiness, Is.EqualTo(HappinessIfThird));
    }

    [Test]
    public void PrincessChoose_IfTheFirstContender_ShouldHaveHappiness20()
    {
        contenders = GenerateContendersForPrincessHappiness20();
        _hall.GenerateContenders(contenders);
        chosenContender = _princess.ChooseContender();
        _princess.CountHappiness(chosenContender?.Name);
        Assert.That(_princess.Happiness, Is.EqualTo(HappinessIfFirst));
    }

    [Test]
    public void PrincessChoose_IfAnotherContender_ShouldHaveHappiness0()
    {
        contenders = GenerateContendersForPrincessHappiness0();
        _hall.GenerateContenders(contenders);
        chosenContender = _princess.ChooseContender();
        _princess.CountHappiness(chosenContender?.Name);
        Assert.That(_princess.Happiness, Is.EqualTo(HappinessIfAnother));
    }

    [Test]
    public void PrincessChoose_IfNobodyChoose_ShouldHaveHappiness10()
    {
        contenders = GenerateContendersForAlonePrincess();
        _hall.GenerateContenders(contenders);
        chosenContender = _princess.ChooseContender();
        _princess.CountHappiness(chosenContender?.Name);
        Assert.That(_princess.Happiness, Is.EqualTo(HappinessIfNoContender));
    }

    [Test]
    public void CallNextContender_ThrowExceptionNoMoreContendersInHall()
    {
        contenders = GenerateContendersForAlonePrincess();
        _hall.SkipContenders(NumberOfContenders);
        var act = () => _hall.VisitContender(NumberOfContenders + 1);
        act.Should().Throw<Exception>()
            .WithMessage("Princess trying to visit contender out of turn! Nobody in hall!");
    }

    private static Contender[] GenerateContendersForAlonePrincess()
    {
        var contenders = new Contender[NumberOfContenders];
        for (var i = NumberOfContenders - 1; i > -1; i--)
        {
            contenders[NumberOfContenders - i - 1] = new Contender(name: "Contender" + (i + 1), score: i + 1);
        }

        return contenders;
    }

    private static Contender[] GenerateContendersForPrincessHappiness20()
    {
        var contenders = new Contender[NumberOfContenders];
        for (var i = NumberOfContenders - 1; i > -1; i--)
        {
            if (i == 49)
            {
                contenders[i] = new Contender(name: "Contender" + 100, score: 100);
            }
            else if (i == 95)
            {
                contenders[i] = new Contender(name: "Contender" + 50, score: 50);
            }

            //starts fill contenders with 95, 99-96 in the end
            contenders[NumberOfContenders - i - 1] = new Contender(name: "Contender" + ((i + 1 - 5 + 100) % 100),
                score: (i + 1 - 5 + 100) % 100);
        }

        return contenders;
    }

    private static Contender[] GenerateContendersForPrincessHappiness50()
    {
        var contenders = new Contender[NumberOfContenders];
        for (var i = NumberOfContenders - 1; i > -1; i--)
        {
            if (i == 49)
            {
                contenders[i] = new Contender(name: "Contender" + 98, score: 98);
            }
            else if (i == 97)
            {
                contenders[i] = new Contender(name: "Contender" + 50, score: 50);
            }

            //starts fill contenders with 95, 99-96 in the end
            contenders[NumberOfContenders - i - 1] = new Contender(name: "Contender" + ((i + 1 - 5 + 100) % 100),
                score: (i + 1 - 5 + 100) % 100);
        }

        return contenders;
    }

    private static Contender[] GenerateContendersForPrincessHappiness100()
    {
        var contenders = new Contender[NumberOfContenders];
        for (var i = NumberOfContenders - 1; i > -1; i--)
        {
            if (i == 49)
            {
                contenders[i] = new Contender(name: "Contender" + 96, score: 96);
            }
            else if (i == 99)
            {
                contenders[i] = new Contender(name: "Contender" + 50, score: 50);
            }

            //starts fill contenders with 95, 99-96 in the end
            contenders[NumberOfContenders - i - 1] = new Contender(name: "Contender" + ((i + 1 - 5 + 100) % 100),
                score: (i + 1 - 5 + 100) % 100);
        }

        return contenders;
    }

    private static Contender[] GenerateContendersForPrincessHappiness0()
    {
        var contenders = new Contender[NumberOfContenders];
        for (var i = 0; i < NumberOfContenders; i++)
        {
            contenders[i] = new Contender(name: "Contender" + (i + 1), score: i + 1);
        }

        return contenders;
    }
}