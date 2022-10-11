using PrincessProblem;
using PrincessProblem.model;

var contenders = ContendersGenerator.GenerateContenders();

var hall = new Hall(contenders);

var friend = new Friend();

var princess = new Princess(hall, friend);

var chosenContender=princess.ChooseContender();

princess.CountHappiness(chosenContender);

ConsoleOutput.PrintListVisitedContenders(hall.ReturnListContenders());

ConsoleOutput.PrintPrincessHappiness(princess.Happiness);