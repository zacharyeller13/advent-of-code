namespace AdventOfCode._2024.utils;

public static class HashSetExtensions
{
    public static bool ContainsAll(this HashSet<string> set, IEnumerable<string> strings) => strings.All(set.Contains);
}