using System.Data.Common;
using AdventOfCode.Lib;

namespace AdventOfCode._2024.day_08;

public class ResonantCollinearity : SolutionBase<int>
{
    private readonly Dictionary<char, List<(int Row, int Col)>> _frequencies = [];
    private readonly List<char[]> _linesChars = [];
    private readonly HashSet<(int, int)> _antinodes = [];

    public ResonantCollinearity(string[] fileContents) : base(fileContents)
    {
        foreach (string fileContent in fileContents)
        {
            _linesChars.Add(fileContent.ToCharArray());
        }
    }

    // Single lowercase letter, uppercase, or digit
    // so [A-Za-z0-9]
    // Antinode is 2 antenna are created where perfectly in line with position
    // of antinode and 2nd is twice as far away as 1st
    // Test input should create
    // ......#....#
    // ...#....0...
    // ....#0....#.
    // ..#....0....
    // ....0....#..
    // .#....A.....
    // ...#........
    // #......#....
    // ........A...
    // .........A..
    // ..........#.
    // ..........#.
    // 14 antinodes
    public override int SolvePart1()
    {
        int maxRow = _lines.Length - 1;
        int maxCol = _lines[0].Length - 1;

        // First find all the indexes of frequencies
        for (int row = 0; row <= maxRow; row++)
        {
            for (int col = 0; col <= maxCol; col++)
            {
                if (char.IsAsciiLetterOrDigit(_lines[row][col]) && !_frequencies.ContainsKey(_lines[row][col]))
                {
                    _frequencies.Add(_lines[row][col], FindIndexesOf(_lines[row][col]));
                }
            }
        }

        // For each point, for each other point
        // Measure the difference between points, can we put a point at each end of that "line" between
        // those 2 points?  E.g. dp = p1 - p2; try p1 + dp and p2 - dp
        // foreach ((char key, var value) in _frequencies)
        // {
        //     Console.WriteLine($"{key}: {string.Join(',', value)}");
        // }

        // Go through and test each of the frequency lines for boundaries
        foreach (var (_, value) in _frequencies)
        {
            for (int i = 0; i < value.Count - 1; i++)
            {
                for (int j = i + 1; j < value.Count; j++)
                {
                    var current = value[i];
                    var next = value[j];
                    (int dr, int dc) = (current.Row - next.Row, current.Col - next.Col);
                    
                    // Console.WriteLine($"{current} {next} ({dr}, {dc})");
                    (int Row, int Col) upper = (current.Row + dr, current.Col + dc);
                    (int Row, int Col) lower = (next.Row - dr, next.Col - dc);
                    // Console.WriteLine($"{upper} {lower}");

                    if ((upper.Row >= 0 && upper.Row <= maxRow) && (upper.Col >= 0 && upper.Col <= maxCol))
                    {
                        _antinodes.Add(upper);
                        _linesChars[upper.Row][upper.Col] = '#';
                    }

                    if ((lower.Row >= 0 && lower.Row <= maxRow) && (lower.Col >= 0 && lower.Col <= maxCol))
                    {
                        _antinodes.Add(lower);
                        _linesChars[lower.Row][lower.Col] = '#';
                    }
                }
            }
        }

        // foreach (char[] linesChar in _linesChars)
        // {
        //     Console.WriteLine(linesChar);
        // }

        return _antinodes.Count;
    }

    public override int SolvePart2()
    {
        int maxRow = _lines.Length - 1;
        int maxCol = _lines[0].Length - 1;

        // First find all the indexes of frequencies
        for (int row = 0; row <= maxRow; row++)
        {
            for (int col = 0; col <= maxCol; col++)
            {
                if (char.IsAsciiLetterOrDigit(_lines[row][col]) && !_frequencies.ContainsKey(_lines[row][col]))
                {
                    _frequencies.Add(_lines[row][col], FindIndexesOf(_lines[row][col]));
                }
            }
        }

        foreach (var (_, value) in _frequencies)
        {
            for (int i = 0; i < value.Count - 1; i++)
            {
                for (int j = i + 1; j < value.Count; j++)
                {
                    var current = value[i];
                    var next = value[j];
                    (int dr, int dc) = (current.Row - next.Row, current.Col - next.Col);

                    _antinodes.Add(current);
                    _linesChars[current.Row][current.Col] = '#';
                    
                    _antinodes.Add(next);
                    _linesChars[next.Row][next.Col] = '#';
                    // Console.WriteLine($"{current} {next} ({dr}, {dc})");
                    (int Row, int Col) upper = (current.Row + dr, current.Col + dc);
                    (int Row, int Col) lower = (next.Row - dr, next.Col - dc);
                    // Console.WriteLine($"{upper} {lower}");

                    while ((upper.Row >= 0 && upper.Row <= maxRow) && (upper.Col >= 0 && upper.Col <= maxCol))
                    {
                        _antinodes.Add(upper);
                        _linesChars[upper.Row][upper.Col] = '#';
                        upper.Row += dr;
                        upper.Col += dc;
                    }

                    while ((lower.Row >= 0 && lower.Row <= maxRow) && (lower.Col >= 0 && lower.Col <= maxCol))
                    {
                        _antinodes.Add(lower);
                        _linesChars[lower.Row][lower.Col] = '#';
                        lower.Row -= dr;
                        lower.Col -= dc;
                    }
                }
            }
        }

        foreach (char[] linesChar in _linesChars)
        {
            Console.WriteLine(linesChar);
        }

        return _antinodes.Count;
    }

    private List<(int, int)> FindIndexesOf(char chr)
    {
        List<(int Row, int Col)> indexes = [];
        for (int row = 0; row < _lines.Length; row++)
        {
            for (int col = 0; col < _lines[0].Length; col++)
            {
                if (_lines[row][col] == chr)
                {
                    indexes.Add((row, col));
                }
            }
        }

        return indexes;
    }
}