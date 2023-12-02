using AoC.Common;

namespace AoC2019;

public class Day1 : ExerciseBase
{
    public Day1(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();
        
        int sum = 0;
        var line = string.Empty;

        while((line = _reader.ReadLine()) != null)
        {
            var mass = int.Parse(line);

            sum += (int)Math.Floor(mass / 3.0) - 2;
        }

        return sum.ToString();
    }

    public override string SolvePart2()
    {
        ResetReader();

        int sum = 0;
        var line = string.Empty;

        while((line = _reader.ReadLine()) != null)
        {
            var mass = int.Parse(line);

            sum += CalculateFuel(mass);
        }
        
        return sum.ToString();
    }

    private int CalculateFuel(int mass)
    {
        var fuel = (int)Math.Floor(mass / 3.0) - 2;

        if (fuel < 0)
        {
            return 0;
        }

        return fuel + CalculateFuel(fuel);
    }
}
