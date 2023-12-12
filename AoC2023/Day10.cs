using System.Data;
using System.Reflection.Metadata;
using AoC.Common;
using Microsoft.VisualBasic;

namespace AoC2023;

public class Day10 : ExerciseBase
{
    public Day10(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();

        var map = new List<string>();
        string? line;

        while ((line = _reader.ReadLine()) != null)
        {
            map.Add(line);
        }

        var start = map.Select((s, i) => (i, s.IndexOf('S'))).First(p => p.Item2 != -1);
        var pairNextToStart = GetPairNextToStart(start, map);
        var nextA = pairNextToStart.Item1;
        var nextB = pairNextToStart.Item2;

        var visitedA = new HashSet<(int, int)>() { start };
        var visitedB = new HashSet<(int, int)>() { start };
        var pathA = new Stack<(int, int)>() { };
        var pathB = new Stack<(int, int)>() { };

        while (nextA != nextB)
        {
            pathA.Push(nextA);
            visitedA.Add(nextA);
            nextA = GetNext(nextA, map, visitedA);

            pathB.Push(nextB);
            visitedB.Add(nextB);
            nextB = GetNext(nextB, map, visitedB);
        }

        return (pathA.Count + 1).ToString();
    }

    private (int, int) GetNext((int, int) current, List<string> map, HashSet<(int, int)> visited)
    {
        var y = current.Item1;
        var x = current.Item2;

        var canGoUp = y - 1 >= 0 && "|F7".Contains(map[y - 1][x]) && !visited.Contains((y - 1, x));
        var canGoDown = y + 1 < map.Count && "|LJ".Contains(map[y + 1][x]) && !visited.Contains((y + 1, x));
        var canGoLeft = x - 1 >= 0 && "-FL".Contains(map[y][x - 1]) && !visited.Contains((y, x - 1));
        var canGoRight = x + 1 < map[y].Length && "-7J".Contains(map[y][x + 1]) && !visited.Contains((y, x + 1));

        return map[y][x] switch
        {
            '|' when canGoUp => (y - 1, x),
            '|' when canGoDown => (y + 1, x),
            '-' when canGoLeft => (y, x - 1),
            '-' when canGoRight => (y, x + 1),
            'F' when canGoDown => (y + 1, x),
            'F' when canGoRight => (y, x + 1),
            '7' when canGoDown => (y + 1, x),
            '7' when canGoLeft => (y, x - 1),
            'L' when canGoUp => (y - 1, x),
            'L' when canGoRight => (y, x + 1),
            'J' when canGoUp => (y - 1, x),
            'J' when canGoLeft => (y, x - 1),
            _ => current
        };
    }

    private ((int, int), (int, int)) GetPairNextToStart((int, int) start, List<string> map)
    {
        var y = start.Item1;
        var x = start.Item2;

        var up = y - 1 >= 0 && "|F7".Contains(map[y - 1][x]) ? (y - 1, x) : start;
        var down = y + 1 < map.Count && "|LJ".Contains(map[y + 1][x]) ? (y + 1, x) : start;
        var left = x - 1 >= 0 && "-FL".Contains(map[y][x - 1]) ? (y, x - 1) : start;
        var right = x + 1 < map[y].Length && "-7J".Contains(map[y][x + 1]) ? (y, x + 1) : start;

        var availableOptions = new List<(int, int)>() { up, down, left, right }.Where(p => p != start).ToArray();

        if(availableOptions.Length != 2)
        {
            throw new Exception("invalid map");
        }

        return (availableOptions[0], availableOptions[1]);
        
    }


    public override string SolvePart2()
    {
        return string.Empty;
    }
}
