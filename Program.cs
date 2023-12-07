using AdventOfCode._2023.day_05;
using AdventOfCode.Lib;

(string inputFolder, string part) = InputParser.ValidateArgs(args);

string[] testFile = InputParser.ParseInput($"./{inputFolder}/part1TestInput.txt", $"{Environment.NewLine}{Environment.NewLine}");
string[] file = InputParser.ParseInput($"./{inputFolder}/input.txt", $"{Environment.NewLine}{Environment.NewLine}");
string divider = new string('-', 25);

// Part 1 Solution
Seeds testSolution = new(testFile);
Seeds solution = new(file);

if (part == "1" || part == "all")
{
    Console.WriteLine($"{divider}Part 1{divider}");
    Console.WriteLine(testSolution.SolvePart1Long()); // Expect 35 as final output
    Console.WriteLine(solution.SolvePart1Long()); // 178159714 correct
}

// Part 2 Solution

if (part == "2" || part == "all")
{
    Console.WriteLine($"{divider}Part 2{divider}");
    Console.WriteLine(testSolution.SolvePart2Long());
    //Console.WriteLine(solution.SolvePartLong2());
}