using System.Text;

namespace AoC2018.Tests;

public class Day1Tests
{
    [Theory]
    [InlineData("+1\n-2\n+3\n+1", "3")]
    [InlineData("+1\n+1\n+1", "3")]
    [InlineData("+1\n+1\n-2", "0")]
    [InlineData("-1\n-2\n-3", "-6")]
    public void SolvePart1Test(string input, string expected)
    {
        var reader = new StringReader(input);
        var day1 = new Day1(reader);

        var result = day1.SolvePart1();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("+1\n-2\n+3\n+1", "2")]
    [InlineData("+1\n-1", "0")]
    [InlineData("+3\n+3\n+4\n-2\n-4", "10")]
    [InlineData("-6\n+3\n+8\n+5\n-6", "5")]
    [InlineData("+7\n+7\n-2\n-7\n-4", "14")]
    public void SolvePart2Test(string input, string expected)
    {
        // a StringReader is not seekable, so we need to use a MemoryStream
        var reader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(input)));
        var day1 = new Day1(reader);

        var result = day1.SolvePart2();

        Assert.Equal(expected, result);
    }
}