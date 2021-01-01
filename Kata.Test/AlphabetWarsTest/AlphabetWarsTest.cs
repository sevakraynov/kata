using Kata.Tasks.AlphabetWars;
using Xunit;

namespace Kata.Test.AlphabetWarsTest
{
	/// <summary>
	/// Тесты для задач <see cref="AlphabetWars"/>
	/// </summary>
	public class AlphabetWarsTest
	{
		[Theory]
		[InlineData("Right side wins!", "z")]
		[InlineData("Let's fight again!", "zdqmwpbs")]
		[InlineData("Right side wins!", "zzzzs")]
		[InlineData("Left side wins!", "wwwwwwz")]
		public void FightTest(string result, string str)
		{
			Assert.Equal(result, AlphabetWars.Fight(str));
		}
	}
}