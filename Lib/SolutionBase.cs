namespace AdventOfCode.Lib;

public class SolutionBase : ISolution
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

    public virtual int SolvePart1()
    {
        throw new NotImplementedException();
    }

    public virtual int SolvePart2()
    {
        throw new NotImplementedException();
    }
}
