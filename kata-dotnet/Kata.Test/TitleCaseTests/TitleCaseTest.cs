using FluentAssertions;
using Kata.Tasks.TitleCase;
using NUnit.Framework;

namespace Kata.Test.TitleCaseTests;

/// <summary>
/// Тесты для задачи <see cref="TitleCase"/>
/// </summary>
public class TitleCaseTest
{
    [Test]
    [TestCase("a clash of KINGS", "a an the of", "A Clash of Kings")]
    [TestCase("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
    [TestCase("", "", "")]
    [TestCase("the quick brown fox", "", "The Quick Brown Fox")]
    public void TestTitleCase(string sampleTitle, string sampleMinorWords, string expected)
        => TitleCase.Title(sampleTitle, sampleMinorWords).Should().Be(expected);
}
