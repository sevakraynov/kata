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
		/// Left side team
		/// </summary>
		/// <typeparam name="char">Letter</typeparam>
		/// <typeparam name="int">Power</typeparam>
		private static Dictionary<char, int> LeftSide = new Dictionary<char, int>()
		{
			{'w', 4},
			{'p', 3},
			{'b', 2},
			{'s', 1}
		};
			
		/// <summary>
		/// Right side team
		/// </summary>
		/// <typeparam name="char">Letter</typeparam>
		/// <typeparam name="int">Power</typeparam>
		private static Dictionary<char, int> RightSide = new Dictionary<char, int>()
		{
			{'m', 4},
			{'q', 3},
			{'d', 2},
			{'z', 1}
		};

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
		/// <returns>
		/// When the left side 
		/// wins return `Left side wins!`, when the right side wins return 
		/// `Right side wins!`, in other case return `Let's fight again!`
		/// </returns>
		public static string Fight(string fight) 
		{
			return WhoIsWin(fight);
		}
	
		/// <summary>
		/// Метод решения задачи Alphabet war - airstrike - letters massacre
		/// </summary>
		/// <remarks>
		/// Write a function that accepts `fight` string consists of only small 
		/// letters and * which means a bomb drop place. 
		/// Return who wins the fight after bombs are exploded. When the left 
		/// side wins return `Left side wins!`, when the right side wins return 
		/// `Right side wins!`, in other case return `Let's fight again!`.
		/// 
		/// The left side letters and their power:w - 4, p - 3, b - 2, s - 1
		/// The right side letters and their power: m - 4, q - 3, d - 2, z - 1
		/// 
		/// The other letters don't have power and are only victims.
		/// The * bombs kills the adjacent letters ( i.e. aa*aa => a___a, **aa** => ______ );
		/// </remarks>
		/// <param name="fight">Input string</param>
		/// <returns>
		/// When the left side wins return `Left side wins!`, 
		/// when the right side wins return `Right side wins!`, 
		/// in other case return `Let's fight again!`
		/// </returns>
		public static string AirStrike(string fight)
		{
			var fightCharArray = fight.ToCharArray();
			for(int i = 0; i < fightCharArray.Length; i++)
			{
				if(fightCharArray[i] == '*') 
				{
					if(i - 1 >= 0 && fightCharArray[i - 1] != '*')
					{
						fightCharArray[i - 1] = '_';
					}

					if(i + 1 < fightCharArray.Length && fightCharArray[i + 1] != '*')
					{
						fightCharArray[i + 1] = '_';
					}
				}
			}

			return WhoIsWin(new string(fightCharArray));
		}

		/// <summary>
		/// Метод определения победителя
		/// </summary>
		/// <param name="str">Входная строка</param>
		/// <returns>
		/// Если левая сторона выигрывает выводится "Left side wins!",
		/// если правая сторона - "Right side wins!",
		/// иначе - "Let's fight again!"
		/// </returns>
		private static string WhoIsWin(string str) 
		{
			int countLeft = 0, countRight = 0;

			foreach(char letter in str)
			{
				if(LeftSide.ContainsKey(letter)) {
					countLeft += LeftSide[letter];
				}

				if(RightSide.ContainsKey(letter)) {
					countRight += RightSide[letter];
				}
			}

			return countLeft == countRight ? "Let's fight again!" : 
					countLeft > countRight ? "Left side wins!" : "Right side wins!";
		}
	}
}