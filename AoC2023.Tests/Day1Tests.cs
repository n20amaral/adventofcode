namespace AoC2023.Tests;
public class Day1Tests
{
    [Theory]
    [InlineData("1abc2", "12")]
    [InlineData("pqr3stu8vwx", "38")]
    [InlineData("a1b2c3d4e5f", "15")]
    [InlineData("treb7uchet", "77")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("two1nine", "29")]
    [InlineData("eightwothree", "83")]
    [InlineData("abcone2threexyz", "13")]
    [InlineData("xtwone3four", "24")]
    [InlineData("4nineeightseven2", "42")]
    [InlineData("zoneight234", "14")]
    [InlineData("7pqrstsixteen", "76")]
    public void SolvePart2Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart2();

        Assert.Equal(expected, result);
    }
}