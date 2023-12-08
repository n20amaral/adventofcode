using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using AoC.Common;

namespace AoC2023;

public class Day7 : ExerciseBase
{
    public Day7(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        var winnings = 0;
        var games = ParseInput("23456789TJQKA", (hand) => 
        {
            var group = hand.GroupBy(c => c);

            return [
                group.Where(g => g.Count() == 5).Count(), // fifths
                group.Where(g => g.Count() == 4).Count(), // quads
                group.Any(g => g.Count() == 2) && group.Any(g => g.Count() == 3) ? 1 : 0, // full house
                group.Where(g => g.Count() == 3).Count(), // triples
                group.Where(g => g.Count() == 2).Count(), // pairs
            ];
        }).OrderDescending().ToArray();

        for (int i = 0; i < games.Length; i++)
        {
            winnings += games[i].BidAmount * (i +1);
        }

        return winnings.ToString();
    }

    public override string SolvePart2()
    {
        var winnings = 0;
        var games = ParseInput("J23456789TQKA", (hand) => 
        {
            var jokers = hand.Where(c => c == 0).Count();

            var group = hand.GroupBy(c => c);
            var fifths = group.Where(g => g.Count() == 5).Count();
            var quads = group.Where(g => g.Count() == 4).Count();
            var triples = group.Where(g => g.Count() == 3).Count();
            var pairs = group.Where(g => g.Count() == 2).Count();
            var fullHouse = triples > 0 && pairs > 0 ? 1 : 0;

            return jokers switch {
                5 => [fifths, 0, 0, 0, 0],
                4 => [quads, 0, 0, 0, 0],
                3 => [
                    pairs == 1 ? 1 : 0,     //fifths
                    pairs == 0 ? 1 : 0,     //quads                         
                    0,                      //full house
                    0,                      //triples
                    0,                      //pairs
                ],
                2 => [
                    triples == 1 ? 1 : 0,   //fifths
                    pairs == 2 ? 1 : 0,     //quads
                    0,                      //full house
                    pairs == 1 ? 1 : 0,     //triples
                    0,                      //pairs
                ],
                1 => [
                    quads == 1 ? 1 : 0,     //fifths
                    triples == 1 ? 1 : 0,   //quads
                    pairs == 2 ? 1 : 0,     //full house
                    pairs == 1 ? 1 : 0,     //triples
                    pairs == 0 ? 1 : 0,     //pairs
                ],
                0 => [fifths, quads, fullHouse, triples, pairs],
                _ => throw new Exception("Invalid number of jokers")
            };
        }).OrderDescending().ToArray();

        for (int i = 0; i < games.Length; i++)
        {
            winnings += games[i].BidAmount * (i +1);
        }

        return winnings.ToString();
    }

    private IEnumerable<Game> ParseInput(string cardSet, Func<int[], int[]> createScoreBoard)
    {
        ResetReader();

        string? line;
        while ((line = _reader.ReadLine()) != null)
        {
            var parts = line.Split(' ');
            var hand = parts[0].Select(c => cardSet.IndexOf(c)).ToArray();
            var bid = int.Parse(parts[1]);
            yield return new Game(hand, bid, createScoreBoard);
        }
    }

    private class Game(int[] hand, int bidAmount, Func<int[], int[]> createScoreBoard) : IComparable<Game>
    {
        public int[] Hand { get; } = hand;
        public int BidAmount { get; } = bidAmount;
        public int CompareTo(Game? other)
        {
            if(other == null)
            {
                return -1;
            }

            var score = createScoreBoard(Hand);
            var otherScore = createScoreBoard(other.Hand);

            for (var i = 0; i < score.Length; i++)
            {
                var difference = otherScore[i] - score[i];
                if(difference != 0)
                {
                    return difference;
                }

                if(score[i] > 0)
                {
                    break;
                }
            }

            for (var i = 0; i < Hand.Length; i++)
            {
                var cardDiff = other.Hand[i] - Hand[i];
                if (cardDiff != 0)
                {
                    return cardDiff;
                }
            }
            
            return 0;
        }
    }
}
