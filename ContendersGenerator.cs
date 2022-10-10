using lab1.model;

namespace lab1;

public static class ContendersGenerator
{
    private static void ShuffleContenders(Contender[] arr)
    {
        var rand = new Random();
     
        for (var i = arr.Length - 1; i >= 1; i--)
        {
            var j = rand.Next(i + 1);
     
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }
    }
    
    public static Contender[]  GenerateContenders()
    {
        var names = File.ReadAllLines("C:/Users/Senya/RiderProjects/C#/lab1/res/names.txt");

        var contenders = new Contender[names.Length];

        for (var i = 0; i < names.Length; i++)
        {
            contenders[i] = new Contender(names[i], i + 1);
        }

        ShuffleContenders(contenders);
        return contenders;
    }
}