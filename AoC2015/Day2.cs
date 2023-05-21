using AoC.Common;

namespace AoC2015;

public class Day2 : ExerciseBase
{
    public Day2(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();
        var line = String.Empty;
        var totalArea = 0;
        while((line = _reader.ReadLine()) != null)
        {
            var dimensions = line.Split("x").Select(m => int.Parse(m)).ToArray();
            var surfaceAreas = new List<int> {
                2 * dimensions[0] * dimensions[1],
                2 * dimensions[1] * dimensions[2],
                2 * dimensions[2] * dimensions[0]
            };

            totalArea += surfaceAreas.Sum() + (surfaceAreas.Min() / 2) ;
        }

        return totalArea.ToString();
    }

    public override string SolvePart2()
    {
        ResetReader();
        var line = String.Empty;
        var totalRibbon = 0;
        while((line = _reader.ReadLine()) != null)
        {
            var dimensions = line.Split("x").Select(m => int.Parse(m)).ToList();
            dimensions.Sort();
            var ribbon = new List<int> {
                (dimensions[0] * 2) + (dimensions[1] * 2),
                dimensions[0] * dimensions[1] * dimensions[2]
            };

            totalRibbon += ribbon.Sum();
        }

        return totalRibbon.ToString();
    }
}