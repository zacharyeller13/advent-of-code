using AdventOfCode.Lib;

namespace AdventOfCode._2024.day_02;

/// <summary>
/// The unusual data (your puzzle input) consists of many reports, one report per line. Each report is a list of numbers called levels that are separated by spaces.
/// </summary>
public class RedNosedReports : SolutionBase<int>
{
    private readonly IEnumerable<List<int>> _reports;

    public RedNosedReports(string[] fileContents) : base(fileContents)
    {
        _reports = _lines.Select(line =>
            line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList()
        );
    }

    /// <summary>
    /// One report per line, are counted safe if:
    /// <list type="bullet">
    /// <item>The levels are either all increasing or all decreasing.</item>
    /// <item>Any two adjacent levels differ by at least one and at most three.</item>
    /// </list>
    /// </summary>
    /// <returns>int representing count of safe reports</returns>
    public override int SolvePart1() => SafeCount(IsSafeStrict);

    // 555 was too low
    // 563 was too high
    /// <summary>
    /// Can tolerate 1 bad level by removing it
    /// </summary>
    public override int SolvePart2() => SafeCount(IsSafeTolerant);

    private int SafeCount(Func<List<int>, bool> safetyFunction)
    {
        int safeCount = 0;
        foreach (List<int> report in _reports)
        {
            // Console.WriteLine(string.Join(' ', report));
            if (safetyFunction(report))
            {
                safeCount++;
            }
        }

        return safeCount;
    }

    private static bool IsSafeStrict(List<int> report)
    {
        bool isSorted = report.SequenceEqual(report.OrderBy(x => x).ToList()) ||
                        report.SequenceEqual(report.OrderByDescending(x => x).ToList());
        
        // Is ascending or descending (parameter 1)
        if (!isSorted)
        {
            return false;
        }
        
        for (int i = 0; i < report.Count - 1; i++)
        {
            int distance = Math.Abs(report[i] - report[i + 1]);
            // Is not within parameter 2 (at least 1 and at most 3)
            if (distance is < 1 or > 3)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsSafeTolerant(List<int> report)
    {
        for (int i = 0; i < report.Count; i++)
        {
            if (IsSafeStrict(report[..i].Concat(report[(i + 1)..]).ToList()))
            {
                return true;
            }
        }

        return false;
    }
}