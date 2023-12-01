using System.Globalization;
using AoC.Common;

namespace AoC2017;

public class Day1 : ExerciseBase
{
    public Day1(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();
        char current;
        char previous = char.MaxValue;
        char first = (char)_reader.Peek();
        var sum = 0;

        while((current = (char)_reader.Read()) != char.MaxValue)
        {
            if (current == previous)
            {
                sum += (int)char.GetNumericValue(current);
            }

            previous = current;
        }

        if (previous == first)
        {
            sum += (int)char.GetNumericValue(previous);
        }

        return sum.ToString();
    }
 
    public override string SolvePart2()
    {
        ResetReader();
        var captcha = _reader.ReadToEnd();
        var half = captcha.Length / 2;
        var sum = 0;

        for (int i = 0, j = half; i < captcha.Length; i++, j++)
        {
            if (i == half)
            {
                j = 0;
            }

            if (captcha[i] == captcha[j])
            {
                sum += (int)char.GetNumericValue(captcha[i]);
            }    
        }

        return sum.ToString();
    }
}
