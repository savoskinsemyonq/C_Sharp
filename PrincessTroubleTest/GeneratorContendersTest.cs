using PrincessTrouble;
using FluentAssertions;

namespace PrincessTroubleTest;

public class ContendersGeneratorTests
{
    private ContendersGenerator _contendersGenerator;

    private const int NumberOfContenders = 100;

    [SetUp]
    public void Setup()
    {
        _contendersGenerator = new ContendersGenerator();
    }

    [Test]
    public void GenerateContenders_ShouldBeUniqueNames()
    {
        var contenders = _contendersGenerator.GenerateContenders();
        var contendersNames = contenders.Select(contender => contender.Name);
        contendersNames.Should().OnlyHaveUniqueItems();
    }

    [Test]
    public void GenerateContenders_ShouldBe100Contenders()
    {
        var contenders = _contendersGenerator.GenerateContenders();
        contenders.Length.Should().Be(NumberOfContenders);
    }
}