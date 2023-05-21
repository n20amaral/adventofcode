using AoC.Common;

namespace AoC2015;

public class Day1 : ExerciseBase
{
    public Day1(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();
        var currentFloor = 0;
        char c;
        while((c = (char)_reader.Read()) != char.MaxValue)
        {
            if(c == '(') 
            {
                currentFloor++;
            }
            else if (c == ')')
            {
                currentFloor--;
            }
        }

        return currentFloor.ToString();
    }

    public override string SolvePart2()
    {
        ResetReader();
        var currentFloor = 0;
        var position = 0;
        char c;
        while((c = (char)_reader.Read()) != char.MaxValue)
        {
            if(c == '(') 
            {
                currentFloor++;
                position++;
            }
            else if (c == ')')
            {
                currentFloor--;
                position++;
            }

            if(currentFloor == -1)
            {
                break;
            }
        }

        return position.ToString();
    }
}
