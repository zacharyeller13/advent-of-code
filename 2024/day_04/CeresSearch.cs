using AdventOfCode.Lib;

namespace AdventOfCode._2024.day_04;

public class CeresSearch : SolutionBase<int>
{
    public CeresSearch(string[] fileContents) : base(fileContents)
    {
    }

    /// <summary>
    /// Word search for "XMAS" but can but vertical, horizontal, diagonal, backwards, overlapping
    /// </summary>
    /// <example>
    /// Test input has 18
    /// </example>
    public override int SolvePart1()
    {
        /* ..X...
           .SAMX.
           .A..A.
           XMAS.S
           .X.... */
        ReadOnlySpan<string> span = _lines.AsSpan();
        int xmasCount = 0;
        for (int row = 0; row < span.Length; row++)
        {
            // Console.WriteLine(span[row]);
            for (int col = 0; col < span[0].Length; col++)
            {
                if (span[row][col] != 'X')
                {
                    continue;
                }

                // Up left diagonal
                xmasCount += CheckUp(span, "left", row, col);
                // Up straight
                xmasCount += CheckUp(span, "straight", row, col);
                // Up right diagonal
                xmasCount += CheckUp(span, "right", row, col);
                // Reverse
                xmasCount += CheckStraight(span, "left", row, col);
                // Forward
                xmasCount += CheckStraight(span, "right", row, col);
                // Down left
                xmasCount += CheckDown(span, "left", row, col);
                // Down straight
                xmasCount += CheckDown(span, "straight", row, col);
                // Down right
                xmasCount += CheckDown(span, "right", row, col);
                // Console.WriteLine();
            }

            // Console.WriteLine();
        }

        return xmasCount;
    }

    /// <summary>
    /// Word search for "X-MAS" which is "MAS" overlapping in an X shape
    /// </summary>
    /// <example>
    /// Test input has 9
    /// </example>
    public override int SolvePart2()
    {
        // M.S
        // .A.
        // M.S
        ReadOnlySpan<string> span = _lines.AsSpan();
        int xmasCount = 0;
        for (int row = 0; row < span.Length; row++)
        {
            for (int col = 0; col < span[0].Length; col++)
            {
                // Switch to searching for A
                if (span[row][col] != 'A')
                {
                    continue;
                }

                xmasCount += CheckX(span, row, col);
            }
        }

        return xmasCount;
    }

    private static int CheckUp(ReadOnlySpan<string> span, string direction, int row, int col)
    {
        int xmasCount = 0;
        try
        {
            string maybeXmas = direction switch
            {
                "left" => new string(['X', span[row - 1][col - 1], span[row - 2][col - 2], span[row - 3][col - 3]]),
                "right" => new string(['X', span[row - 1][col + 1], span[row - 2][col + 2], span[row - 3][col + 3]]),
                "straight" => new string(['X', span[row - 1][col], span[row - 2][col], span[row - 3][col]]),
                _ => throw new ArgumentException(null, nameof(direction))
            };
            // Console.Write(maybeXmas);
            if (maybeXmas == "XMAS")
            {
                xmasCount++;
            }
        }
        catch (IndexOutOfRangeException)
        {
            // Console.Write('_');
        }

        // Console.Write($"({xmasCount}),");
        return xmasCount;
    }

    private static int CheckDown(ReadOnlySpan<string> span, string direction, int row, int col)
    {
        int xmasCount = 0;
        try
        {
            string maybeXmas = direction switch
            {
                "left" => new string(['X', span[row + 1][col - 1], span[row + 2][col - 2], span[row + 3][col - 3]]),
                "right" => new string(['X', span[row + 1][col + 1], span[row + 2][col + 2], span[row + 3][col + 3]]),
                "straight" => new string(['X', span[row + 1][col], span[row + 2][col], span[row + 3][col]]),
                _ => throw new ArgumentException(null, nameof(direction))
            };
            // Console.Write(maybeXmas);
            if (maybeXmas == "XMAS")
            {
                xmasCount++;
            }
        }
        catch (IndexOutOfRangeException)
        {
            // Console.Write('_');
        }

        // Console.Write($"({xmasCount}),");
        return xmasCount;
    }

    private static int CheckStraight(ReadOnlySpan<string> span, string direction, int row, int col)
    {
        int xmasCount = 0;
        try
        {
            string maybeXmas = direction switch
            {
                "left" => new string(['X', span[row][col - 1], span[row][col - 2], span[row][col - 3]]),
                "right" => new string(['X', span[row][col + 1], span[row][col + 2], span[row][col + 3]]),
                _ => throw new ArgumentException(null, nameof(direction))
            };
            // Console.Write(maybeXmas);
            if (maybeXmas == "XMAS")
            {
                xmasCount++;
            }
        }
        catch (IndexOutOfRangeException)
        {
            // Console.Write('_');
        }

        // Console.Write($"({xmasCount}),");
        return xmasCount;
    }

    private static int CheckX(ReadOnlySpan<string> span, int row, int col)
    {
        try
        {
            string leftMas = new([span[row - 1][col - 1], 'A', span[row + 1][col + 1]]);
            string rightMas = new([span[row + 1][col - 1], 'A', span[row - 1][col + 1]]);

            if (leftMas is "MAS" or "SAM" && rightMas is "MAS" or "SAM")
            {
                return 1;
            }

            return 0;
        }
        catch (IndexOutOfRangeException)
        {
            return 0;
        }
    }
}