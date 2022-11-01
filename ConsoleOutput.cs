using PrincessProblem.model;

namespace PrincessProblem;

public static class ConsoleOutput
{
    public static void PrintListVisitedContenders(Contender[] contenders)
    {
        Console.WriteLine("Список участвовавших в отборе!");
        foreach (var contender in contenders)
        {
            Console.WriteLine($"Имя: {contender.Name} и насколько он хорош: {contender.Score}");
        }
    }

    public static void PrintPrincessHappiness(int happiness)
    {
        Console.WriteLine("---");
        Console.WriteLine($"Принцесса счастлива на {happiness}/100");
    }
}