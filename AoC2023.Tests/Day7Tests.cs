namespace AoC2023.Tests;

public class Day7Tests
{

    [Theory]
    [InlineData("32T3K 765\nT55J5 684\nKK677 28\nKTJJT 220\nQQQJA 483", "6440")]
    [InlineData("9QQQQ 1\nKKKKK 1000\nKQQQQ 10\nQQQQQ 100", "4321")]
    [InlineData("99888 100\n97QQQ 1\n99QQQ 1000\n98QQQ 10", "4321")]
    [InlineData("57Q79 10\n99Q77 1000\n99Q88 10000\n96Q79 100\n23456 1", "54321")]
    public void SolvePart1(string input, string expected)
    {
        using var reader = new StringReader(input);
        var day = new Day7(reader);

        var actual = day.SolvePart1();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("32T3K 765\nT55J5 684\nKK677 28\nKTJJT 220\nQQQJA 483", "5905")]
    [InlineData("9QQQQ 1\nKKKKK 1000\nKQQQQ 10\nQQQQQ 100", "4321")]
    [InlineData("99888 100\n97QQQ 1\n99QQQ 1000\n98QQQ 10", "4321")]
    [InlineData("57Q79 10\n99Q77 1000\n99Q88 10000\n96Q79 100\n23456 1", "54321")]
    [InlineData("9QQQQ 1\nKKKKK 1000\nJQQQQ 10\nQQQQQ 100", "4321")]
    [InlineData("99888 100\n97QQQ 1\n99QQQ 1000\nJ8QQQ 10", "3241")]
    [InlineData("57Q79 10\n99QJJ 1000\n99Q88 10000\n96Q79 100\n23456 1", "45321")]
    public void SolvePart2(string input, string expected)
    {
        using var reader = new StringReader(input);
        var day = new Day7(reader);

        var actual = day.SolvePart2();

        Assert.Equal(expected, actual);
    }
}
