using AoC.Common;

namespace AoC2020;

public class Day1 : ExerciseBase
{
    public Day1(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();

        string? line;
        var set = new HashSet<int>();

        while ((line = _reader.ReadLine()) != null)
        {
            var current = int.Parse(line);

            if(set.Any(n => n + current == 2020))
            {
                return (current * (2020 - current)).ToString();
            }

            set.Add(current);
        }

        return "0";
    }

    public override string SolvePart2()
    {
        ResetReader();

        string? line;
        var set = new HashSet<int>();

        while ((line = _reader.ReadLine()) != null)
        {
            var current = int.Parse(line);

            foreach (var number in set)
            {
                if (set.Any(n => n + current + number == 2020))
                {
                    return (current * number * (2020 - current - number)).ToString();
                }
            }

            set.Add(current);
        }

        return "0";
    }
}
