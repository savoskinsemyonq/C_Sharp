using PrincessTrouble;
using FluentAssertions;
using PrincessTrouble.model;
using Moq;

namespace PrincessTroubleTest;

public class HallTests
{
    private Hall _hall;

    private Contender[] _contenders = { new Contender(name: "Ivan", score: 1), new Contender(name: "Petr", score: 2) };

    private Mock<IContendersGenerator> _mockContenderGenerator;

    [SetUp]
    public void Setup()
    {
        _mockContenderGenerator = new Mock<IContendersGenerator>();
        _hall = new Hall(_mockContenderGenerator.Object);
    }

    [Test]
    public void VisitNextContender_ReturnNextContender()
    {
        GenerateContendersAndMakeTheFirstContenderVisited();
        var contenderWhoShouldVisit = _hall.VisitContender(1);
        var nextContender = _contenders[1].Name;
        contenderWhoShouldVisit.Name.Should().Be(nextContender);
    }

    [Test]
    public void PeekCurrentContender_ReturnCurrentContender()
    {
        GenerateContendersAndMakeTheFirstContenderVisited();
        var currentContender = _hall.PeekContender(0);
        var realCurrentContender = _contenders[0].Name;
        currentContender.Name.Should().Be(realCurrentContender);
    }

    [Test]
    public void PeekCurrentContender_ThrowExceptionPeekContenderOutOfTurn()
    {
        GenerateContendersAndMakeTheFirstContenderVisited();
        var act = () => _hall.PeekContender(1);
        act.Should().Throw<Exception>()
            .WithMessage(Resourses.PeekContenderOutOfTurnException);
    }

    [Test]
    public void CallNextContender_ThrowExceptionNoMoreContendersInHall()
    {
        GenerateContendersAndMakeTheFirstContenderVisited();
        _hall.SkipContenders(_contenders.Length);
        var act = () => _hall.VisitContender(_contenders.Length + 1);
        act.Should().Throw<Exception>()
            .WithMessage(Resourses.NobodyInHallException);
    }

    [Test]
    public void GetContenderScore_ReturnContenderScore()
    {
        GenerateContendersAndMakeTheFirstContenderVisited();
        var contender = _hall.PeekContender(0);
        var score = _hall.GetContenderScore(contender.Name);
        score.Should().Be(_contenders[0].Score);
    }

    [Test]
    public void GetContenderScore_ThrowExceptionGetScoreContenderWhoNotVisit()
    {
        GenerateContendersAndMakeTheFirstContenderVisited();
        var act = () => _hall.GetContenderScore(_contenders[1].Name);
        act.Should().Throw<Exception>()
            .WithMessage(Resourses.GetScoreContenderWhoNotVisit);
    }

    [Test]
    public void CheckContenderVisit_ReturnIsContenderVisitTrue()
    {
        GenerateContendersAndMakeTheFirstContenderVisited();
        var contenderWhoVisited = _contenders[0];
        _hall.IsContenderVisitedPrincess(contenderWhoVisited).Should().BeTrue();
    }

    [Test]
    public void CheckContenderVisit_ReturnIsContenderVisitFalse()
    {
        GenerateContendersAndMakeTheFirstContenderVisited();
        var contenderWhoNotVisited = _contenders[1];
        _hall.IsContenderVisitedPrincess(contenderWhoNotVisited).Should().BeFalse();
    }

    private void GenerateContendersAndMakeTheFirstContenderVisited()
    {
        _mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.GenerateContenders())
            .Returns(_contenders);
        _hall.GenerateContenders();
        _hall.VisitContender(0);
    }
}