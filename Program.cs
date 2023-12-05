using AdventOfCode._2023.day_03;
using AdventOfCode.Lib;


string inputFolder = InputParser.ValidateArgs(args);

string[] testFile = InputParser.ParseInput($"./{inputFolder}/part1TestInput.txt");
string[] file = InputParser.ParseInput($"./{inputFolder}/input.txt");
string divider = new string('-', 25);

// Part 1 Solution
GearRatios testSolution = new(testFile);
GearRatios solution = new(file);

Console.WriteLine($"{divider}Part 1{divider}");
Console.WriteLine(testSolution.SolvePart1()); // Expect: 4361
Console.WriteLine(solution.SolvePart1()); // 489676 too low; 531561 correct

// Part 2 Solution
Console.WriteLine($"{divider}Part 2{divider}");
Console.WriteLine(testSolution.SolvePart2()); // Expect: 467835
Console.WriteLine(solution.SolvePart2()); // 83279367 correct