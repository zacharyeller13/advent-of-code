using System.Globalization;
using AdventOfCode._2023.day_07;
using AdventOfCode.Lib;

(string inputFolder, string part) = InputParser.ValidateArgs(args);

string[] testFile = InputParser.ParseInput($"./{inputFolder}/part1TestInput.txt");
string[] file = InputParser.ParseInput($"./{inputFolder}/input.txt");
string divider = new string('-', 25);

// Part 1 Solution
CamelCards testSolution = new(testFile);
CamelCards solution = new(file);

if (part is "1" or "all")
{
    Console.WriteLine($"{divider}Part 1{divider}");
    Console.WriteLine(testSolution.SolvePart1());
    Console.WriteLine(solution.SolvePart1());
    // List<string> test = new() { "99J99", "99T99", "99J99" };
    // List<string> test2 = new() { "99;99", "99:99", "99;99" };
    // test.Sort(StringComparer.Ordinal);
    // test2.Sort(StringComparer.Ordinal);
    // Console.WriteLine(string.Join(",", test));
    // Console.WriteLine(string.Join(",", test2));
}

// Part 2 Solution

if (part is "2" or "all")
{
    Console.WriteLine($"{divider}Part 2{divider}");
    Console.WriteLine(testSolution.SolvePart2());
    Console.WriteLine(solution.SolvePart2());
}