using Kata.Tasks.BreakCamelCase;
using Xunit;

namespace Kata.Test.BreakCamelCaseTests
{
	/// <summary>
	/// Тесты для задачи <see cref="BreakCamelCase"/>
	/// </summary>
	public class BreakCamelCaseTest
	{
		[Theory]
		[InlineData("camelCasing", "camel Casing")]
		[InlineData("camelCasingTest", "camel Casing Test")]
		public void TestBreakCamelCase(string str, string expected)
		{
			Assert.Equal(expected, BreakCamelCase.Break(str));
		}
    }
}