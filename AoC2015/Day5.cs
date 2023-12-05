using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.Marshalling;
using AoC.Common;

namespace AoC2015;

public class Day5 : ExerciseBase
{
    public Day5(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();
        var naughty = new string[] { "ab", "cd", "pq", "xy" };
        var sum = 0;
        string? word;

        while((word = _reader.ReadLine()) != null)
        {
            if(string.IsNullOrWhiteSpace(word))
            {
                continue;
            }
;
            var doubleCheck = false;
            var naughtyCheck = false;
            var vowelCount = 0;

            for(var i = 0; i < word.Length; i++)
            {
                var notLastChar = i < word.Length - 1;

                if(notLastChar && naughty.Contains($"{word[i]}{word[i + 1]}"))
                {
                    naughtyCheck = true;
                    break;
                }

                if(!doubleCheck && notLastChar && word[i] == word[i + 1])
                {
                    doubleCheck = true;
                }

                switch(word[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        vowelCount++;
                        break;
                }
            }

            sum += !naughtyCheck && doubleCheck && vowelCount > 2 ? 1 : 0;
        }

        return sum.ToString();
    }

    public override string SolvePart2()
    {
        ResetReader();
        var sum = 0;
        string? word;

        while((word = _reader.ReadLine()) != null)
        {
            if(string.IsNullOrWhiteSpace(word))
            {
                continue;
            }

            var inBetweenCheck = false;
            var pairCheck = false;

            for(var i = 0; i < word.Length - 1; i++)
            {
                if(!inBetweenCheck && i > 0)
                {
                    var slice = word.Substring(i - 1, 3);
                    inBetweenCheck = slice[0] == slice[2] && slice[0] != slice[1];
                }

                // no space for a next pair, or no next pair found
                if(i > word.Length - 4 || word.IndexOf($"{word[i]}{word[i + 1]}", i + 2) == - 1)
                {
                    continue;
                }

                pairCheck = true;
            } 

            sum += pairCheck && inBetweenCheck ? 1 : 0;
        }

        return sum.ToString();
    }
}
