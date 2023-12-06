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

        var seedMappings = _reader
            .ReadLine()?.Split(": ")[1].Split(" ")
            .Select(s => new SeedMappping(long.Parse(s)))
            .ToList();

        _ = seedMappings ?? throw new Exception("No seeds data found.");

        MapSeeds(seedMappings);

        var lowestLocation = seedMappings.MinBy(m => m.Location)?.Location ?? -1;

        return lowestLocation.ToString();
    }

    public override string SolvePart2()
    {
        ResetReader();

        return string.Empty;
    }


    private void MapSeeds(List<SeedMappping> seedMappings)
    {
        string? line;
        string source = string.Empty;
        string destination = string.Empty;

        while ((line = _reader.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                // blank line means a mapping is complete
                if (!string.IsNullOrWhiteSpace(source) && !string.IsNullOrWhiteSpace(destination))
                {
                    UpdateUnmapped(source, destination, seedMappings);
                }

                continue;
            }

            // extract mapping info
            if (!char.IsNumber(line[0]))
            {
                var mapDetails = line.Substring(0, line.IndexOf(' ')).Split("-");
                source = mapDetails[0].Capitalize();
                destination = mapDetails[2].Capitalize();
                continue;
            }

            // extract mapping data
            var data = line.Split(" ");
            var length = long.Parse(data[2]);
            var sourceStart = long.Parse(data[1]);
            var sourceEnd = sourceStart + length - 1;
            var destinationStart = long.Parse(data[0]);
            var delta = destinationStart - sourceStart;

            var mappingType = typeof(SeedMappping);
            var sourceProperty = mappingType.GetProperty(source, typeof(long)) ?? throw new Exception($"No {source} property found.");
            var destinationProperty = mappingType.GetProperty(destination, typeof(long)) ?? throw new Exception($"No {destination} property found.");

            foreach (var mapping in seedMappings)
            {
                var sourceValue = (long?)sourceProperty.GetValue(mapping) ?? -1;

                // not in range for current mapping
                if (sourceValue < sourceStart || sourceValue > sourceEnd)
                {
                    continue;
                }

                destinationProperty.SetValue(mapping, sourceValue + delta);
            }
        }

        // update last mapping, becaus missing blank line at the end 
        UpdateUnmapped(source, destination, seedMappings);
    }

    private void UpdateUnmapped(string source, string destination, List<SeedMappping> seedMappings)
    {
        var mappingType = typeof(SeedMappping);
        var sourceProperty = mappingType.GetProperty(source, typeof(long)) ?? throw new Exception($"No {source} property found.");
        var destinationProperty = mappingType.GetProperty(destination, typeof(long)) ?? throw new Exception($"No {destination} property found.");

        foreach (var mapping in seedMappings)
        {
            if ((long?)destinationProperty.GetValue(mapping) != -1)
            {
                continue;
            }

            destinationProperty.SetValue(mapping, sourceProperty.GetValue(mapping));
        }
    }

    private record SeedMappping(long Seed, long Soil = -1, long Fertilizer = -1, long Water = -1, long Light = -1, long Temperature = -1, long Humidity = -1, long Location = -1);

    private record SeedRange(long Start, long End);

    private class Mapping(long min, long max, long delta)
    {
        public long Min { get; } = min;
        public long Max { get; } = max;
        public long Delta { get; } = delta;
        public List<Mapping> Children { get; } = new List<Mapping>();
    }
}

internal static class StringExtensions
{
    public static string Capitalize(this string s) => s switch
    {
        null => throw new ArgumentNullException(nameof(s)),
        "" => throw new ArgumentException($"{nameof(s)} cannot be empty", nameof(s)),
        _ => s[0].ToString().ToUpper(CultureInfo.InvariantCulture) + s[1..]
    };
}
