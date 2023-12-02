using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.InteropServices;
using AoC.Common;

namespace AoC2023
{
    public class Day2 : ExerciseBase
    {
        public Day2(TextReader reader) : base(reader)
        {
        }


        public override string SolvePart1()
        {
            ResetReader();

            var idSum = 0;
            var line = string.Empty;
            
            while ((line = _reader.ReadLine()) != null)
            {
                var game = CreateGame(line);
                if(GameIsImpossible(game))
                {
                    continue;
                }
                
                idSum += game.Id;
            }

            return idSum.ToString();
        }

        public override string SolvePart2()
        {
            ResetReader();

            var powerSum = 0;
            var line = string.Empty;
            
            while ((line = _reader.ReadLine()) != null)
            {
                var game = CreateGame(line);
                
                powerSum += GetMinimumPower(game);
            }

            return powerSum.ToString();
        }

        private record Game(int Id, List<Tuple<int, int, int>> Sets);

        private Game CreateGame(string line)
        {
            var gameData = line.Split(':');
            var setsData = gameData[1].Split(';').Select(s => s.Trim()).ToList();
            var id = int.Parse(gameData[0].Split(' ')[1]);

            return new Game(id, setsData.Select(s => CreateSet(s)).ToList());
        }

        private Tuple<int, int, int> CreateSet(string setData)
        {
            var red = 0;
            var green = 0;
            var blue = 0;
            var rolls = setData.Split(',').Select(s => s.Trim()).ToList();

            foreach (var roll in rolls)
            {


                var rollData = roll.Split(' ');
                var count = int.Parse(rollData[0]);

                switch(rollData[1])
                {
                    case "red":
                        red += count;
                        break;
                    case "green":
                        green += count;
                        break;
                    case "blue":
                        blue += count;
                        break;
                }
            }

            return new Tuple<int, int, int>(red, green, blue);
        }

        private bool GameIsImpossible(Game game)
        {
            return game.Sets.Any(s => s.Item1 > 12 || s.Item2 > 13 || s.Item3 > 14);
        }
        private int GetMinimumPower(Game game)
        {
            var maxRed = 0;
            var maxGreen = 0;
            var maxBlue = 0;

            foreach (var set in game.Sets)
            {
                if (set.Item1 > maxRed)
                {
                    maxRed = set.Item1;
                }

                if (set.Item2 > maxGreen)
                {
                    maxGreen = set.Item2;
                }

                if (set.Item3 > maxBlue)
                {
                    maxBlue = set.Item3;
                }
            }

            return maxRed * maxGreen * maxBlue;
        }

    }
}