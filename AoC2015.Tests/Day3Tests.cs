namespace AoC2015.Tests;

public class Day3Tests
{
    [Theory]
    [InlineData(">", "2")]
    [InlineData("^>v<", "4")]
    [InlineData("^v^v^v^v^v", "2")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day3 = new Day3(reader);

        var result = day3.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("^v", "3")]
    [InlineData("^>v<", "3")]
    [InlineData("^v^v^v^v^v", "11")]
    public void SolvePart2Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day3 = new Day3(reader);

        var result = day3.SolvePart2();

        Assert.Equal(expected, result);
    }
}