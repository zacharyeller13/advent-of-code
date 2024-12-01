using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_04;

public class Scratchcards : SolutionBase<int>
{
    private readonly List<HashSet<int>> _scores = new();
    private readonly List<HashSet<int>> _scratchers = new();

    public Scratchcards(string[] fileContents) : base(fileContents)
    {
        foreach (var line in _lines)
        {
            _scores.Add(GetScores(line));
            _scratchers.Add(GetScratchers(line));
        }
    }

    public override int SolvePart1()
    {
        int totalScore = 0;

        for (int i = 0; i < _scores.Count; i++)
        {
            int scoreCount = -1;
            scoreCount += _scores[i].Intersect(_scratchers[i]).Count();

            // If I understand correctly, left-shifting by a negative is undefined
            // And somewhat based on how a specific CPUs evaluate a left shift
            // Still get correct answers w/out this check, but best to be safe
            if (scoreCount > -1)
            {
                totalScore += 1 << scoreCount;
            }
        }

        return totalScore;
    }

    public override int SolvePart2()
    {
        int[] cardCounts = new int[_scores.Count];

        // For each card, check winners
        for (int i = 0; i < _scores.Count; i++)
        {
            cardCounts[i]++;
            int scoreCount = _scores[i].Intersect(_scratchers[i]).Count();

            // For each winner, add an additional next card
            // (e.g. Card 1 wins 2, add additional Card 2 and additional Card 3)
            for (int j = 0; j < scoreCount; j++)
            {
                cardCounts[i + j + 1] += cardCounts[i];
            }
        }
        return cardCounts.Sum();
    }

    private static HashSet<int> GetScores(string card)
    {
        string[] scores = card.Split(':')[1]
                            .Trim()
                            .Split('|')[0]
                            .Trim()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return new HashSet<int>(Array.ConvertAll<string, int>(scores, (n => int.Parse(n))));
    }

    private static HashSet<int> GetScratchers(string card)
    {
        string[] scratches = card.Split('|')[1]
                                .Trim()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return new HashSet<int>(Array.ConvertAll<string, int>(scratches, (n => int.Parse(n.Trim()))));
    }
}
