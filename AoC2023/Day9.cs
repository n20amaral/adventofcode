using AoC.Common;

namespace AoC2023;

public class Day9 : ExerciseBase
{
    public Day9(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        var sequences = ParseInput().ToArray();
        var sum = 0;

        foreach (var sequence in sequences)
        {
            sum += PredictNext(sequence);
        }

        return sum.ToString();
    }
    public override string SolvePart2()
    {
        var sequences = ParseInput().ToArray();
        var sum = 0;

        foreach (var sequence in sequences)
        {
            sum += PredictPreviousSum(sequence);
        }

        return sum.ToString();
    }

    private int PredictNext(int[] sequence)
    {
        var differences = new List<List<int>>();
        var current = sequence.ToList();
        
        while(!current.All(n => n == 0))
        {
            var diffResult = new List<int>();
            for (int i = 1; i < current.Count; i++)
            {
                diffResult.Add(current[i] - current[i - 1]);
            }
            differences.Add(diffResult);
            current = diffResult;
        }

        for (int i = differences.Count - 2; i >= 0 ; i--)
        {
             differences[i].Add(differences[i].Last() + differences[i + 1].Last());
        }

        return differences[0].Last() + sequence.Last();
    }

    private int PredictPreviousSum(int[] sequence)
    {
        var sum = 0;
        var differences = new List<List<int>>();
        var current = sequence.ToList();
        
        while(!current.All(n => n == 0))
        {
            var diffResult = new List<int>();
            for (int i = 1; i < current.Count; i++)
            {
                diffResult.Add(current[i] - current[i - 1]);
            }
            differences.Add(diffResult);
            current = diffResult;
        }

        for (int i = differences.Count - 2; i >= 0 ; i--)
        {
            var prevDiif = differences[i].First() - differences[i + 1].First();
            differences[i].Insert(0, prevDiif);
        }

        sum +=  sequence.First() - differences[0].First();

        return sum;
    }

    private IEnumerable<int[]> ParseInput()
    {
        ResetReader();
        string? line;
        while ((line = _reader.ReadLine()) != null)
        {
            yield return line.Split(" ").Where(x => x.Length > 0).Select(int.Parse).ToArray();
        }
    }
}
