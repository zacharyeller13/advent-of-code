using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_01;

public class Trebuchet : ISolution<int>
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

    public void PrintLines()
    {
        foreach (string line in _lines)
        {
            Console.WriteLine(line);
        }
    }

    public void PrintPart2()
    {
        foreach (var digit in GetCalibrationValues("Part2"))
        {
            Console.WriteLine(digit);            
        }
    }

    private IEnumerable<int> GetCalibrationValues(string part) => part switch
    {
        "Part1" => _lines.Select(GetCalibrationValue),
        "Part2" => _lines.Select(GetStringDigits),
        _ => throw new ArgumentOutOfRangeException(nameof(part), "There are only 2 parts")
    };

    private int GetStringDigits(string line)
    {
        List<int> digits = new();
        
        for (int i = 0; i < line.Length; i++)
        {
            foreach ((string digitKey, int digit) in _stringDigits)
            {
                if (line[i..].StartsWith(digitKey))
                {
                    digits.Add(digit);
                }
            }
        }

        return (digits[0] * 10) + digits[^1];
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