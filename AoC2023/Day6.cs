using AoC.Common;

namespace AoC2023;

public class Day6 : ExerciseBase
{
    public Day6(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();

        var times = _reader.ReadLine()?
            .Split(':')[1]
            .Split(' ').Where(s => s.Length > 0).Select(long.Parse)
            .ToArray();
        _ = times ?? throw new Exception("Couldn't get time values");
        var distances = _reader.ReadLine()?
            .Split(':')[1]
            .Split(' ').Where(s => s.Length > 0).Select(long.Parse)
            .ToArray();
        _ = distances ?? throw new Exception("Couldn't get distance values");
        
        var waysToBeat = new int[times.Length];

        for (int i = 0; i < waysToBeat.Length; i++)
        {
            waysToBeat[i] = CountWaysToBeat(times[i], distances[i]);
        }

        return waysToBeat.Aggregate((a,b) => a*b).ToString();
    }
    public override string SolvePart2()
    {
        ResetReader();

        var time = _reader.ReadLine()?
            .Split(':')[1]
            .Replace(" ", "") ?? string.Empty;
            
        var distance = _reader.ReadLine()?
            .Split(':')[1]
            .Replace(" ", "") ?? string.Empty;

        return CountWaysToBeat(long.Parse(time), long.Parse(distance)).ToString();
    }

    private int CountWaysToBeat(long time, long distance)
    {
        var ways = 0;
        var pressing = 0;

        while(time - pressing > 0)
        {
            var timeAvailable = time - pressing;
            var result = timeAvailable * pressing;

            if(ways > 0 && result <= distance)
            {
                break;
            }

            if(result > distance)
            {
                ways++;
            }

            pressing++;
        }

        return ways;
    }
}
