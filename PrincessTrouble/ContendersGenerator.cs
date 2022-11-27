using PrincessTrouble.model;

namespace PrincessTrouble;

public class ContendersGenerator
{
    public Contender[] GenerateContenders()
    {
        var hundredUniqueNames = File.ReadAllLines("C:/Users/Senya/RiderProjects/Princess/PrincessTrouble/res/names.txt");
        var contenders = new Contender[hundredUniqueNames.Length];

        const int numberContenders = 100;

        for (var i = 0; i < numberContenders; i++) contenders[i] = new Contender(hundredUniqueNames[i], i + 1);

        var random = new Random();

        contenders = contenders.OrderBy(x => random.Next()).ToArray();
        return contenders;
    }
}