﻿using PrincessProblem;
using PrincessProblem.model;

var contenders = ContendersGenerator.GenerateContenders();

var hall = new Hall(contenders);

var friend = new Friend(hall);

var princess = new Princess(hall, friend);

var chosenContender = princess.ChooseContender();

princess.CountHappiness(chosenContender?.Name);

ConsoleOutput.PrintListVisitedContenders(hall.ReturnListContenders(princess.СontendersNumberWhoVisitedPrincess));

ConsoleOutput.PrintPrincessHappiness(princess.Happiness);