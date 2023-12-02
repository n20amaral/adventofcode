using AoC.Common;

namespace AoC2021;

public class Day1 : ExerciseBase
{
    public Day1(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();

        var line = string.Empty;
        var timesIncreased = 0;
        var previous = int.Parse(_reader.ReadLine());

        while ((line = _reader.ReadLine()) != null)
        {
            var current = int.Parse(line);

            if(current > previous)
            {
                timesIncreased++;
            }

            previous = current;
        }

        return timesIncreased.ToString();
    }

    public override string SolvePart2()
    {
        ResetReader();

        var queue = new Queue<int>(3);
        var line = string.Empty;
        var timesIncreased = 0;
        var previous = 0;

        while ((line = _reader.ReadLine()) != null)
        {
            var current = int.Parse(line);

            if (queue.Count < 3)
            {
                queue.Enqueue(current);
                continue;
            }

            previous = queue.Sum();
            queue.Dequeue();
            queue.Enqueue(current);

            if(queue.Sum() > previous)
            {
                timesIncreased++;
            }
        }

        return timesIncreased.ToString();
    }
}
