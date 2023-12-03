using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_02;

public class CubeConundrum : ISolution
{
    private readonly string[] _lines;
    private static readonly int redCount = 12;
    private static readonly int greenCount = 13;
    private static readonly int blueCount = 14;
    

    public CubeConundrum(string[] fileContents)
    {
        _lines = fileContents;
    }

    public int SolvePart1()
    {
        throw new NotImplementedException();
    }

    public int SolvePart2()
    {
        throw new NotImplementedException();
    }

    public void PrintLines()
    {
        foreach (string line in _lines)
        {
            Console.WriteLine(line);
        }
    }
}