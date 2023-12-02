namespace AdventOfCode._2023.day_01;

public class Trebuchet
{
    private readonly string[] _lines;
    public IEnumerable<int> CalibrationValues { get; }

    public Trebuchet(string[] fileContents)
    {
        _lines = fileContents;
        CalibrationValues = GetCalibrationValues();
    }

    public void PrintLines()
    {
        foreach (string line in _lines)
        {
            Console.WriteLine(line);
        }
    }

    private IEnumerable<int> GetCalibrationValues()
    {
        foreach(string line in _lines)
        {
            yield return GetCalibrationValue(line);
        }
    }

    private int GetCalibrationValue(string line)
    {
        string nums = "";
        foreach (char character in line)
        {
            if (char.IsDigit(character))
            {
                nums += character;
            }
        }

        if (nums.Length < 2)
        {
            nums += nums;
        }
        else
        {
            nums = $"{nums[0]}{nums[^1]}";
        }

        return int.Parse(nums);
    }
}
