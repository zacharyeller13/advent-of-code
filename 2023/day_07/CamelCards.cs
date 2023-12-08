using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_07;

public class CamelCards : SolutionBase
{
    private static readonly Dictionary<char, int> CardWeights = new Dictionary<char, int>()
    {
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { 'T', 10 },
        { 'J', 11 },
        { 'Q', 12 },
        { 'K', 13 },
        { 'A', 14 },
    };
    public CamelCards(string[] fileContents) : base(fileContents) { }

    public override int SolvePart1()
    {
        PrintLines();
        foreach (char c in _lines[0].Split()[0])
        {
            Console.WriteLine($"{c}: {CardWeights[c]}");
        }
        return -1;
    }

    public override int SolvePart2()
    {
        return base.SolvePart2();
    }
}
