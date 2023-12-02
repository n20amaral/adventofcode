namespace AoC2020.Tests;

public class Day1Tests
{
    [Theory]
    [InlineData("1721\n979\n366\n299\n675\n1456", "514579")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1721\n979\n366\n299\n675\n1456", "241861950")]
    public void SolvePart2Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart2();

        Assert.Equal(expected, result);
    }
}