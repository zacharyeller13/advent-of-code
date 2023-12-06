using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_04;

public class Scratchcards : ISolution
{
    private readonly string[] _lines;

    public Scratchcards(string[] fileContents)
    {
        _lines = fileContents;
    }

    public int SolvePart1()
    {
        int[] scores;
        int[] scratches;
        int totalScore = 0;

        foreach (var line in _lines)
        {
            int scoreCount = -1;
            scores = GetScores(line);
            scratches = GetScratches(line);

            scoreCount += scratches.Where(n => scores.Contains(n)).Count();

            totalScore += 1 << scoreCount;
        }

        return totalScore;
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

    private static int[] GetScores(string card)
    {
        string[] scores = card.Split(':')[1]
                            .Trim()
                            .Split('|')[0]
                            .Trim()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return Array.ConvertAll<string, int>(scores, (n => int.Parse(n)));
    }

    private static int[] GetScratches(string card)
    {
        string[] scratches = card.Split('|')[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return Array.ConvertAll<string, int>(scratches, (n => int.Parse(n.Trim())));
    }
}
