using AdventOfCode.Lib;

namespace AdventOfCode._2024.day_01;

public class HistorianHysteria : SolutionBase<int>
{
    private readonly List<int> _left = [];
    private readonly List<int> _right = [];
    private readonly Dictionary<int, int> _rightGrouped = [];

    public HistorianHysteria(string[] fileContents) : base(fileContents)
    {
        foreach (string line in _lines)
        {
            string[] nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _left.Add(int.Parse(nums[0]));
            int right = int.Parse(nums[1]);
            _right.Add(right);

            if (!_rightGrouped.TryAdd(right, 1))
            {
                _rightGrouped[right] += 1;
            }
        }
        _left.Sort();
        _right.Sort();
    }

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
    public override int SolvePart1()
    {
        int sum = 0;
        for (int i = 0; i < _left.Count; i++)
        {
            sum += Math.Abs(_left[i] - _right[i]);
        }
        return sum;
    }

    /// <summary>
    /// In the example: 
    ///     l r
    ///     1 3
    ///     2 3
    ///     3 3
    ///     3 4
    ///     3 5
    ///     4 9
    /// 
    ///     l rCount, product
    ///     1 0, 0
    ///     2 0, 0
    ///     3 3, 9
    ///     3 3, 9
    ///     3 3, 9
    ///     4 1, 4
    ///
    /// Similarity score is sum of products; 0+0+9+9+9+4=31
    /// </summary>
    public override int SolvePart2()
    {
        checked
        {
            return _left.Sum(n => _rightGrouped.GetValueOrDefault(n, 0) * n);
        }
    }
}