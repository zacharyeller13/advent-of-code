using System.Text;
using AdventOfCode.Lib;

namespace AdventOfCode._2024.day_06;

public class GuardGallivant : SolutionBase<int>
{
    private readonly HashSet<(int, int)> _indices = [];
    private readonly HashSet<(int, int)> _possibleObstacles = [];

    public GuardGallivant(string[] fileContents) : base(fileContents)
    {
    }

    public override int SolvePart1()
    {
        (int Row, int Col) startIdx = (-1, -1);
        for (int i = 0; i < _lines.Length; i++)
        {
            ReadOnlySpan<char> span = _lines[i].AsSpan();
            if (span.IndexOf('^') is int j and > -1)
            {
                startIdx = (i, j);
                break;
            }
        }

        _indices.Add(startIdx);
        MakeMoves(startIdx);

        // foreach (var index in _indices)
        // {
        //     Console.WriteLine(index);
        // }

        return _indices.Count;
    }

    public override int SolvePart2()
    {
        (int Row, int Col) startIdx = (-1, -1);
        for (int i = 0; i < _lines.Length; i++)
        {
            ReadOnlySpan<char> span = _lines[i].AsSpan();
            if (span.IndexOf('^') is int j and > -1)
            {
                startIdx = (i, j);
                break;
            }
        }

        _indices.Add(startIdx);
        MakeMoves(startIdx);

        foreach (var index in _possibleObstacles)
        {
            Console.WriteLine(index);
        }
        PrintLines();

        return _possibleObstacles.Count;
    }

    private void MakeMoves((int Row, int Col) startIdx)
    {
        var currentIdx = startIdx;
        Span<string> lines = _lines.AsSpan();
        int maxRow = lines.Length - 1;
        int maxCol = lines[0].Length - 1;

        while ((currentIdx.Row > 0 && currentIdx.Row < maxRow) && (currentIdx.Col > 0 && currentIdx.Col < maxCol))
        {
            // ^ move -1 row
            while (currentIdx.Row > 0 && lines[currentIdx.Row - 1][currentIdx.Col] != '#')
            {
                currentIdx.Row--;
                if (!_indices.Add(currentIdx))
                {
                    _possibleObstacles.Add(currentIdx with { Row = currentIdx.Row - 1});
                }
            }

            // > move +1 col
            while (currentIdx.Col < maxCol && lines[currentIdx.Row][currentIdx.Col + 1] != '#')
            {
                currentIdx.Col++;
                if (!_indices.Add(currentIdx))
                {
                    _possibleObstacles.Add(currentIdx with { Col = currentIdx.Col + 1});
                }
            }

            // \/ move +1 row
            while (currentIdx.Row < maxRow && lines[currentIdx.Row + 1][currentIdx.Col] != '#')
            {
                currentIdx.Row++;
                if (!_indices.Add(currentIdx))
                {
                    _possibleObstacles.Add(currentIdx with { Row = currentIdx.Row + 1 });
                }
            }

            // < move -1 col
            while (currentIdx.Col > 0 && lines[currentIdx.Row][currentIdx.Col - 1] != '#')
            {
                currentIdx.Col--;
                if (!_indices.Add(currentIdx))
                {
                    _possibleObstacles.Add(currentIdx with { Col = currentIdx.Col - 1 });
                }
            }
        }
    }
}