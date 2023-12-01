namespace AoC2016.Tests;

public class Day1Tests
{
    [Theory]
    [InlineData("R2, L3", "5")]
    [InlineData("R2, R2, R2", "2")]
    [InlineData("R5, L5, R5, R3", "12")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("R8, R4, R4, R8", "4")]
    public void SolvePart2Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart2();

        Assert.Equal(expected, result);
    }
}