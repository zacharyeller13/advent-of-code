namespace AdventOfCode.Lib;

public static class InputParser
{
    public static string ValidateArgs(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: ./AdventOfCode <year> <day>");
            Environment.Exit(1);
        }

        return $"{args[0]}/{args[1]}";
    }
    public static string[] ParseInput(string inputFile) => File.ReadAllLines(inputFile);
}
