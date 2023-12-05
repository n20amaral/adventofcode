namespace AoC2015.Tests;

public class Day5Tests
{

    [Theory]
    [InlineData("ugknbfddgicrmopn", "1")]
    [InlineData("aaa", "1")]
    [InlineData("jchzalrnumimnmhp", "0")]
    [InlineData("haegwjzuvuyypxyu", "0")]
    [InlineData("dvszwmarrgswjxmb", "0")]
    public void Part1(string input, string expected)
    {
        var reader = new StringReader(input);
        var day = new Day5(reader);

        var actual = day.SolvePart1();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("qjhvhtzxzqqjkmpb", "1")]
    [InlineData("xxyxx", "1")]
    [InlineData("uurcxstgmygtbstg", "0")]
    [InlineData("ieodomkazucvgmuy", "0")]
    [InlineData("abaxyxy", "1")]
    [InlineData("xxabaxxx", "1")]
    public void Part2(string input, string expected)
    {
        var reader = new StringReader(input);
        var day = new Day5(reader);

        var actual = day.SolvePart2();

        Assert.Equal(expected, actual);
    }
}
