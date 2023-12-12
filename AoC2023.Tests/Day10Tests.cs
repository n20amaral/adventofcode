namespace AoC2023.Tests;

public class Day10Tests
{
    [Theory]
    [InlineData(".....\n.S-7.\n.|.|.\n.L-J.\n.....", "4")]
    [InlineData("..F7.\n.FJ|.\nSJ.L7\n|F--J\nLJ...", "8")]
    public void SolvePart1(string input, string expected)
    {
        using var reader = new StringReader(input);
        var day = new Day10(reader);

        var actual = day.SolvePart1();

        Assert.Equal(expected, actual);
    }
}
