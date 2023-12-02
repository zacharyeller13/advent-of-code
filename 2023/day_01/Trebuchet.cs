using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_01;

public class Trebuchet : ISolution
{
    private readonly string[] _lines;

    private readonly Dictionary<string, int> _stringDigits = new()
    {
        { "0", 0 },
        { "1", 1 },
        { "2", 2 },
        { "3", 3 },
        { "4", 4 },
        { "5", 5 },
        { "6", 6 },
        { "7", 7 },
        { "8", 8 },
        { "9", 9 },
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    public Trebuchet(string[] fileContents)
    {
        _lines = fileContents;
    }

    public int SolvePart1() => GetCalibrationValues("Part1").Sum();

    public int SolvePart2() => GetCalibrationValues("Part2").Sum();
    public IEnumerable<int> PrintPart2() => GetCalibrationValues("Part2");


    private IEnumerable<int> GetCalibrationValues(string part) => part switch
    {
        "Part1" => _lines.Select(GetCalibrationValue),
        "Part2" => _lines.Select(GetStringDigits),
        _ => throw new ArgumentOutOfRangeException(nameof(part), "There are only 2 parts")
    };

    private int GetStringDigits(string line)
    {
        int firstIndex = line.Length;
        string first = "";
        int lastIndex = -1;
        string last = "";

        foreach (string digit in _stringDigits.Keys)
        {
            int index = line.IndexOf(digit);
            if (index != -1)
            {
                first = index < firstIndex ? digit : first;
                firstIndex = index < firstIndex ? index : firstIndex;
                last = index > lastIndex ? digit : last;
                lastIndex = index > lastIndex ? index : lastIndex;
            }
        }
        
        return int.Parse($"{_stringDigits[first]}{_stringDigits[last]}");
    }

    private static int GetCalibrationValue(string line)
    {
        string nums = "";
        foreach (char character in line)
        {
            if (char.IsDigit(character))
            {
                nums += character;
            }
        }

        return int.Parse($"{nums[0]}{nums[^1]}");
    }
}