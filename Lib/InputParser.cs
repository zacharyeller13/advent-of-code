namespace AdventOfCode.Lib;

public static class InputParser
{
    public static List<string> ParseInput(string inputFile)
    {
        string[] lines = inputFile.Split('\n');
        return lines.ToList();
    }
}
