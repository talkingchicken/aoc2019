using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayOne
	{
		public static void PartOne()
		{
			IEnumerable<string> inputList = Utils.GetLinesForDay(1);
			
			int output = inputList.Select(x => Convert.ToInt32(x) / 3 - 2).Sum();

			Console.WriteLine(output);
		}

		public static void PartTwo()
		{
			IEnumerable<string> inputList = Utils.GetLinesForDay(1);
			
			int output = inputList.Select(x => GetTotalFuel(Convert.ToInt32(x))).Sum();

			Console.WriteLine(output);
		}

		private static int GetTotalFuel(int input)
		{
			int total = 0;

			int currentValue = input;
			while (currentValue > 0)
			{
				int nextValue = currentValue / 3 - 2;

				if (nextValue > 0)
				{
					total += nextValue;
				}

				currentValue = nextValue;
			}

			return total;
		}
	}
}