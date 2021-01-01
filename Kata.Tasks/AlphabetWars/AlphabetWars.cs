using System.Collections.Generic;
using System.Text;

namespace Kata.Tasks.AlphabetWars
{
	/// <summary>
	/// Класс для решения задачи Alphabet wars
	/// </summary>
	public static class AlphabetWars
	{
		/// <summary>
		/// Метод для решения задачи Alphabet wars
		/// </summary>
		/// <remarks>
		/// 
		/// <see cref="https://www.codewars.com/kata/59377c53e66267c8f6000027/">TASK</see>:
		/// 
		/// There is a war and nobody knows - the alphabet war! 
		/// There are two groups of hostile letters. The tension between left side 
		/// letters and right side letters was too high and the war began.
		/// 
		/// Write a function that accepts `fight` string consists of only 
		/// small letters and return who wins the fight. When the left side 
		/// wins return `Left side wins!`, when the right side wins return 
		/// `Right side wins!`, in other case return `Let's fight again!`.
		/// 
		/// </remarks>
		/// <param name="fight">Fight string</param>
		/// <returns>When the left side 
		/// wins return `Left side wins!`, when the right side wins return 
		/// `Right side wins!`, in other case return `Let's fight again!`
		/// </returns>
		public static string Fight(string fight) 
		{
			var teamLeft = new Dictionary<char, int>()
			{
				{'w', 4},
				{'p', 3},
				{'b', 2},
				{'s', 1}
			};
			
			var teamRight = new Dictionary<char, int>()
			{
				{'m', 4},
				{'q', 3},
				{'d', 2},
				{'z', 1}
			};

			int countLeft = 0, countRight = 0;

			foreach(char letter in fight)
			{
				if(teamLeft.ContainsKey(letter)) {
					countLeft += teamLeft[letter];
				}

				if(teamRight.ContainsKey(letter)) {
					countRight += teamRight[letter];
				}
			}

			return countLeft == countRight ? "Let's fight again!" : 
					countLeft > countRight ? "Left side wins!" : "Right side wins!";
		}
	}
}