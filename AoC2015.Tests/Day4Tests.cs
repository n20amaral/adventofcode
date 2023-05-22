namespace AoC2015.Tests;

public class Day4Tests
{
    [Theory]
    [InlineData("abcdef", "609043")]
    [InlineData("pqrstuv", "1048970")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day4 = new Day4(reader);

        var result = day4.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abcdef", "6742839")]
    [InlineData("pqrstuv", "5714438")]
    public void SolvePart2Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day4 = new Day4(reader);

        var result = day4.SolvePart2();

        Assert.Equal(expected, result);
    }
}