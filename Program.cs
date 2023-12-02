using AdventOfCode._2023.day_01;
using AdventOfCode.Lib;

string[] testFile = InputParser.ParseInput("./2023/day_01/part1TestInput.txt");
string[] testFile2 = InputParser.ParseInput("./2023/day_01/part2TestInput.txt");
string[] file = InputParser.ParseInput("./2023/day_01/input.txt");
string divider = new string('-', 25);

// Part 1 Solution
Trebuchet testSolution = new(testFile);
Trebuchet solution = new(file);

Console.WriteLine($"{divider}Part 1{divider}");
Console.WriteLine(testSolution.SolvePart1());
Console.WriteLine(solution.SolvePart1());

// Part 2 Solution
Trebuchet testSolution2 = new(testFile2);

Console.WriteLine($"{divider}Part 2{divider}");
Console.WriteLine(testSolution2.SolvePart2());
Console.WriteLine(solution.SolvePart2());