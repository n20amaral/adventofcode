using System.Linq;
using AoC.Common;

namespace AoC2022;

public class Day1 : ExerciseBase
{
    public Day1(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();
        var mostCarrying = 0;
        var current = 0;
        string? line;

        while ((line = _reader.ReadLine()) != null)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                current += int.Parse(line);
                continue;
            }

            if (current > mostCarrying)
            {
                mostCarrying = current;
            }

            current = 0;
        }

        mostCarrying = current > mostCarrying ? current : mostCarrying;

        return mostCarrying.ToString();
    }

    public override string SolvePart2()
    {
        ResetReader();
        var topCarrying = new List<int>();
        var current = 0;
        string? line;

        while ((line = _reader.ReadLine()) != null)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                current += int.Parse(line);
                continue;
            }

            if (topCarrying.Count < 3)
            {
                topCarrying.Add(current);
            }
            else if (current > topCarrying.Min())
            {
                topCarrying.Remove(topCarrying.Min());
                topCarrying.Add(current);
            }

            current = 0;
        }

        if(current > topCarrying.Min())
        {
            topCarrying.Remove(topCarrying.Min());
            topCarrying.Add(current);
        }

        return topCarrying.Sum().ToString();   
    }
}
