using PrincessTrouble;
using FluentAssertions;
using PrincessTrouble.model;

namespace PrincessTroubleTest;

public class FriendTests
{
    private Friend _friend;

    private Hall _hall;

    private ContendersGenerator _contendersGenerator;

    private IContender contender1;

    private IContender contender2;

    private Contender[] contenders = { new Contender(name: "Ivan", score: 1), new Contender(name: "Petr", score: 2) };

    [SetUp]
    public void Setup()
    {
        _contendersGenerator = new ContendersGenerator();
        _hall = new Hall(_contendersGenerator);
        _friend = new Friend(_hall);
        _hall.GenerateContenders(contenders);
        contender1 = _hall.VisitContender(0);
    }

    [Test]
    public void CompareTwoContenders_ReturnsTheBest()
    {
        contender2 = _hall.VisitContender(1);
        var bestContender = _friend.CompareContenders(contender1, contender2);
        Assert.That(bestContender, Is.EqualTo(contender2));
    }

    [Test]
    public void CompareTwoContenders_WhenContendersDidNotMetPrincess_ThrowException()
    {
        contender2 = contenders[1];
        var act = () => _friend.CompareContenders(contender1, contender2);
        act.Should().Throw<Exception>()
            .WithMessage("Friend trying to compare contenders, who didn't meet princess");
    }
}