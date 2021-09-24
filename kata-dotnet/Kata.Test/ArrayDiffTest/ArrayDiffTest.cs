using Kata.Tasks.ArrayDiff;
using Xunit;

namespace Kata.Test.ArrayDiffTest
{
	/// <summary>
	/// Тесты для задачи <see cref="ArrayDiff"/>
	/// </summary>
	public class ArrayDiffTest
	{
		[Theory]
		[InlineData(new int[] {2}, new int[] {1, 2}, new int[] {1})]
		[InlineData(new int[] {2, 2}, new int[] {1, 2, 2}, new int[] {1})]
		[InlineData(new int[] {1}, new int[] {1, 2, 2}, new int[] {2})]
		[InlineData(new int[] {1, 2, 2}, new int[] {1, 2, 2}, new int[] {})]
		[InlineData(new int[] {}, new int[] {}, new int[] {1, 2})]
		public void TestArrayDiff(int[] result, int[] left, int[] right)
		{
			Assert.Equal(result, ArrayDiff.Diff(left, right));
		}
	}
}