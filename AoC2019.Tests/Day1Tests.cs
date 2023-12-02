namespace AoC2019.Tests;

public class Day1Tests
{
    [Theory]
    [InlineData("12", "2")]
    [InlineData("14", "2")]
    [InlineData("1969", "654")]
    [InlineData("100756", "33583")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("14", "2")]
    [InlineData("1969", "966")]
    [InlineData("100756", "50346")]
    public void SolvePart2Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart2();

        Assert.Equal(expected, result);
    }
}