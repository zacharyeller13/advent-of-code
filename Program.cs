using AdventOfCode._2023.day_08;
using AdventOfCode.Lib;

(string inputFolder, string part) = InputParser.ValidateArgs(args);

string[] testFile = InputParser.ParseInput($"./{inputFolder}/part1TestInput.txt", "\n");
string[] testFile2 = InputParser.ParseInput($"./{inputFolder}/part2TestInput.txt", "\n");
string[] file = InputParser.ParseInput($"./{inputFolder}/input.txt", "\n");
string divider = new string('-', 25);

// Part 1 Solution
HauntedWasteland testSolution = new(testFile);
HauntedWasteland solution = new(file);

if (part is "1" or "all")
{
    Console.WriteLine($"{divider}Part 1{divider}");
    Console.WriteLine(testSolution.SolvePart1());
    Console.WriteLine(solution.SolvePart1());
}

// Part 2 Solution

if (part is "2" or "all")
{
    HauntedWasteland testSolution2 = new(testFile2);
    
    Console.WriteLine($"{divider}Part 2{divider}");
    Console.WriteLine(testSolution2.SolvePart2());
    Console.WriteLine(solution.SolvePart2()); // 1016719625 too low; 14321394058031 correct
}