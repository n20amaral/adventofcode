namespace AoC2023.Tests;

public class Day3Tests
{

    [Theory]
    [InlineData("467..114..\n...*......\n..35..633.\n......#...\n617*......\n.....+.58.\n..592.....\n......755.\n...$.*....\n.664.598..", "4361")]
    [InlineData(".....+..\n......37\n........", "37")]
    public void SolvePart1Tests(string input, string expected)
    {
        var reader = new StringReader(input);
        var day = new Day3(reader);

        var actual = day.SolvePart1();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("467..114..\n...*......\n..35..633.\n......#...\n617*......\n.....+.58.\n..592.....\n......755.\n...$.*....\n.664.598..", "467835")]
    [InlineData("467..114..\n...+......\n..35..633.\n......#...\n617.......\n.....+.58.\n..592.....\n.......755\n...$..*...\n...598....", "451490")]
    [InlineData("......\n......\n...*10\n...10.", "100")]
    [InlineData("......\n......\n...*10\n..10..", "100")]
    [InlineData("......\n......\n...*10\n.10...", "100")]
    [InlineData("......\n......\n...*10\n10....", "0")]
    [InlineData("......\n......\n.10.10\n...*10", "0")]
    public void SolvePart2Tests(string input, string expected)
    {
        var reader = new StringReader(input);
        var day = new Day3(reader);

        var actual = day.SolvePart2();

        Assert.Equal(expected, actual);
    }
}
