using AdventOfCode.Lib;

namespace AdventOfCode._2024.day_01;

/// <summary>
/// In the example, the pairs and distances would be as follows:
///     l r, distance
///     1 3, 2
///     2 3, 1
///     3 3, 0
///     3 4, 1
///     3 5, 2
///     4 9, 5
///
/// To find the total distance between the left list and the right list, add up the distances between all of the pairs you found.
/// In the example above, this is 2 + 1 + 0 + 1 + 2 + 5, a total distance of 11!
/// </summary>
public class HistorianHysteria : SolutionBase<int>
{
    private readonly List<int> _left = [];
    private readonly List<int> _right = [];
    
    public HistorianHysteria(string[] fileContents) : base(fileContents)
    {
        foreach (string line in _lines)
        {
            string[] nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _left.Add(int.Parse(nums[0]));
            _right.Add(int.Parse(nums[1]));
        }
        _left.Sort();
        _right.Sort();
    }

    public override int SolvePart1()
    {
        int sum = 0;
        for (int i = 0; i < _left.Count; i++)
        {
            sum += Math.Abs(_left[i] - _right[i]);
        }
        return sum;
    }

    public override int SolvePart2()
    {
        return -1;
    }
}