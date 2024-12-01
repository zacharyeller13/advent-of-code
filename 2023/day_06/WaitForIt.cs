using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_06;


// Start speed = 0
// Speed added per ms held: 1
// So 1 ms = 1 mm/ms; 2 ms = 2 mm/ms; 3 ms = 3 mm/ms
public class WaitForIt : SolutionBase<long>
{
    private long[] _times;
    private long[] _distances;
    public WaitForIt(string[] fileContents) : base(fileContents)
    {
        _times = ParseLine(0, splitlongs: true);
        _distances = ParseLine(1, splitlongs: true);
    }

    public override long SolvePart1()
    {
        return GetPossibleWins().Aggregate((x, y) => x * y);
    }

    public override long SolvePart2()
    {
        // Reset because the digits should be all together
        _times = ParseLine(0);
        _distances = ParseLine(1);
        
        return GetPossibleWins().Aggregate((x, y) => x * y);
    }

    private long[] ParseLine(long index, bool splitlongs = false)
    {
        string[] digits;
        string line = _lines[index].Split(':')[1];
        if (splitlongs)
        {
            digits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
        else
        {
            digits = new string[] { line.Trim().Replace(" ", "") };
        }
        return Array.ConvertAll<string, long>(digits, long.Parse);
    }
    
    private IEnumerable<long> GetPossibleWins()
    {
        for (long i = 0; i < _times.Length; i++)
        {
            long wins = 0;
            long duration = _times[i];
            long record = _distances[i];

            for (long j = 1; j < duration; j++)
            {
                // speed * timeTraveled
                long distanceTraveled = j * (duration - j);

                if (distanceTraveled > record)
                {
                    wins++;
                }
                
            }
            yield return wins;
        }
    }
}
