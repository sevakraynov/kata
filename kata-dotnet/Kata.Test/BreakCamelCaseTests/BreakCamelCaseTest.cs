using FluentAssertions;
using Kata.Tasks.BreakCamelCase;
using NUnit.Framework;

namespace Kata.Test.BreakCamelCaseTests;

/// <summary>
/// Тесты для задачи <see cref="BreakCamelCase"/>
/// </summary>
public class BreakCamelCaseTest
{
    [Test]
    [TestCase("camelCasing", "camel Casing")]
    [TestCase("camelCasingTest", "camel Casing Test")]
    public void TestBreakCamelCase(string str, string expected)
        => expected.Should().Be(BreakCamelCase.Break(str));
}
