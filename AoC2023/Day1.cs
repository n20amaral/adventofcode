using System.Collections;
using System.Text;
using AoC.Common;
using Microsoft.VisualBasic;

namespace AoC2023;

public class Day1 : ExerciseBase
{
    public Day1(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();

        var sum = 0;
        var line = String.Empty;
        while((line = _reader.ReadLine()) != null)
        {
            var numbers = line.Where(c => char.IsNumber(c));
            sum += int.Parse([numbers.FirstOrDefault(), numbers.LastOrDefault()]);
        }

        return sum.ToString();
    }
 
    public override string SolvePart2()
    {
        ResetReader();

        var sum = 0;
        var line = String.Empty;

        while((line = _reader.ReadLine()) != null)
        {
            var firstNumber = -1;
            var lastNumber = -1;

            for (int i = 0; i < line.Length; i++)
            {
                var numberFound = char.IsNumber(line[i]) ? (int)char.GetNumericValue(line[i]) : GetStartingNumberNameNumericValue(line[i..]);

                if(numberFound < 0)
                {
                    continue;
                }

                if(firstNumber < 0)
                {
                    firstNumber = numberFound;
                    continue;
                }

                lastNumber = numberFound;
            }

            if(lastNumber < 0)
            {
                lastNumber = firstNumber;
            }

            sum += firstNumber * 10 + lastNumber;
        }

        return sum.ToString();
    }

    private int GetStartingNumberNameNumericValue(string str)
    {
        string[] numberNames = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        for(var i = 0; i < numberNames.Length; i++)
        {
            if(str.StartsWith(numberNames[i]))
            {
                return i;
            }
        }

        return -1;
    }
}
