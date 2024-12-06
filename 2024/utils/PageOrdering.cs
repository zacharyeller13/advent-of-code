using System.Text;

namespace AdventOfCode._2024.utils;

public record PageOrdering
{
    public HashSet<string> After { get; } = [];

    public override string ToString()
    {
        StringBuilder str = new();
        
        str.Append("After: [");
        foreach (string i in After)
        {
            str.Append(i);
            str.Append(',');
        }
        str.Append(']');

        return str.ToString();
    }
}
