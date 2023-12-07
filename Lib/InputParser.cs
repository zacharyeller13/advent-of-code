namespace AdventOfCode.Lib;

public static class InputParser
{
    public static (string, string) ValidateArgs(string[] args)
    {
        if (args.Length != 3)
        {
            PrintUsage();
        }
        return ($"{args[0]}/{args[1]}", args[2]);
    }

    public static string[] ParseInput(string inputFile) => File.ReadAllLines(inputFile);
    public static string[] ParseInput(string inputFile, string splitString)
    {
        string text = File.ReadAllText(inputFile);
        return text.Split(splitString, StringSplitOptions.RemoveEmptyEntries);
    }

    private static void PrintUsage()
    {
        Console.WriteLine("Usage: ./AdventOfCode <year> <day> <part>");
        Environment.Exit(1);
    }
}
