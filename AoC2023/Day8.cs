using AoC.Common;

namespace AoC2023;

public class Day8 : ExerciseBase
{
    public Day8(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        var map = ParseInput(out string directions);
        var steps = 0;
        var position = "AAA";
        var i = 0;

        while (position != "ZZZ")
        {
            position = directions[i] switch
            {
                'L' => map[position].Item1,
                'R' => map[position].Item2,
                _ => throw new Exception("invalid direction")
            };

            if (++i == directions.Length)
            {
                i = 0;
            }

            steps++;
        }

        return steps.ToString();
    }

    public override string SolvePart2()
    {
        return string.Empty;
    }

    private Dictionary<string, Tuple<string, string>> ParseInput(out string directions)
    {
        ResetReader();
        directions = _reader.ReadLine() ?? throw new Exception("no directions found");

        var map = new Dictionary<string, Tuple<string, string>>();

        string? line;
        while ((line = _reader.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var parts = line.Split(" = ");
            var to = parts[1].Substring(1, parts[1].Length - 2).Split(", ");
            map.Add(parts[0], new Tuple<string, string>(to[0], to[1]));
        }

        return map;
    }
}
