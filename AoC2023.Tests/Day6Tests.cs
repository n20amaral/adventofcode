namespace AoC2023.Tests;

public class Day6Tests
{
    [Theory]
    [InlineData("Time:      7  15   30\nDistance:  9  40  200", "288")]
    public void SolvePart1(string input, string expected)
    {
        using var reader = new StringReader(input);
        var day = new Day6(reader);

        var actual = day.SolvePart1();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Time:      7  15   30\nDistance:  9  40  200", "71503")]
    public void SolvePart2(string input, string expected)
    {
        using var reader = new StringReader(input);
        var day = new Day6(reader);

        var actual = day.SolvePart2();

        Assert.Equal(expected, actual);   
    }
}
