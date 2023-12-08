using AdventOfCode._2023.day_06;
using AdventOfCode.Lib;

(string inputFolder, string part) = InputParser.ValidateArgs(args);

string[] testFile = InputParser.ParseInput($"./{inputFolder}/part1TestInput.txt");
string[] file = InputParser.ParseInput($"./{inputFolder}/input.txt");
string divider = new string('-', 25);

// Part 1 Solution
WaitForIt testSolution = new(testFile);
WaitForIt solution = new(file);

if (part == "1" || part == "all")
{
    Console.WriteLine($"{divider}Part 1{divider}");
    Console.WriteLine(testSolution.SolvePart1());
    Console.WriteLine(solution.SolvePart1());
}

// Part 2 Solution

if (part == "2" || part == "all")
{
    Console.WriteLine($"{divider}Part 2{divider}");
    Console.WriteLine(testSolution.SolvePart2());
    Console.WriteLine(solution.SolvePart2());
}