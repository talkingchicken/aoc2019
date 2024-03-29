using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayTwo
	{
		public static void PartOne()
		{
			IEnumerable<string> lines = Utils.GetLinesForDay(2);

			string input = lines.ElementAt(0);

			List<int> inputList = new List<int>(new List<String>(input.Split(',')).Select(x => Convert.ToInt32(x)));

			inputList[1] = 12;
			inputList[2] = 2;

			IntCode.RunProgram(inputList);

			Console.WriteLine((inputList[0]));
		}

		public static void PartTwo()
		{
			int inputCheck = 19690720;

			IEnumerable<string> lines = Utils.GetLinesForDay(2);
			string input = lines.ElementAt(0);
			
			IEnumerable<int> cleanSource = new List<String>(input.Split(',')).Select(x => Convert.ToInt32(x));

			for	(int i = 0; i <= 99; i++)
			{
				for (int j = 0; j <= 99; j++)
				{
					List<int> inputList = new List<int>(cleanSource);

					inputList[1] = i;
					inputList[2] = j;

					IntCode.RunProgram(inputList);

					if (inputList[0] == inputCheck)
					{
						int output = 100 * i + j;
						Console.WriteLine(output);
						return;
					}
				}
			}

			Console.WriteLine("No values found");
		}
	}
}