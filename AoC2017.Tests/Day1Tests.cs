namespace AoC2017.Tests;

public class Day1Tests
{
    [Theory]
    [InlineData("1122", "3")]
    [InlineData("1111", "4")]
    [InlineData("1234", "0")]
    [InlineData("91212129", "9")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1212", "6")]
    [InlineData("1221", "0")]
    [InlineData("123425", "4")]
    [InlineData("123123", "12")]
    [InlineData("12131415", "4")]
    public void SolvePart2Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart2();

        Assert.Equal(expected, result);
    }
}