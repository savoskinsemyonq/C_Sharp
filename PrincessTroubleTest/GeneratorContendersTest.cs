using PrincessTrouble;
using FluentAssertions;

namespace PrincessTroubleTest;

public class ContendersGeneratorTests
{
    private ContendersGenerator _contendersGenerator;

    [SetUp]
    public void Setup()
    {
        _contendersGenerator = new ContendersGenerator();
    }

    [Test]
    public void GenerateContenders_ShouldBeUniqueNames()
    {
        var contrnders = _contendersGenerator.GenerateContenders();
        var contenders_names = contrnders.Select(contender => contender.Name);
        contenders_names.Should().OnlyHaveUniqueItems();
    }
}