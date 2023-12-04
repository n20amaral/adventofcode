using System.ComponentModel;
using System.Text;
using AoC.Common;

namespace AoC2023;

public class Day3 : ExerciseBase
{
    public Day3(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();

        var previous = string.Empty;
        var current = _reader.ReadLine() ?? string.Empty;
        var next = string.Empty;
        var sum = 0;

        while ((next = _reader.ReadLine()) != null)
        {
            sum += SumPartNumbers(previous, current, next);

            previous = current;
            current = next;
        }

        sum += SumPartNumbers(previous, current, string.Empty);

        return sum.ToString();
    }

    public override string SolvePart2()
    {
        ResetReader();

        var previous = string.Empty;
        var current = _reader.ReadLine() ?? string.Empty;
        var next = string.Empty;
        var sum = 0;

        while ((next = _reader.ReadLine()) != null)
        {
            sum += SumGearRatio(previous, current, next);

            previous = current;
            current = next;
        }

        sum += SumGearRatio(previous, current, string.Empty);

        return sum.ToString();
    }

    private int SumPartNumbers(string previous, string current, string next)
    {
        var sum = 0;
        var partNumbers = new Dictionary<int, string>();

        for (int i = 0; i < current.Length; i++)
        {
            if (char.IsNumber(current[i]))
            {
                var index = i;
                var number = current[i].ToString();

                while (++i < current.Length && char.IsNumber(current[i]))
                {
                    number += current[i];
                }

                partNumbers.Add(index, number);
            }
        }

        foreach (var partNumber in partNumbers)
        {
            var index = partNumber.Key;
            var number = partNumber.Value;

            var sb = new StringBuilder();

            var isOnLeftEdge = index == 0;
            var isOnRightEdge = index + number.Length == current.Length;
            var initial = isOnLeftEdge ? 0 : index - 1;
            var final = isOnRightEdge ? index + number.Length - 1 : index + number.Length;

            if (isOnLeftEdge)
            {
                sb.Append(current[final]);
            }
            else if (isOnRightEdge)
            {
                sb.Append(current[initial]);
            }
            else
            {
                sb.Append(current[initial]);
                sb.Append(current[final]);
            }

            if (!string.IsNullOrEmpty(previous))
            {
                sb.Append(previous.AsSpan(initial, isOnRightEdge ? number.Length + 1 : number.Length + 2));
            }

            if (!string.IsNullOrEmpty(next))
            {
                sb.Append(next.AsSpan(initial, isOnRightEdge ? number.Length + 1 : number.Length + 2));
            }

            if (sb.ToString().Replace(".", "").Count() > 0)
            {
                sum += int.Parse(number);
            }
        }

        return sum;
    }

    private int SumGearRatio(string previous, string current, string next)
    {
        var sum = 0;

        for (int i = 0; i < current.Length; i++)
        {
            if (current[i] != '*')
            {
                continue;
            }

            var numbers = new List<int>();

            var left = DiscoverNumber(current[0..i], false);
            var right = DiscoverNumber(current[(i + 1)..], true);

            // ..123*.
            if (!string.IsNullOrWhiteSpace(left))
            {
                numbers.Add(int.Parse(left));
            }

            // .*123..
            if (!string.IsNullOrWhiteSpace(right))
            {
                numbers.Add(int.Parse(right));
            }

            numbers.AddRange(ExtractGearPartsFromAdjacentLine(previous, i));
            numbers.AddRange(ExtractGearPartsFromAdjacentLine(next, i));

            if (numbers.Count == 2)
            {
                sum += numbers.Aggregate((a, b) => a * b);
            }
        }

        return sum;
    }

    private IEnumerable<int> ExtractGearPartsFromAdjacentLine(string line, int middleIndex)
    {
        var parts = new List<int>();
        var left = string.IsNullOrWhiteSpace(line) ? string.Empty : DiscoverNumber(line[0..middleIndex], false);
        var right = string.IsNullOrWhiteSpace(line) ? string.Empty : DiscoverNumber(line[(middleIndex + 1)..], true);
        var middle = !string.IsNullOrWhiteSpace(line) && char.IsNumber(line[middleIndex]) ? $"{left}{line[middleIndex]}{right}" : string.Empty;

        // ..123..  .123... ...123.
        // ...*...  ...*... ...*...
        if (!string.IsNullOrWhiteSpace(middle))
        {
            parts.Add(int.Parse(middle));
        }

        // 123....
        // ...*...
        if (!string.IsNullOrWhiteSpace(left) && string.IsNullOrWhiteSpace(middle))
        {
            parts.Add(int.Parse(left));
        }

        // ....123
        // ...*...
        if (!string.IsNullOrWhiteSpace(right) && string.IsNullOrWhiteSpace(middle))
        {
            parts.Add(int.Parse(right));
        }

        return parts;
    }

    private string DiscoverNumber(string str, bool leftToRight)
    {
        var number = string.Empty;

        for (int i = leftToRight ? 0 : str.Length - 1; leftToRight ? i < str.Length : i >= 0; i += leftToRight ? 1 : -1)
        {
            if (!char.IsNumber(str[i]))
            {
                break;
            }

            number = leftToRight ? number + str[i] : str[i] + number;
        }

        return number;
    }
}
