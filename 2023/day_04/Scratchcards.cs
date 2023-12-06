﻿using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_04;

public class Scratchcards : ISolution
{
    private readonly string[] _lines;
    private readonly List<int[]> _scores = new();
    private readonly List<int[]> _scratchers = new();

    public Scratchcards(string[] fileContents)
    {
        _lines = fileContents;
        foreach (var line in _lines)
        {
            _scores.Add(GetScores(line));
            _scratchers.Add(GetScratchers(line));
        }
    }

    public int SolvePart1()
    {
        int totalScore = 0;

        for (int i = 0; i < _scores.Count; i++)
        {
            int scoreCount = -1;

            var scratchSet = new HashSet<int>(_scratchers[i]);
            var scoreSet = new HashSet<int>(_scores[i]);
            scoreCount += scoreSet.Intersect(scratchSet).Count();

            totalScore += 1 << scoreCount;
        }

        return totalScore;
    }

    public int SolvePart2()
    {
        // For each card, check winners
        // For each winner, add an additional next card
        // (e.g. Card 1 wins 2, add additional Card 2 and additional Card 3)
        // Repeat until no more cards to process
        // How many total cards are processed after this?
        // Constraint: Cards will never make you copy a card past the end of the table
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

    private static int[] GetScratchers(string card)
    {
        string[] scratches = card.Split('|')[1]
                                .Trim()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return Array.ConvertAll<string, int>(scratches, (n => int.Parse(n.Trim())));
    }
}
