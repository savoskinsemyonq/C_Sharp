using PrincessTrouble;
using FluentAssertions;
using PrincessTrouble.model;
using Moq;

namespace PrincessTroubleTest;

public class HallTests
{
    private Hall _hall;

    private Contender[] _contenders = { new Contender(name: "Ivan", score: 1), new Contender(name: "Petr", score: 2) };

    [SetUp]
    public void Setup()
    {
        var mockContenderGenerator = new Mock<IContendersGenerator>();
        mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.GenerateContenders())
            .Returns(_contenders);
        _hall = new Hall(mockContenderGenerator.Object);
        _hall.GenerateContenders();
        _hall.VisitContender(0);
    }

    [Test]
    public void CallNextContender_ReturnNextContender()
    {
        var contender2 = _hall.VisitContender(1);
        contender2.Name.Should().Be(_contenders[1].Name);
    }

    [Test]
    public void CallCurrentContender_ReturnCurrentContender()
    {
        var contender2 = _hall.PeekContender(0);
        contender2.Name.Should().Be(_contenders[0].Name);
    }

    [Test]
    public void CallCurrentContender_ThrowExceptionPeekContenderOutOfTurn()
    {
        var act = () => _hall.PeekContender(1);
        act.Should().Throw<Exception>()
            .WithMessage(Resourses.PeekContenderOutOfTurnException);
    }

    [Test]
    public void CallNextContender_ThrowExceptionNoMoreContendersInHall()
    {
        _hall.SkipContenders(_contenders.Length);
        var act = () => _hall.VisitContender(_contenders.Length + 1);
        act.Should().Throw<Exception>()
            .WithMessage(Resourses.NobodyInHallException);
    }

    [Test]
    public void GetContenderScore_ReturnContenderScore()
    {
        var contender1 = _hall.PeekContender(0);
        var score = _hall.GetContenderScore(contender1.Name);
        score.Should().Be(_contenders[0].Score);
    }

    [Test]
    public void GetContenderScore_ThrowExceptionGetScoreContenderWhoNotVisit()
    {
        var act = () => _hall.GetContenderScore(_contenders[1].Name);
        act.Should().Throw<Exception>()
            .WithMessage(Resourses.GetScoreContenderWhoNotVisit);
    }

    [Test]
    public void CheckContenderVisit_ReturnIsContenderVisitTrue()
    {
        _hall.IsContenderVisitedPrincess(_contenders[0]).Should().BeTrue();
    }

    [Test]
    public void CheckContenderVisit_ReturnIsContenderVisitFalse()
    {
        _hall.IsContenderVisitedPrincess(_contenders[1]).Should().BeFalse();
    }
}