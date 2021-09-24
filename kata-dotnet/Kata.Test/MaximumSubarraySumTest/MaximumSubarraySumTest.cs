using Kata.Tasks.MaximumSubarraySum;
using Xunit;

namespace Kata.Test.MaximumSubarraySumTest
{
    /// <summary>
	/// Тесты для задачи <see cref="MaximumSubarraySum"/>
	/// </summary>
    public class MaximumSubarraySumTest
    {
        [Theory]
		[InlineData(6, new int[]{-2, 1, -3, 4, -1, 2, 1, -5, 4})]
		[InlineData(0, new int[0])]
		public void TestMaximumSubarraySum(int maxSubarraySum, int[] array)
		{
			Assert.Equal(maxSubarraySum, MaximumSubarraySum.MaxSubArrSum(array));
		}
    }
}