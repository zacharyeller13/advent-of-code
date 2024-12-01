using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_02;

public class CubeConundrum : ISolution<int>
{
    private const int MaxRedCount = 12;
    private const int MaxGreenCount = 13;
    private const int MaxBlueCount = 14;

    private readonly string[] _lines;
    private readonly Dictionary<int, bool> _gamePossibilities = new();
    private int _sumOfPowers;

    public CubeConundrum(string[] fileContents)
    {
        _lines = fileContents;
        ParseGames();
    }

    public int SolvePart1() => _gamePossibilities.Sum(kvp => kvp.Value ? kvp.Key : 0);

    public int SolvePart2() => _sumOfPowers;

    public void PrintLines()
    {
        foreach (string line in _lines)
        {
            Console.WriteLine(line);
        }
    }

    public void PrintGames()
    {
        foreach (var game in _gamePossibilities)
        {
            Console.WriteLine(game);
        }
    }

    private void ParseGames()
    {
        // We know it always starts with "Game ", so we can use the known value instead of finding the index
        const int gameIdx = 5;

        foreach (string line in _lines)
        {
            int setsIdx = line.IndexOf(':');
            
            // For solving part 1
            _gamePossibilities.Add(int.Parse(line[gameIdx..setsIdx]),
                CheckPossibilities(line[(setsIdx + ": ".Length)..]));
            
            // For solving part 2
            _sumOfPowers += GetFewestCubes(line[(setsIdx + ": ".Length)..]).Aggregate((x, y) => x * y);
        }
    }

    private static IEnumerable<Dictionary<string, int>> ParseCubeCounts(string line) => line.Split("; ")
        .Select(
            set => set.Split(", ")
                .ToDictionary(
                    s => s.Split(' ')[^1],
                    s => int.Parse(s.Split(' ')[0])
                )
        );

    private static bool CheckPossibilities(string line) => ParseCubeCounts(line).All(IsPossible);

    private static bool IsPossible(Dictionary<string, int> gameCounts)
    {
        gameCounts.TryGetValue("red", out int redCount);
        gameCounts.TryGetValue("green", out int greenCount);
        gameCounts.TryGetValue("blue", out int blueCount);

        return redCount <= MaxRedCount
               && greenCount <= MaxGreenCount
               && blueCount <= MaxBlueCount;
    }

    private static IEnumerable<int> GetFewestCubes(string line)
    {
        IEnumerable<Dictionary<string, int>> cubes = ParseCubeCounts(line);

        foreach (string color in new[] { "red", "green", "blue" })
        {
            yield return cubes.SelectMany(dict => dict).Max(kvp => kvp.Key == color ? kvp.Value : 0);
        }
    }
}