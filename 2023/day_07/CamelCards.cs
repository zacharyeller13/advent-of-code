using System.Collections;
using System.ComponentModel.DataAnnotations;
using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_07;

public class CamelCards : SolutionBase
{
    private readonly Dictionary<string, int> _handBids = new();

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
        int totalWinnings = 0;
        var sortedHands = _handBids.OrderBy(hand => WeightHand(hand.Key, 2))
            .ThenBy(hand => ReplaceFaceCards(hand.Key, 2), StringComparer.Ordinal).ToList();
        
        for (int i = 0; i < _handBids.Count; i++)
        {
            // Console.WriteLine($"{sortedHands[i]}: {sortedHands[i].Value * (i+1)}");
            totalWinnings += sortedHands[i].Value * (i + 1);
        }
        return totalWinnings;
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

    private static int WeightHand(string hand, int part = 1)
    {
        List<int> cardCounts = CountCards(hand);

        // Doesn't handle "JK3JT: 1, 1, 1, 4"
        // Where original score counts would be J: 2, K: 1, 3: 1, T: 1
        if (part == 2)
        {
            int jCount = hand.Count(c => c == 'J');
            if (jCount > 0)
            {
                // Does flipping them work?
                // No, have to check for where J = 5 -> [] if we remove without check
                // Once done the check, JK3JT: 1, 1, 3; JAJ95: 1, 1, 3 == SUCCESS
                if (jCount != 5)
                {
                    cardCounts.Remove(jCount);
                    cardCounts[^1] += jCount;
                }
            }
            // Console.WriteLine($"{hand}: {string.Join(", ", cardCounts)}");
        }
        
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

    // The Range attribute is cool, though it really does nothing for me here
    // .NET doesn't actually to any validation from the attribute
    private static string ReplaceFaceCards(string hand, [Range(1,2)] int part = 1)
    {
        // Comparing ordinally, so replace with values that would be larger (or smaller in part 2)
        // https://www.barcodefaq.com/ascii-chart-char-set/
        
        char jReplacement = part == 2 ? '1' : ';';
        
        return hand.Replace('T', ':')
            .Replace('J', jReplacement)
            .Replace('Q', '<')
            .Replace('K', '=')
            .Replace('A', '>');
    }  
}