static int checkMarker(string stream)
{
    string group = "";
    int i = 0;

    while (i <= stream.Length - 4)
    {
        group = stream.Substring(i, 4);
        HashSet<char> groupSet = group.ToHashSet();

        if (group.Length == groupSet.Count)
        {
            return i + 4;
        }

        i++;
    }

    return -1;
}

string inputs = System.IO.File.ReadAllText("day_6/inputs");

Console.WriteLine(checkMarker(inputs));

