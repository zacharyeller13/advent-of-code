using System.Reflection;
using AdventOfCode.Lib;

(string inputFolder, string part, bool isTest) = InputParser.ValidateArgs(args);

string[]? testFile = InputParser.ParseInput($"./{inputFolder}/part1TestInput.txt", "\n");
string[]? file = InputParser.ParseInput($"./{inputFolder}/input.txt", "\n");
string divider = new('-', 25);

var types = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
    type.IsVisible && type.Namespace == $"AdventOfCode._{inputFolder.Replace('/', '.')}").ToArray();

if (types.Length > 1)
{
    throw new Exception($"Found more than one class for namespace AdventOfCode._{inputFolder.Replace('/', '.')}");
}

Type solutionType = types[0];
object? testSolution = testFile is null ? null : Activator.CreateInstance(solutionType, args: [testFile]);
object? solution = file is null ? null : Activator.CreateInstance(solutionType, args: [file]);

if (solutionType.BaseType?.GenericTypeArguments[0] == typeof(int))
{
    RunSolutions((testSolution as SolutionBase<int>), (solution as SolutionBase<int>), isTest);
}
else if (solutionType.BaseType?.GenericTypeArguments[0] == typeof(long))
{
    RunSolutions((testSolution as SolutionBase<long>), (solution as SolutionBase<long>), isTest);
}
else if (solutionType.BaseType?.GenericTypeArguments[0] == typeof(ulong))
{
    RunSolutions((testSolution as SolutionBase<ulong>), (solution as SolutionBase<ulong>), isTest);
}

return;

void RunSolutions<T>(SolutionBase<T>? test, SolutionBase<T>? main, bool testOnly) where T : struct
{
    // Part 1 Solution
    if (part is "1" or "all")
    {
        Console.WriteLine($"{divider}Part 1{divider}");
        Console.WriteLine(test?.SolvePart1());
        if (!testOnly)
        {
            Console.WriteLine(main?.SolvePart1());
        }
    }

    // Part 2 Solution
    if (part is "2" or "all")
    {
        Console.WriteLine($"{divider}Part 2{divider}");
        Console.WriteLine(test?.SolvePart2());
        if (!testOnly)
        {
            Console.WriteLine(main?.SolvePart2());
        }
    }
}