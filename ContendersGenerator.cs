using PrincessProblem.model;

namespace PrincessProblem;

public static class ContendersGenerator
{
    public static Contender[]  GenerateContenders()
    {
        var names = File.ReadAllLines("C:/Users/Senya/RiderProjects/C#/lab1/res/names.txt");

        var contenders = new Contender[names.Length];

        const int numberContenders = 100;

        for (var i = 0; i < numberContenders; i++)
        {
            contenders[i] = new Contender(names[i], i + 1);
        }
        
        var random = new Random();
        
        contenders = contenders.OrderBy(x => random.Next()).ToArray();
        
        return contenders;
    }
}