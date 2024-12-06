using AdventOfCode._2024.utils;
using AdventOfCode.Lib;

namespace AdventOfCode._2024.day_05;

public class PrintQueue : SolutionBase<int>
{
    private readonly IEnumerable<string> _pages;
    private readonly Dictionary<string, PageOrdering> _orders = GenerateDict();

    public PrintQueue(string[] fileContents) : base(fileContents)
    {
        var rules = _lines.Where(line => line.Length == 5);
        _pages = _lines.Where(line => line.Length > 5);
        // Setup ordering
        foreach (ReadOnlySpan<char> rule in rules)
        {
            (string left, string right) = (rule[..2].ToString(), rule[3..].ToString());
            _orders[left].After.Add(right);
        }
    }

    public override int SolvePart1()
    {
        int sum = 0;
        foreach (string page in _pages)
        {
            // Console.WriteLine(page);
            ReadOnlySpan<string> pageNums = page.Split(',').AsSpan();
            // Console.WriteLine(IsOrdered(pageNums));
            if (IsOrdered(pageNums))
            {
                // Console.WriteLine(pageNums[pageNums.Length / 2]);
                sum += int.Parse(pageNums[pageNums.Length / 2]);
            }
        }

        return sum;
    }

    public override int SolvePart2()
    {
        int sum = 0;
        foreach (string page in _pages)
        {
            string[] pageNumsArray = page.Split(',');
            ReadOnlySpan<string> pageNums = pageNumsArray.AsSpan();
            
            if (!IsOrdered(pageNums))
            {
                Array.Sort(pageNumsArray, (left, right) =>
                {
                    if (_orders[left].After.Contains(right))
                    {
                        return -1;
                    }

                    return _orders[right].After.Contains(left) ? 1 : 0;
                });
                
                sum += int.Parse(pageNums[pageNums.Length / 2]);
            }
        }

        return sum;
    }

    private static Dictionary<string, PageOrdering> GenerateDict()
    {
        Dictionary<string, PageOrdering> ret = new();
        for (int i = 10; i < 100; i++)
        {
            ret.Add($"{i}", new PageOrdering());
        }

        return ret;
    }

    private bool IsOrdered(ReadOnlySpan<string> pageNums)
    {
        for (int i = 0; i < pageNums.Length-1; i++)
        {
            string[] subArray = pageNums[(i + 1)..].ToArray();
            if (!_orders[pageNums[i]].After.ContainsAll(subArray))
            {
                return false;
            }
        }
        
        return true;
    }
}