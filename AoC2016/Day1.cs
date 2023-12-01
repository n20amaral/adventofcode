using System.Runtime.CompilerServices;
using AoC.Common;

namespace AoC2016;

public class Day1 : ExerciseBase
{
    public Day1(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();

        var coords = new int[] {0,0};
        var directions = _reader.ReadToEnd().Split(", ");
        var currentDirection = char.MinValue; 

        foreach (var direction in directions)
        {
            var distance = int.Parse(direction[1..]);
            currentDirection = MakeTurn(currentDirection, direction[0]);

            switch (currentDirection)
            {
                case 'R':
                    coords[0] += distance;
                    break;
                case 'L':
                    coords[0] -= distance;
                    break;
                case 'U':
                    coords[1] += distance;
                    break;
                case 'D':
                    coords[1] -= distance;
                    break;
                default:
                    throw new Exception("Invalid direction");
            }
        }

        return $"{Math.Abs(coords[0] + coords[1])}";
    }

    public override string SolvePart2()
    {
        ResetReader();

        var coords = new int[] {0,0};
        var coordsHistory = new List<int[]> { new int[] {0,0} };
        var directions = _reader.ReadToEnd().Split(", ");
        var currentDirection = char.MinValue; 

        foreach (var direction in directions)
        {
            var distance = int.Parse(direction[1..]);
            currentDirection = MakeTurn(currentDirection, direction[0]);
            
            for (int i = 0; i < distance; i++)
            {
                switch (currentDirection)
                {
                    case 'R':
                        coords[0]++;
                        break;
                    case 'L':
                        coords[0]--;
                        break;
                    case 'U':
                        coords[1]++;
                        break;
                    case 'D':
                        coords[1]--;
                        break;
                    default:
                        throw new Exception("Invalid direction");
                }
                
                if (coordsHistory.Any(c => c[0] == coords[0] && c[1] == coords[1]))
                {
                    return $"{Math.Abs(coords[0] + coords[1])}";
                }

                coordsHistory.Add([coords[0], coords[1]]);
            }
        }

        return "0";
    }

    private char MakeTurn(char currentDirection, char turn)
    {
        if (currentDirection == char.MinValue)
        {
            return turn;
        }

        return currentDirection switch
        {
            'R' or 'L' => turn == currentDirection ? 'D' : 'U',
            'D' => turn == 'R' ? 'L' : 'R',
            'U' => turn == 'R' ? 'R' : 'L',
            _ => throw new Exception("Invalid direction"),
        };
    }
}
