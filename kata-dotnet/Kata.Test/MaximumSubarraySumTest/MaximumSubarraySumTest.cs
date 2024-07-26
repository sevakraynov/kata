using FluentAssertions;
using Kata.Tasks.MaximumSubarraySum;
using NUnit.Framework;

namespace Kata.Test.MaximumSubarraySumTest;

/// <summary>
/// Тесты для задачи <see cref="MaximumSubarraySum"/>
/// </summary>
public class MaximumSubarraySumTest
{
    [Test]
    [TestCase(6, new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 })]
    [TestCase(0, new int[0])]
    public void TestMaximumSubarraySum(int maxSubarraySum, int[] array)
        => maxSubarraySum.Should().Be(MaximumSubarraySum.MaxSubArrSum(array));
}
