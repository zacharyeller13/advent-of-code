using AdventOfCode.Lib;

namespace AdventOfCode._2024.day_07;

public class BridgeRepair : SolutionBase<long>
{
    public BridgeRepair(string[] fileContents) : base(fileContents)
    {
    }

    public override long SolvePart1()
    {
        long validCount = 0;
        foreach (string line in _lines)
        {
            (long testValue, long[] numbers) = line.Split(": ", StringSplitOptions.RemoveEmptyEntries) switch
            {
                [string val, string nums] => (long.Parse(val),
                    nums.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray()),
                _ => (0, [])
            };

            if (IsValid(testValue, numbers))
            {
                Console.WriteLine($"{testValue}: {string.Join(',', numbers)}");
                validCount += testValue;
            }
        }

        return validCount;
    }

    public override long SolvePart2()
    {
        long validCount = 0;
        foreach (string line in _lines)
        {
            (long testValue, long[] numbers) = line.Split(": ", StringSplitOptions.RemoveEmptyEntries) switch
            {
                [string val, string nums] => (long.Parse(val),
                    nums.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray()),
                _ => (0, [])
            };

            if (IsValidWithConcat(testValue, numbers))
            {
                // Console.WriteLine($"{testValue}: {string.Join(',', numbers)}");
                validCount += testValue;
            }
        }

        return validCount;
    }

    private static bool IsValid(long testValue, long[] numbers)
    {
        if (numbers.Length == 1)
        {
            return testValue == numbers[0];
        }

        if (IsValid(testValue, [numbers[0] + numbers[1], ..numbers[2..]]))
        {
            return true;
        }

        return IsValid(testValue, [numbers[0] * numbers[1], ..numbers[2..]]);
    }

    private static bool IsValidWithConcat(long testValue, long[] numbers)
    {
        if (numbers.Length == 1)
        {
            return testValue == numbers[0];
        }

        if (IsValidWithConcat(testValue, [numbers[0] + numbers[1], ..numbers[2..]]))
        {
            return true;
        }

        if (IsValidWithConcat(testValue, [long.Parse(string.Join("", numbers[..2])), ..numbers[2..]]))
        {
            return true;
        }

        return IsValidWithConcat(testValue, [numbers[0] * numbers[1], ..numbers[2..]]);
    }
}