namespace AoC2021.Tests;

public class Day1Tests
{
    [Theory]
    [InlineData("199\n200\n208\n210\n200\n207\n240\n269\n260\n263", "7")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("199\n200\n208\n210\n200\n207\n240\n269\n260\n263", "5")]
    public void SolvePart2Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart2();

        Assert.Equal(expected, result);
    }
}