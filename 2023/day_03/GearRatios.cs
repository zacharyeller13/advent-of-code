using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_03;

public class GearRatios : SolutionBase<int>
{
    private int _sumOfPartNumbers;

    // Represents coordinates of a gear
    private HashSet<(int, int)> _gears = new();

    // Represents the gear ratio of each gear
    // defined by the product of the 2 numbers adjacent to each gear
    private Dictionary<(int, int), List<int>> _partNums = new();

    public GearRatios(string[] fileContents) : base(fileContents)
    {
        CheckDigits();
    }

    public override int SolvePart1() => _sumOfPartNumbers;

    public override int SolvePart2()
    {
        int gearRatio = 0;

        foreach (var gearNums in _partNums.Values)
        {
            if (gearNums.Count == 2)
            {
                gearRatio += gearNums[0] * gearNums[1];
            }
        }

        return gearRatio;
    }

    private void CheckDigits()
    {
        for (int index = 0; index < _lines.Length; index++)
        {
            string line = _lines[index];
            string prev = index > 0 ? _lines[index - 1] : "";
            string next = index < _lines.Length - 1 ? _lines[index + 1] : "";
            bool symbolFound = false;
            int startIdx = 0;
            int digits;

            while (startIdx < line.Length)
            {
                int endIdx = startIdx;

                while (endIdx < line.Length && char.IsDigit(line[endIdx]))
                {
                    // Check above and below.
                    int prevIdx = endIdx - (endIdx > 0 ? 1 : 0);
                    int nextIdx = endIdx + (endIdx < line.Length - 1 ? 2 : 1);
                    symbolFound |= SymbolFound(prev, prevIdx, nextIdx);
                    symbolFound |= SymbolFound(next, prevIdx, nextIdx);

                    // Add gears
                    if (prev != "")
                    {
                        AddGears(index - 1, prevIdx, nextIdx);
                    }

                    if (next != "")
                    {
                        AddGears(index + 1, prevIdx, nextIdx);
                    }

                    endIdx++;
                }

                if (startIdx != endIdx)
                {
                    digits = int.Parse(line[startIdx..endIdx]);
                    // Check symbols left and right
                    int prevIdx = startIdx - (startIdx > 0 ? 1 : 0);
                    int nextIdx = endIdx + (endIdx < next.Length ? 0 : -1);
                    symbolFound |= IsSymbol(line[prevIdx]) || IsSymbol(line[nextIdx]);

                    AddGear(index, prevIdx);
                    AddGear(index, nextIdx);

                    _sumOfPartNumbers += symbolFound ? digits : 0;

                    // Must reset symbol found when we start over for a new range of digits
                    symbolFound = false;

                    foreach (var gear in _gears)
                    {
                        if (_partNums.ContainsKey(gear))
                        {
                            _partNums[gear].Add(digits);
                        }
                        else
                        {
                            _partNums[gear] = new List<int> { digits };
                        }
                    }

                    _gears.Clear();
                }

                startIdx = endIdx + 1;
            }
        }
    }

    private void AddGears(int rowIdx, int prevColIdx, int nextColIdx)
    {
        for (int i = prevColIdx; i < nextColIdx; i++)
        {
            AddGear(rowIdx, i);
        }
    }

    private void AddGear(int rowIdx, int colIdx)
    {
        if (IsGear(_lines[rowIdx][colIdx]))
        {
            _gears.Add((rowIdx, colIdx));
        }
    }

    private static bool SymbolFound(string line, int prevIdx, int nextIdx)
    {
        if (line == "")
        {
            return false;
        }

        return (line[prevIdx..nextIdx]).Any(IsSymbol);
    }


    private static bool IsSymbol(char chr) => !char.IsDigit(chr) && chr != '.';

    private static bool IsGear(char chr) => chr == '*';
}