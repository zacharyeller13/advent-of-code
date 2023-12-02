using AdventOfCode._2023.day_01;
using AdventOfCode.Lib;

string[] testFile = InputParser.ParseInput("./2023/day_01/testInput.txt");
string[] file = InputParser.ParseInput("./2023/day_01/input.txt");
string divider = new string('-', 25);

// Part 1 Solution
Trebuchet testSolution = new(testFile);
Trebuchet solution = new(file);

Console.WriteLine($"{divider}Part 1{divider}");
Console.WriteLine(testSolution.CalibrationValues.Sum());
Console.WriteLine(solution.CalibrationValues.Sum());

// Part 2 Solution
Console.WriteLine($"{divider}Part 1{divider}");
