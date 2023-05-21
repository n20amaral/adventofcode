namespace AoC2015.Tests;

public class Day2Tests
{
    [Theory]
    [InlineData("2x3x4", "58")]
    [InlineData("1x1x10", "43")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day2 = new Day2(reader);

        var result = day2.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("2x3x4", "34")]
    [InlineData("1x1x10", "14")]
    public void SolvePart2Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day2 = new Day2(reader);

        var result = day2.SolvePart2();

        Assert.Equal(expected, result);
    }
}