using System.Collections;
using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_07;

public class CamelCards : SolutionBase
{
    private static readonly Dictionary<char, int> CardWeights = new()
    {
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { 'T', 10 },
        { 'J', 11 },
        { 'Q', 12 },
        { 'K', 13 },
        { 'A', 14 },
    };

    private Dictionary<string, int> _handBids = new();

    public CamelCards(string[] fileContents) : base(fileContents)
    {
        foreach (string line in fileContents)
        {
            _handBids.Add(line.Split()[0], int.Parse(line.Split()[1]));
        }
    }

    public override int SolvePart1()
    {
        int totalWinnings = 0;
        var sortedHands = _handBids.OrderBy(hand => WeightHand(hand.Key))
            .ThenBy(hand => ReplaceFaceCards(hand.Key), StringComparer.Ordinal).ToList();

        for (int i = 0; i < _handBids.Count; i++)
        {
            // Console.WriteLine($"{sortedHands[i]}: {sortedHands[i].Value * (i+1)}");
            totalWinnings += sortedHands[i].Value * (i + 1);
        }

        return totalWinnings;
    }

    public override int SolvePart2()
    {
        return base.SolvePart2();
    }

    private static List<int> CountCards(string hand)
    {
        List<int> cardCounts = new();
        foreach (char c in new HashSet<char>(hand))
        {
            cardCounts.Add(hand.Count(card => card == c));
        }

        cardCounts.Sort();
        return cardCounts;
    }

    private static int WeightHand(string hand)
    {
        List<int> cardCounts = CountCards(hand);
        if (cardCounts.SequenceEqual(new[] { 1, 1, 1, 1, 1 }))
        {
            return 1;
        }

        if (cardCounts.SequenceEqual(new[] { 1, 1, 1, 2 }))
        {
            return 2;
        }

        if (cardCounts.SequenceEqual(new[] { 1, 2, 2 }))
        {
            return 3;
        }

        if (cardCounts.SequenceEqual(new[] { 1, 1, 3 }))
        {
            return 4;
        }

        if (cardCounts.SequenceEqual(new[] { 2, 3 }))
        {
            return 5;
        }

        if (cardCounts.SequenceEqual(new[] { 1, 4 }))
        {
            return 6;
        }

        if (cardCounts.SequenceEqual(new[] { 5 }))
        {
            return 7;
        }

        return 0;
    }

    private static string ReplaceFaceCards(string hand)
    {
        return hand.Replace('T', ':')
            .Replace('J', ';')
            .Replace('Q', '<')
            .Replace('K', '=')
            .Replace('A', '>');
    }
}