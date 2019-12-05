using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayFour
	{
		public static void PartOne()
		{
			int inputMin = 246540;
			int inputMax = 787419;

			int validPasswords = 0;
			for (int i = inputMin; i <= inputMax; i++)
			{
				if (IsValidPassword(i))
					validPasswords++;
			}

			Console.WriteLine(validPasswords);
		}

		private static bool IsValidPassword(int input)
		{
			int currentDigit = input % 10;

			bool repeating = false;
			while (input >= 10)
			{
				input /= 10;

				int nextDigit = input % 10;
				if (nextDigit > currentDigit)
					return false;

				if (nextDigit == currentDigit)
					repeating = true;

				currentDigit = nextDigit;
			}

			return repeating;
		}

		public static void PartTwo()
		{
			int inputMin = 246540;
			int inputMax = 787419;

			int validPasswords = 0;
			for (int i = inputMin; i <= inputMax; i++)
			{
				if (IsVeryValidPassword(i))
					validPasswords++;
			}

			Console.WriteLine(validPasswords);
		}

		
		private static bool IsVeryValidPassword(int input)
		{
			int currentDigit = input % 10;

			int currentChain = 1;
			bool repeating = false;

			while (input >= 10)
			{
				input /= 10;

				int nextDigit = input % 10;
				if (nextDigit > currentDigit)
					return false;

				if (nextDigit == currentDigit)
				{
					currentChain++;
				}
				else
				{
					if (currentChain == 2)
						repeating = true;

					currentChain = 1;
				}

				currentDigit = nextDigit;
			}

			return repeating || currentChain == 2;
		}
	}
}