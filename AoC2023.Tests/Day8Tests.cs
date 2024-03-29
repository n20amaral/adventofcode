﻿namespace AoC2023.Tests;

public class Day8Tests
{
    [Theory]
    [InlineData("RL\n\nAAA = (BBB, CCC)\nBBB = (DDD, EEE)\nCCC = (ZZZ, GGG)\nDDD = (DDD, DDD)\nEEE = (EEE, EEE)\nGGG = (GGG, GGG)\nZZZ = (ZZZ, ZZZ)", "2")]
    [InlineData("LLR\n\nAAA = (BBB, BBB)\nBBB = (AAA, ZZZ)\nZZZ = (ZZZ, ZZZ)", "6")]
    public void SolvePart1(string input, string expected)
    {
        using var reader = new StringReader(input);
        var day = new Day8(reader);

        var actual = day.SolvePart1();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("LR\n\n11A = (11B, XXX)\n11B = (XXX, 11Z)\n11Z = (11B, XXX)\n22A = (22B, XXX)\n22B = (22C, 22C)\n22C = (22Z, 22Z)\n22Z = (22B, 22B)\nXXX = (XXX, XXX)", "6")]
    public void SolvePart2(string input, string expected)
    {
        using var reader = new StringReader(input);
        var day = new Day8(reader);

        var actual = day.SolvePart2();

        Assert.Equal(expected, actual);
    }
}
