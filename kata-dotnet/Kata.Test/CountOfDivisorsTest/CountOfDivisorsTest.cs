using Kata.Tasks.CountOfDivisors;
using Xunit;

namespace Kata.Test.CountOfDivisorsTest
{
    /// <summary>
	/// Тесты для задачи <see cref="CountOfDivisors"/>
	/// </summary>
    public class CountOfDivisorsTest
    {
        [Theory]
		[InlineData(1, 1)]
		[InlineData(4, 10)]
		[InlineData(2, 11)]
		[InlineData(8, 54)]
		[InlineData(3, 4)]
		[InlineData(2, 5)]
		[InlineData(6, 12)]
		[InlineData(8, 30)]
		public void TestMaximumSubarraySum(int countOfDivisors, int number)
		{
			Assert.Equal(countOfDivisors, CountOfDivisors.Divisors(number));
		}
    }
}