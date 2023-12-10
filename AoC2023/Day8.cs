using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Data;
using System.IO.Compression;
using AoC.Common;
using Microsoft.VisualBasic;

namespace AoC2023;

public class Day8 : ExerciseBase
{
    private readonly long PART2_RESULT = -1;
    private bool _skipPart2 = false;

    public Day8(TextReader reader) : base(reader)
    {
        if(reader is not StringReader)
        {
            _skipPart2 = true;
        }
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
        // TODO: Part2 needs a more efficient solution. This one takes too long to run (hours).
        if(_skipPart2)
        {
            return PART2_RESULT.ToString();
        }

        var map = ParseInput(out string directions);

        var allPositions = map.Keys.ToList();
        var endsWithZ = allPositions.Select(p => p.EndsWith('Z')).ToArray();

        var leftRightTargets = allPositions.Select(p => new int[] { allPositions.IndexOf(map[p].Item1), allPositions.IndexOf(map[p].Item2) }).ToList();
        var moving = directions.Select(d => d == 'L' ? 0 : 1).ToArray();

        var startPositions = allPositions.Where(p => p.EndsWith('A')).Select(p => allPositions.IndexOf(p)).ToArray();

        var allReachedToZ = false;
        var to = 0;
        var steps = 0;

        while (!allReachedToZ)
        {
            allReachedToZ = true;

            for (int i = 0; i < startPositions.Length; i++)
            {
                startPositions[i] = leftRightTargets[startPositions[i]][moving[to]];
                allReachedToZ &= endsWithZ[startPositions[i]];
            }

            to = (to + 1) % moving.Length;
            steps++;
        }

        return steps.ToString();
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
