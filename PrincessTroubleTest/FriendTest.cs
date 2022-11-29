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

    [SetUp]
    public void Setup()
    {
        var mockContenderGenerator = new Mock<IContendersGenerator>();
        mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.GenerateContenders())
            .Returns(_contenders);
        _hall = new Hall(mockContenderGenerator.Object);
        _friend = new Friend(_hall);
        _hall.GenerateContenders();
    }

    [Test]
    public void CompareTwoContenders_ReturnsTheBest()
    {
        var contender1 = _hall.VisitContender(0);
        var contender2 = _hall.VisitContender(1);
        var bestContender = _friend.CompareContenders(contender1, contender2);
        bestContender.Name.Should().Be(contender2.Name);
    }

    [Test]
    public void CompareTwoContenders_WhenContendersDidNotMetPrincess_ThrowException()
    {
        var contender1 = _hall.VisitContender(0);
        var contender2 = _contenders[1];
        var act = () => _friend.CompareContenders(contender1, contender2);
        act.Should().Throw<Exception>()
            .WithMessage(Resourses.FriendCompareContendersException);
    }
}