using System.Linq;

namespace Kata.Tasks.BreakCamelCase
{
	/// <summary>
	/// Класс для решения задачи Break camelCase
	/// </summary>
	/// <remarks>
	/// 
	/// <see cref="https://www.codewars.com/kata/5208f99aee097e6552000148">TASK</see>:
	/// Complete the solution so that the function will break up camel casing,
	/// using a space between words.
	///
	/// EXAMPLE:
	/// solution("camelCasing")  ==  "camel Casing"
	/// 
	/// </remarks>
	public static class BreakCamelCase
	{
		public static string Break(string str)
		{
			return string.Concat(str.Select(c => char.IsUpper(c) ? $" {c}" : $"{c}"));
		}
	}
}