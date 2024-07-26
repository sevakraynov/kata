using FluentAssertions;
using Kata.Tasks.CountOfDivisors;
using NUnit.Framework;

namespace Kata.Test.CountOfDivisorsTest;

/// <summary>
/// Тесты для задачи <see cref="CountOfDivisors"/>
/// </summary>
public class CountOfDivisorsTest
{
    [Test]
    [TestCase(1, 1)]
    [TestCase(4, 10)]
    [TestCase(2, 11)]
    [TestCase(8, 54)]
    [TestCase(3, 4)]
    [TestCase(2, 5)]
    [TestCase(6, 12)]
    [TestCase(8, 30)]
    public void TestMaximumSubarraySum(int countOfDivisors, int number)
        => countOfDivisors.Should().Be(CountOfDivisors.Divisors(number));
}
