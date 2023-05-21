using AoC.Common;

namespace AoC2015;

public class Day3 : ExerciseBase
{
    public Day3(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();
        (int X, int Y) position = (0, 0);
        var visitedHouses = new HashSet<(int,int)>();
        visitedHouses.Add(position);
        char c;
        
        while((c = (char)_reader.Read()) != char.MaxValue)
        {
            UpdatePosition(ref position, c);
            visitedHouses.Add(position);
        }

        return visitedHouses.Count.ToString();
    }


    public override string SolvePart2()
    {
        ResetReader();
        (int X, int Y) position = (0, 0);
        (int X, int Y) altPosition = (0, 0);
        var visitedHouses = new HashSet<(int,int)>();
        visitedHouses.Add(position);
        var altTurn = false;
        char c;
        
        while((c = (char)_reader.Read()) != char.MaxValue)
        {
            if(altTurn) {
                UpdatePosition(ref altPosition, c);
                visitedHouses.Add(altPosition);
            } else {
                UpdatePosition(ref position, c);
                visitedHouses.Add(position);
            }

            altTurn = !altTurn;
        }

        return visitedHouses.Count.ToString();
    }

    private void UpdatePosition(ref (int X, int Y) position, char c)
    {
        switch (c)
        {
            case '>':
                position.X++;
                break;
            case '<':
                position.X--;
                break;
            case '^':
                position.Y++;
                break;
            case 'v':
                position.Y--;
                break;
            default:
                break;
        }
    }
}