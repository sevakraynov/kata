using FluentAssertions;
using Kata.Tasks.ArrayDiff;
using NUnit.Framework;

namespace Kata.Test.ArrayDiffTest;

/// <summary>
/// Тесты для задачи <see cref="ArrayDiff"/>
/// </summary>
public class ArrayDiffTest
{
    [Test]
    [TestCase(new[] { 2 }, new[] { 1, 2 }, new[] { 1 })]
    [TestCase(new[] { 2, 2 }, new[] { 1, 2, 2 }, new[] { 1 })]
    [TestCase(new[] { 1 }, new[] { 1, 2, 2 }, new[] { 2 })]
    [TestCase(new[] { 1, 2, 2 }, new[] { 1, 2, 2 }, new int[] { })]
    [TestCase(new int[] { }, new int[] { }, new[] { 1, 2 })]
    public void TestArrayDiff(int[] result, int[] left, int[] right)
        => result.Should().BeEquivalentTo(ArrayDiff.Diff(left, right));
}
