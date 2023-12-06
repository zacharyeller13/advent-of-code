using AdventOfCode._2023.day_03;
using AdventOfCode._2023.day_04;
using AdventOfCode.Lib;


string inputFolder = InputParser.ValidateArgs(args);

string[] testFile = InputParser.ParseInput($"./{inputFolder}/part1TestInput.txt");
string[] file = InputParser.ParseInput($"./{inputFolder}/input.txt");
string divider = new string('-', 25);

// Part 1 Solution
Scratchcards testSolution = new(testFile);
Scratchcards solution = new(file);

Console.WriteLine($"{divider}Part 1{divider}");
Console.WriteLine(testSolution.SolvePart1());
Console.WriteLine(solution.SolvePart1());

// Part 2 Solution
Console.WriteLine($"{divider}Part 2{divider}");
//Console.WriteLine(testSolution.SolvePart2());
//Console.WriteLine(solution.SolvePart2());