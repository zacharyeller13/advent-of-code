using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_09;

public class MirageMaintenance : SolutionBase<int>
{
    public MirageMaintenance(string[] fileContents) : base(fileContents)
    {
    }

    public override int SolvePart1()
    {
        int extrapolatedValues = 0;
        foreach (string line in _lines)
        {
            int[] intLine = Array.ConvertAll(line.Split(), int.Parse);
            // Create sequences stack with each subsequent sequence till we reach 
            // a sequence of all zeros
            Stack<int[]> sequences = FindZeroSequence(intLine);

            // Pop each sequence and add a new value at the end
            // without actually adding it to the array
            // just calculate what the new value would be one each sequence
            // until we get to the top line
            int nextInt = 0;
            while (sequences.Count > 0)
            {
                int[] sequence = sequences.Pop();
                nextInt += sequence[^1];
            }
            extrapolatedValues += (nextInt + intLine[^1]);
        }

        return extrapolatedValues;
    }

    public override int SolvePart2()
    {
        int extrapolatedValues = 0;
        foreach (string line in _lines)
        {
            int[] intLine = Array.ConvertAll(line.Split(), int.Parse);
            // Create sequences stack with each subsequent sequence till we reach 
            // a sequence of all zeros
            Stack<int[]> sequences = FindZeroSequence(intLine);

            // Pop each sequence and subtract new value at front
            // until we get to the top line
            int nextInt = 0;
            while (sequences.Count > 0)
            {
                int[] sequence = sequences.Pop();
                nextInt = sequence[0] - nextInt;
            }
            extrapolatedValues += (intLine[0] - nextInt);
        }

        return extrapolatedValues;
    }

    private static Stack<int[]> FindZeroSequence(int[] intLine)
    {
        Stack<int[]> sequences = new();
            
        while (intLine.Any(n => n != 0))
        {
            int[] sequence = new int[intLine.Length - 1];
            for (int i = 0; i < intLine.Length - 1; i++)
            {
                sequence[i] = intLine[i + 1] - intLine[i];
            }
            sequences.Push(sequence);
            intLine = sequence;
        }
        return sequences;
    }
}