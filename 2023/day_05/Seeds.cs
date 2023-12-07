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

public class Seeds : ISolution
{
    private readonly string[] _lines;
    private long[] _seeds;
    private string[] _maps;

    public Seeds(string[] fileContents)
    {
        _lines = fileContents;
        SetSeeds(fileContents);
        SetMaps(fileContents);
    }

    public long SolvePart1Long()
    {
        List<long> mappedSeeds = new();
        foreach (var seed in _seeds)
        {
            mappedSeeds.Add(MapSeed(seed));
        }
        return mappedSeeds.Min();
    }
    public long SolvePart2Long()
    {
        throw new NotImplementedException();
    }
    
    // Unused because the inputs are too large for a regular integer
    // Maybe I should create a separate ISolutionLong interface? Maybe I'm "overengineering" lol
    public int SolvePart1()
    {
        throw new NotImplementedException();
    }
    public int SolvePart2()
    {
        throw new NotImplementedException();
    }
    public void PrintLines()
    {
        foreach (var line in _lines)
        {
            Console.WriteLine(line);
        }
    }

    private void SetSeeds(string[] fileContents)
    {
        string[] seeds = fileContents[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        _seeds = Array.ConvertAll<string, long>(seeds, long.Parse);
    }

    private void SetMaps(string[] fileContents)
    {
        _maps = fileContents[1..];
    }

    private long MapSeed(long seed)
    {
        foreach (var map in _maps)
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
