using AoC.Common;

namespace AoC2018;

public class Day1 : ExerciseBase
{
    public Day1(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();

        var sum = 0;
        string line;
        while ((line = _reader.ReadLine()!) != null)
        {
            sum += int.Parse(line);
        }

        return sum.ToString();
    }

    public override string SolvePart2()
    {
        ResetReader();

        var sum = 0;
        var frequencies = new List<int>() { 0 };
        
        while (true)
        {

            var line = _reader.ReadLine();

            if (line == null)
            {

                ResetReader();                
                continue;
            }

            sum += int.Parse(line);

            if (frequencies.Contains(sum))
            {
                break;
            }

            frequencies.Add(sum);
        }

        return sum.ToString();
    }
}
