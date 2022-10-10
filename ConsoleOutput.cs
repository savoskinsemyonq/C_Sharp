using lab1.model;

namespace lab1;

public static class ConsoleOutput
{
    public static void PrintListVisitedContenders(Contender[] contenders)
    {
        Console.WriteLine("Список участвовавших в отборе!");
        foreach (var contender in contenders)
        {
            Console.WriteLine($"Имя: {contender.Name} и насколько он хорош: {((IContender)contender).Score}");
        }
    }

    public static void PrintHappinessPrincess(int happiness)
    {
        Console.WriteLine("---");
        Console.WriteLine($"Принцесса счастлива на {happiness}/100");
    }
}