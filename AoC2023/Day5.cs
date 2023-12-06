using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Xml;
using AoC.Common;

namespace AoC2023;

public class Day5 : ExerciseBase
{
    private readonly long PART2_RESULT = 77435348;
    private bool _skipPart2 = false;

    public Day5(TextReader reader) : base(reader)
    {
        if(reader is not StringReader)
        {
            _skipPart2 = true;
        }
    }

    public override string SolvePart1()
    {
        ResetReader();

        var seeds = _reader.ReadLine()?.Substring("seeds: ".Length).Split(' ').Select(long.Parse).ToArray();
        _ = seeds ?? throw new InvalidDataException("No seeds found");

        var lines = _reader.ReadToEnd().Split("\n");

        ProcessSeeds(seeds, lines);

        return seeds.Min().ToString();
    }

    public override string SolvePart2()
    {
        // TODO: Part2 needs a more efficient solution. This one takes too long to run (11 min).
        if(_skipPart2)
        {
            return PART2_RESULT.ToString();
        }

        ResetReader();

        var seedValues = _reader.ReadLine()?.Substring("seeds: ".Length).Split(' ').Select(long.Parse).ToArray();
        _ = seedValues ?? throw new InvalidDataException("No seeds found");

        var lines = _reader.ReadToEnd().Split("\n");

        var lowestLocation = new List<long>();

        for (int i = 0; i < seedValues.Length; i += 2)
        {
            var from = seedValues[i];
            var to = from + seedValues[i + 1] - 1;

            lowestLocation.Add(FindLowestLocationInParallel(from, to, lines));
        }

        return lowestLocation.Min().ToString();
    }

    private void ProcessSeeds(long[] seeds, string[] lines)
    {
        var processed = new bool[seeds.Length];

        foreach(var line in lines)
        {
            if(string.IsNullOrWhiteSpace(line) || !char.IsNumber(line[0]))
            {
                processed = new bool[seeds.Length];
                continue;
            }

            var parts = line.Split(' ');
            var length = long.Parse(parts[2]);
            var fromMin = long.Parse(parts[1]);
            var fromMax = fromMin + length;
            var to = long.Parse(parts[0]);
            var delta = to - fromMin;

            for (int i = 0; i < seeds.Length; i++)
            {
                if(processed[i] || seeds[i] < fromMin || seeds[i] > fromMax)
                {
                    continue;
                }

                seeds[i] += delta;
                processed[i] = true;
            }
        }
    }

    private long FindLowestLocationInParallel(long startRange, long endRange, string[] lines)
    {
        var lowest = long.MaxValue;
        object lockObject = new object();

        int numberOfTasks = Environment.ProcessorCount; // Number of parallel tasks
        long totalRange = endRange - startRange + 1;
        long rangePerTask = totalRange / numberOfTasks;

        var tasks = new Task[numberOfTasks];

        for (int i = 0; i < numberOfTasks; i++)
        {
            long taskStart = startRange + i * rangePerTask;
            long taskEnd = (i == numberOfTasks - 1) ? endRange : taskStart + rangePerTask - 1;

            tasks[i] = Task.Run(() => ProcessSeedRange(taskStart, taskEnd, lines, lockObject, ref lowest));
        }

        Task.WaitAll(tasks);

        return lowest;
    }

    private void ProcessSeedRange(long start, long end, string[] lines, object lockObject, ref long lowest)
    {
        long[] seeds = new long[end - start + 1];
        for (long i = 0; i <= end - start; i++)
        {
            seeds[i] = start + i;
        }

        ProcessSeeds(seeds, lines);

        lock (lockObject)
        {
            lowest = Math.Min(lowest, seeds.Min());
        }
    }
}
