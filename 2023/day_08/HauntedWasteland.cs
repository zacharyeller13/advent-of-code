using System.Numerics;
using AdventOfCode.Lib;

namespace AdventOfCode._2023.day_08;

public class HauntedWasteland : SolutionBase
{
    private readonly string _instructions;
    private readonly Dictionary<string, (string Left, string Right)> _nodes = new();

    public HauntedWasteland(string[] fileContents) : base(fileContents)
    {
        _instructions = _lines[0];
        
        foreach (string line in _lines[1..])
        {
            string[] node = line.Split('=', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            string[] nodeValues = node[1].Split(',', StringSplitOptions.TrimEntries);
            _nodes.Add(node[0], (nodeValues[0].Replace("(", ""), nodeValues[1].Replace(")", "")));
        }
    }

    public override int SolvePart1() => FindPathToZ("AAA");

    public BigInteger SolvePart2()
    {
        var startNodes = _nodes.Keys.Where(key => key.EndsWith('A'));
        Dictionary<string, BigInteger> pathsToZ = new();
        foreach (string startNode in startNodes)
        {
            pathsToZ.Add(startNode, FindPathToZ(startNode));
        }
        
        foreach (var keyValuePair in pathsToZ)
        {
            Console.WriteLine(keyValuePair);
        }
        Console.WriteLine(string.Join(", ", pathsToZ.Values));
        
        return MathExtensions.LCM(pathsToZ.Values.ToArray());
    }

    private int FindPathToZ(string startNode)
    {
        string currentNode = startNode;
        int steps = 0;
        int instructionIndex = 0;
        
        while (!currentNode.EndsWith('Z'))
        {
            char instruction = _instructions[instructionIndex];
            currentNode = instruction == 'L' ? _nodes[currentNode].Left : _nodes[currentNode].Right;
            instructionIndex = (instructionIndex + 1) % _instructions.Length;
            steps++;
        }

        return steps;
    }
}