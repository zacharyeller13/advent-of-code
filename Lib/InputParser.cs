namespace AdventOfCode.Lib;

public static class InputParser
{
    public static (string, string) ValidateArgs(string[] args) => args.Length switch
    {
        2 => ($"{args[0]}/{args[1]}", "all"),
        3 => ($"{args[0]}/{args[1]}", args[2]),
        _ => PrintUsage()
    };
    public static string[] ParseInput(string inputFile) => File.ReadAllLines(inputFile);

    private static (string, string) PrintUsage()
    {
        Console.WriteLine("Usage: ./AdventOfCode <year> <day> <part>");
        Environment.Exit(1);
        return ("", "");
    }
}
