using PrincessTrouble;
using FluentAssertions;
using PrincessTrouble.model;

namespace PrincessTroubleTest;

public class HallTests
{
    private ContendersGenerator _contendersGenerator;

    private Hall _hall;

    private IContender contender1;

    private IContender contender2;

    private Contender[] contenders = { new Contender(name: "Ivan", score: 1), new Contender(name: "Petr", score: 2) };

    [SetUp]
    public void Setup()
    {
        _contendersGenerator = new ContendersGenerator();
        _hall = new Hall(_contendersGenerator);
        _hall.GenerateContenders(contenders);
        contender1 = _hall.VisitContender(0);
    }

    [Test]
    public void CallNextContender_ReturnNextContender()
    {
        contender2 = _hall.VisitContender(1);
        Assert.That(contender2, Is.EqualTo(contenders[1]));
    }

    [Test]
    public void CallNextContender_ThrowExceptionNoMoreContendersInHall()
    {
        _hall.SkipContenders(contenders.Length);
        var act = () => _hall.VisitContender(contenders.Length + 1);
        act.Should().Throw<Exception>()
            .WithMessage("Princess trying to visit contender out of turn! Nobody in hall!");
    }
}