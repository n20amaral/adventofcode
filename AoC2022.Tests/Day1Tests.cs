namespace AoC2022.Tests;

public class Day1Tests
{
    [Theory]
    [InlineData("1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000", "24000")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000", "45000")]
    public void SolvePart2Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart2();

        Assert.Equal(expected, result);
    }
}