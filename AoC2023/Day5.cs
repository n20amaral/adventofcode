using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using AoC.Common;

namespace AoC2023;

public class Day5 : ExerciseBase
{
    public Day5(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();

        var seeds = _reader.ReadLine()?.Substring("seeeds:".Length).Split(' ').Select(long.Parse).ToArray();
        _ = seeds ?? throw new InvalidDataException("No seeds found"); 
        
        // var processed = new bool[seeds.Count];
        // string? line;
        // while((line = _reader.ReadLine()) != null)
        // {
        //     if(string.IsNullOrWhiteSpace(line) || !char.IsNumber(line[0]))
        //     {
        //         processed = new bool[seeds.Count];
        //         continue;
        //     }

        //     var parts = line.Split(' ');
        //     var length = long.Parse(parts[2]);
        //     var fromMin = long.Parse(parts[1]);
        //     var fromMax = fromMin + length;
        //     var to = long.Parse(parts[0]);
        //     var delta = to - fromMin;

            
        //     for (int i = 0; i < seeds.Count; i++)
        //     {
        //         if(processed[i] || seeds[i] < fromMin || seeds[i] > fromMax)
        //         {
        //             continue;
        //         }
                
        //         seeds[i] += delta;
        //         processed[i] = true;
        //     }
        // }

        ProcessSeeds(seeds, _reader.ReadToEnd().Split("\r\n"));

        return seeds.Min().ToString();
    }

    public override string SolvePart2()
    {
        return string.Empty;
    }

    private void ProcessSeeds(long[] seeds, string[] lines)
    {
        var processed = new bool[seeds.Length];
        
        foreach(var line in lines)
        {
            if(string.IsNullOrWhiteSpace(line) || !char.IsNumber(line[0]))
            {
                processed = new bool[seeds.Length];
                continue;
            }

            var parts = line.Split(' ');
            var length = long.Parse(parts[2]);
            var fromMin = long.Parse(parts[1]);
            var fromMax = fromMin + length;
            var to = long.Parse(parts[0]);
            var delta = to - fromMin;

            for (int i = 0; i < seeds.Length; i++)
            {
                if(processed[i] || seeds[i] < fromMin || seeds[i] > fromMax)
                {
                    continue;
                }
                
                seeds[i] += delta;
                processed[i] = true;
            }
        }
    }
}
