using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayFive
	{
		public static void PartOne()
		{
			IEnumerable<string> lines = Utils.GetLinesForDay(5);

			string input = lines.ElementAt(0);

			List<int> inputList = new List<int>();

			inputList.Add(1);

			List<int> program = new List<int>(new List<String>(input.Split(',')).Select(x => Convert.ToInt32(x)));

			int output = IntCode.RunProgram(program, inputList);
			
			Console.WriteLine(output);
		}

		public static void PartTwo()
		{
			IEnumerable<string> lines = Utils.GetLinesForDay(5);

			string input = lines.ElementAt(0);

			List<int> inputList = new List<int>();

			inputList.Add(5);

			List<int> program = new List<int>(new List<String>(input.Split(',')).Select(x => Convert.ToInt32(x)));

			int output = IntCode.RunProgram(program, inputList);
			
			Console.WriteLine(output);
		}
	}
}