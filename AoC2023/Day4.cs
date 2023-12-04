using AoC.Common;

namespace AoC2023;

public class Day4 : ExerciseBase
{
    public Day4(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();

        var sum = 0;
        string? card;
        while((card = _reader.ReadLine()) != null)
        {
            if(string.IsNullOrWhiteSpace(card))
            {
                continue;
            }

            var numbers = card.Substring(card.IndexOf(':') + 1).Split("|");
            var winningNumbers = numbers[0].Split(" ").Where(n => n.Length > 0).Select(int.Parse).ToList();
            var cardNumbers = numbers[1].Split(" ").Where(n => n.Length > 0).Select(int.Parse).ToList();

            sum += CalculatePoints(winningNumbers.Intersect(cardNumbers).Count());            
        }
        
        return sum.ToString();
    }

    public override string SolvePart2()
    {
        ResetReader();

        var cardInstances = new Dictionary<int, int>();
        string? line;
        while((line = _reader.ReadLine()) != null)
        {
            if(string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var firstSpace = line.IndexOf(' ');
            var colon = line.IndexOf(':');
            var cardId = int.Parse(line.Substring(firstSpace, colon - firstSpace));
            var numbers = line.Substring(colon + 1).Split("|");
            var winningNumbers = numbers[0].Split(" ").Where(n => n.Length > 0).Select(int.Parse).ToList();
            var cardNumbers = numbers[1].Split(" ").Where(n => n.Length > 0).Select(int.Parse).ToList();

            if(!cardInstances.ContainsKey(cardId))
            {
                cardInstances.Add(cardId, 1);
            } else {
                cardInstances[cardId] += 1;
            }

            var winningCount =  winningNumbers.Intersect(cardNumbers).Count();

            for (int i = 1; i <= winningCount; i++)
            {
                var cardIdCopy = cardId + i;

                if (!cardInstances.ContainsKey(cardIdCopy))
                {
                    cardInstances.Add(cardIdCopy, cardInstances[cardId]);
                    continue;
                }

                cardInstances[cardIdCopy] += cardInstances[cardId];
            }
        }
        
        return cardInstances.Sum(kv => kv.Value).ToString();
    }

    private int CalculatePoints(int winningNumbersTotal)
    {
        if(winningNumbersTotal < 2)
        {
            return winningNumbersTotal;
        }

        return CalculatePoints(winningNumbersTotal - 1) * 2;
    }
}
