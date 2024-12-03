using AdventOfCode.Lib;

namespace AdventOfCode._2024.day_03;

public class MullItOver : SolutionBase<int>
{
    public MullItOver(string[] fileContents) : base(fileContents)
    {
    }

    /// <summary>
    /// Everything like <c>mul(X,Y)</c> where X and Y are 1 to 3 digits in length is multiplied then added
    /// </summary>
    /// <example>Test input should come to: <c>2*4 + 5*5 + 11*8 + 8*5 = 161</c></example>
    public override int SolvePart1()
    {
        checked
        {
            int sum = 0;
            foreach (string line in _lines)
            {
                string[] instances = line.Split("mul(");
                sum += instances.Sum(instance => ParseMul(instance));
            }

            return sum;
        }
    }

    /// <summary>
    /// Everything like <c>mul(X,Y)</c> where X and Y are 1 to 3 digits in length is multiplied then added
    /// Except now we obey <c>don't()</c> and <c>do()</c> statements to enable and disable subsequent muls
    /// </summary>
    /// <example>Test input should come to: <c>2*4 + 8*5 = 48</c></example>
    public override int SolvePart2()
    {
        int sum = 0;
        bool enabled = true;
        foreach (string line in _lines)
        {
            string[] instances = line.Split("mul(");
            foreach (string instance in instances)
            {
                sum += ParseMul(instance, enabled);

                if (instance.Contains("don't()"))
                {
                    enabled = false;
                }

                if (instance.Contains("do()"))
                {
                    enabled = true;
                }
            }
        }

        return sum;
    }

    private static int ParseMul(string instance, bool enabled = true)
    {
        int sum = 0;

        if (!enabled)
        {
            return 0;
        }

        if (instance.AsSpan().IndexOf(')') is var i and > -1)
        {
            // Console.WriteLine(instance.AsSpan()[..i].ToString());
            string[] nums = instance[..i].Split(',', 2);
            if (nums.Length == 2 && nums.AsSpan()[0].Length <= 3 && nums.AsSpan()[1].Length <= 3)
            {
                // Console.Write(string.Join(" * ", nums));
                int product = nums.Select(int.Parse).Aggregate((x, y) => x * y);
                // Console.WriteLine($" = {product}");
                sum += product;
            }
        }
        else
        {
            // Console.WriteLine("_");
        }

        return sum;
    }
}