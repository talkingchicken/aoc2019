using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class IntCode
	{
		private static int GetParam(List<int> program, int currentPosition, int paramIndex)
		{
			int opcode = program[currentPosition];

			int currentDigit = (opcode / (10 * (int)Math.Pow(10, paramIndex))) % 10;
			if (currentDigit == 0)
			{
				return program[program[currentPosition + paramIndex]];
			} 
			else
			{
				return program[currentPosition + paramIndex];
			}
		}
		public static int RunProgram(List<int> program, List<int> input = null)
		{
			int currentPosition = 0;
			int currentInputIndex = 0;

			int output = 0;

			while (true)
			{
				int instruction = program[currentPosition] % 100;
				switch(instruction)
				{
					case 1:

						program[program[currentPosition + 3]] = GetParam(program, currentPosition, 1) + GetParam(program, currentPosition, 2);
						currentPosition += 4;
						break;
						
					case 2:
						program[program[currentPosition + 3]] = GetParam(program, currentPosition, 1) * GetParam(program, currentPosition, 2);
						currentPosition += 4;
						break;

					case 3:
						program[program[currentPosition + 1]] = input[currentInputIndex++];
						currentPosition += 2;
						break;

					case 4:
						
						output = GetParam(program, currentPosition, 1);
						currentPosition += 2;
						break;

					case 5:
					{
						// jump if true
						int valueCheck = GetParam(program, currentPosition, 1);

						if (valueCheck != 0)
						{
							currentPosition = GetParam(program, currentPosition, 2);
						}
						else
						{
							currentPosition += 3;
						}
						break;
					}
					
					case 6:
					{
						// jump is false
						int valueCheck = GetParam(program, currentPosition, 1);

						if (valueCheck == 0)
						{
							currentPosition = GetParam(program, currentPosition, 2);
						}
						else
						{
							currentPosition += 3;
						}
						break;
					}
					
					case 7:
					{
						int firstParam = GetParam(program, currentPosition, 1);
						int secondParam = GetParam(program, currentPosition, 2);

						program[program[currentPosition + 3]] = (firstParam < secondParam) ? 1 : 0;

						currentPosition += 4;
						break;
					}
					
					case 8:
					{
						int firstParam = GetParam(program, currentPosition, 1);
						int secondParam = GetParam(program, currentPosition, 2);

						program[program[currentPosition + 3]] = (firstParam == secondParam) ? 1 : 0;

						currentPosition += 4;
						break;
					}

					case 99:
						return output;

					default:
						throw new Exception("Error: unknown opcode");
				}
			}

			return output;
		}
	}
}