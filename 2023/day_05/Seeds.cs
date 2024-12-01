using AdventOfCode.Lib;
using System.ComponentModel;

namespace AdventOfCode._2023.day_05;

// Each line is a of format:
// <target start> <source start> <length>
// e.g. 50 98 2 =>
// target contains 2 values: 50, 51
// source contains 2 values: 98, 99
// so -> 50 == 98; 51 == 99
// where not mapped, numbers are same
// e.g. 0 == 0 => map.TryGetValue() where default is the same as the key

public class Seeds : SolutionBase<long>
{
    private readonly long[] _seeds;
    private readonly List<(long,long)> _seedPairs = new();

    public Seeds(string[] fileContents) : base(fileContents)
    {
        _seeds = ParseSeeds(fileContents);
        for (int i = 0; i < _seeds.Length; i += 2)
        {
            _seedPairs.Add((_seeds[i], _seeds[i + 1]));
        }
    }

    public override long SolvePart1()
    {
        List<long> mappedSeeds = new();
        foreach (var seed in _seeds)
        {
            mappedSeeds.Add(MapSeed(seed));
        }
        return mappedSeeds.Min();
    }

    public override long SolvePart2()
    {
        // May not finish this; it's very complex
        // And I'd like to try other days of the advent
        foreach (var tuple in _seedPairs)
        {
            Console.WriteLine(string.Join(',', tuple));
        }
        return -1;
    }

    private static long[] ParseSeeds(string[] fileContents)
    {
        string[] seeds = fileContents[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return Array.ConvertAll<string, long>(seeds, long.Parse);
    }

    private long MapSeed(long seed)
    {
        foreach (var map in _lines[1..])
        {
            string[] parts = map.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            seed = ProcessMaps(seed, parts[1..]);
        }
        return seed;
    }

    private static long ProcessMaps(long seed, string[] parts)
    {
        foreach (var line in parts)
        {
            long dest = long.Parse(line.Split()[0]);
            long source = long.Parse(line.Split()[1]);
            long range = long.Parse(line.Split()[2]);

            if (source <= seed && seed < (source + range))
            {
                return dest + (seed - source);
            }
        }
        return seed;
    }
}
