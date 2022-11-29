using PrincessTrouble;
using FluentAssertions;
using PrincessTrouble.model;
using Moq;

namespace PrincessTroubleTest;

public class FriendTests
{
    private Friend _friend;

    private Hall _hall;

    private Contender[] _contenders = { new Contender(name: "Ivan", score: 1), new Contender(name: "Petr", score: 2) };
    
    private Mock<IContendersGenerator> _mockContenderGenerator;

    [SetUp]
    public void Setup()
    {
        _mockContenderGenerator = new Mock<IContendersGenerator>();
        _hall = new Hall(_mockContenderGenerator.Object);
        _friend = new Friend(_hall);
    }

    [Test]
    public void CompareTwoContenders_ReturnsTheBest()
    {
        _mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.GenerateContenders())
            .Returns(_contenders);
        _hall.GenerateContenders();
        var worseContender = _hall.VisitContender(0);
        var betterContender = _hall.VisitContender(1);
        var bestContender = _friend.CompareContenders(worseContender, betterContender);
        bestContender.Name.Should().Be(bestContender.Name);
    }

    [Test]
    public void CompareTwoContenders_WhenContendersDidNotMetPrincess_ThrowException()
    {
        _mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.GenerateContenders())
            .Returns(_contenders);
        _hall.GenerateContenders();
        var worseContenderWhoVisited = _hall.VisitContender(0);
        var betterContenderWhoDidNotVisited = _contenders[1];
        var act = () => _friend.CompareContenders(worseContenderWhoVisited, betterContenderWhoDidNotVisited);
        act.Should().Throw<Exception>()
            .WithMessage(Resourses.FriendCompareContendersException);
    }
}