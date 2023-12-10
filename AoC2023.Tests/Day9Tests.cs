using System.Runtime.InteropServices;

namespace AoC2023.Tests;

public class Day9Tests
{
    [Theory]
    [InlineData("0   3   6   9  12  15", "18")]
    [InlineData("1   3   6  10  15  21", "28")]
    [InlineData("10  13  16  21  30  45", "68")]
    public void SolvePart1(string input, string expected)
    {
        using var reader = new StringReader(input);
        var day = new Day9(reader);

        var actual = day.SolvePart1();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("0   3   6   9  12  15", "-3")]
    [InlineData("1   3   6  10  15  21", "0")]
    [InlineData("10  13  16  21  30  45", "5")]
    public void SolvePart2(string input, string expected)
    {
        using var reader = new StringReader(input);
        var day = new Day9(reader);

        var actual = day.SolvePart2();

        Assert.Equal(expected, actual);
    }
}
