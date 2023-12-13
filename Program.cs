using AdventOfCode._2023.day_09;
using AdventOfCode.Lib;

(string inputFolder, string part) = InputParser.ValidateArgs(args);

string[] testFile = InputParser.ParseInput($"./{inputFolder}/part1TestInput.txt", "\n");
string[] file = InputParser.ParseInput($"./{inputFolder}/input.txt", "\n");
string divider = new string('-', 25);

// Part 1 Solution
MirageMaintenance testSolution = new(testFile);
MirageMaintenance solution = new(file);

if (part is "1" or "all")
{
    Console.WriteLine($"{divider}Part 1{divider}");
    Console.WriteLine(testSolution.SolvePart1()); // 18, 28, 68 = 114
    Console.WriteLine(solution.SolvePart1()); // 1877825184
}

// Part 2 Solution

if (part is "2" or "all")
{
    Console.WriteLine($"{divider}Part 2{divider}");
    Console.WriteLine(testSolution.SolvePart2()); // 2
    Console.WriteLine(solution.SolvePart2()); // 1108
}