using System.Runtime.InteropServices;

namespace AoC2023.Tests
{
    public class Day2Tests
    {
        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", "8")]
        public void SolvePart1Test(string input, string expected)
        {
            var reader = new StringReader(input);
            var day2 = new Day2(reader);

            var result = day2.SolvePart1();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green","2286")]
        public void SolvePart2Test(string input, string expected)
        {
            var reader = new StringReader(input);
            var day2 = new Day2(reader);

            var result = day2.SolvePart2();

            Assert.Equal(expected, result);
        }
    }
}