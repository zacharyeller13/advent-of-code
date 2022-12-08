static int checkMarker(string stream, int markerLength)
{
    string group = "";
    int i = 0;

    while (i <= stream.Length - markerLength)
    {
        group = stream.Substring(i, markerLength);
        HashSet<char> groupSet = group.ToHashSet();

        if (group.Length == groupSet.Count)
        {
            return i + markerLength;
        }

        i++;
    }

    return -1;
}

string inputs = File.ReadAllText("../inputs");

Console.WriteLine(checkMarker(inputs, 14));
