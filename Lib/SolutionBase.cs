namespace AdventOfCode.Lib;

public class SolutionBase<T> : ISolution<T> where T : struct
{
    protected readonly string[] _lines;

    public SolutionBase(string[] fileContents)
    {
        _lines = fileContents;
    }

    public void PrintLines()
    {
        foreach (var line in _lines)
        {
            Console.WriteLine(line);
        }
    }

    public virtual T SolvePart1()
    {
        PrintLines();
        return default;
    }

    public virtual T SolvePart2()
    {
        PrintLines();
        return default;
    }
}