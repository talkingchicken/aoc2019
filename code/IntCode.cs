using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class IntCode
	{
		public static void RunProgram(List<int> program)
		{
			int currentPosition = 0;

			while (true)
			{
				switch(program[currentPosition])
				{
					case 1:
						program[program[currentPosition + 3]] = program[program[currentPosition + 1]] + program[program[currentPosition + 2]];
						currentPosition += 4;
						break;
						
					case 2:
						program[program[currentPosition + 3]] = program[program[currentPosition + 1]] * program[program[currentPosition + 2]];
						currentPosition += 4;
						break;

					case 99:
						return;

					default:
						throw new Exception("Error: unknown opcode");
				}
			}
			
		}
	}
}