using System.Reflection;
using AdventOfCode.Lib;

(string inputFolder, string part) = InputParser.ValidateArgs(args);

string[] testFile = InputParser.ParseInput($"./{inputFolder}/part1TestInput.txt", "\n");
string[] file = InputParser.ParseInput($"./{inputFolder}/input.txt", "\n");
string divider = new string('-', 25);

var types = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
    type.IsVisible && type.Namespace == $"AdventOfCode._{inputFolder.Replace('/', '.')}").ToArray();

if (types.Length > 1)
{
    throw new Exception($"Found more than one class for namespace AdventOfCode._{inputFolder.Replace('/', '.')}");
}

Type solutionType = types[0];

if (solutionType.BaseType?.GenericTypeArguments[0] == typeof(int))
{
    var testSolution = Activator.CreateInstance(solutionType, args: [testFile]);
    var solution = Activator.CreateInstance(solutionType, args: [file]);
    RunSolutions((testSolution as SolutionBase<int>)!, (solution as SolutionBase<int>)!);
}
else if (solutionType.BaseType?.GenericTypeArguments[0] == typeof(long))
{
    var testSolution = Activator.CreateInstance(solutionType, args: [testFile]);
    var solution = Activator.CreateInstance(solutionType, args: [file]);
    RunSolutions((testSolution as SolutionBase<long>)!, (solution as SolutionBase<long>)!);
}
else if (solutionType.BaseType?.GenericTypeArguments[0] == typeof(ulong))
{
    var testSolution = Activator.CreateInstance(solutionType, args: [testFile]);
    var solution = Activator.CreateInstance(solutionType, args: [file]);
    RunSolutions((testSolution as SolutionBase<ulong>)!, (solution as SolutionBase<ulong>)!);
}

return;

void RunSolutions<T>(SolutionBase<T> testSolution, SolutionBase<T> solution)
{
    // Part 1 Solution
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
}