using Kata.Tasks.TitleCase;
using Xunit;

namespace Kata.Test.TitleCaseTests
{
	/// <summary>
	/// Тесты для задачи <see cref="TitleCase"/>
	/// </summary>
	public class TitleCaseTest
	{
		[Theory]
		[InlineData("a clash of KINGS", "a an the of", "A Clash of Kings")]
		[InlineData("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
		public void TestTitleCase(string sampleTitle, string sampleMinorWords, string expected)
		{
			Assert.Equal(expected, TitleCase.Title(sampleTitle, sampleMinorWords));
		}

		[Fact]
		public void EmptyTitle()
		{
			Assert.Equal(string.Empty, TitleCase.Title(string.Empty));
		}

		[Fact]
		public void QuickBrownFoxTest()
		{
			Assert.Equal("The Quick Brown Fox", TitleCase.Title("the quick brown fox"));
		}
	}
}