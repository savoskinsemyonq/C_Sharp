using lab1;
using lab1.model;

var contenders = ContendersGenerator.GenerateContenders();

var hall = new Hall(contenders);

var friend= new Friend();

var princess= new Princess(hall, friend);

princess.ChooseContenderStrategy();

ConsoleOutput.PrintListVisitedContenders(hall.ReturnListContenders());

ConsoleOutput.PrintHappinessPrincess(princess.Happiness);