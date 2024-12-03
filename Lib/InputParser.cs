namespace AdventOfCode.Lib;

public static class InputParser
{
    public static (string, string, bool) ValidateArgs(string[] args)
    {
        switch (args.Length)
        {
            case < 3:
                PrintUsage();
                break;
            case > 3:
                return ($"{args[0]}/{args[1]}", args[2], args[3] == "test");
        }

        return ($"{args[0]}/{args[1]}", args[2], false);
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
