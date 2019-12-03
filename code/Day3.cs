using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class Coordinate
	{
		public int x {get; private set;}
		public int y {get; private set;}

		public Coordinate(int xParam, int yParam)
		{
			x = xParam;
			y = yParam;
		}
	}
	class DayThree
	{

		private static List<Coordinate> GetCoordinateForWire(string input)
		{
			string[] splitInput = input.Split(',');

			List<Coordinate> output = new List<Coordinate>();
			output.Add(new Coordinate(0,0));

			foreach (string value in splitInput)
			{
				char direction = value[0];

				int distance = Convert.ToInt32(value.Substring(1));

				int newX = output.Last().x;
				int newY = output.Last().y;

				switch(direction)
				{
					case 'L':
						newX -= distance;
						break;
					case 'R':
						newX += distance;
						break;
					case 'U':
						newY += distance;
						break;
					case 'D':
						newY -= distance;
						break;
					default:
						throw new Exception("invalid direction");
				}

				output.Add(new Coordinate(newX, newY));
			}

			return output;
		}
		public static Coordinate DoWiresCross(Coordinate wire1Start, Coordinate wire1End, Coordinate wire2Start, Coordinate wire2End)
		{
			if (wire1Start.x != wire1End.x)
			{
				if (wire2Start.y == wire2End.y)
					return null;
				
				if ((wire1Start.y > wire2Start.y && wire1Start.y > wire2End.y) || (wire1Start.y < wire2Start.y && wire1Start.y < wire2End.y))
					return null;

				if ((wire2Start.x > wire1Start.x && wire2Start.x > wire1End.x) || (wire2Start.x < wire1Start.x && wire2Start.x < wire1End.x))
					return null;

				return new Coordinate(wire2Start.x, wire1Start.y);
			}
			else
			{
				if (wire2Start.x == wire2End.x)
					return null;
				
				if ((wire2Start.y > wire1Start.y && wire2Start.y > wire1End.y) || (wire2Start.y < wire1Start.y && wire2Start.y < wire1End.y))
					return null;

				if ((wire1Start.x > wire2Start.x && wire1Start.x > wire2End.x) || (wire1Start.x < wire2Start.x && wire1Start.x < wire2End.x))
					return null;
				
				return new Coordinate(wire1Start.x, wire2Start.y);
			}

		}

		public static void PartOne()
		{
			var input = Utils.GetLinesForDay(3);

			List<Coordinate> firstWire = GetCoordinateForWire(input.ElementAt(0));
			List<Coordinate> secondWire = GetCoordinateForWire(input.ElementAt(1));

			int minDistance = Int32.MaxValue;

			for(int i = 0; i < firstWire.Count - 1; i++)
			{
				for (int j = 0; j < secondWire.Count - 1; j++)
				{
					Coordinate result = DoWiresCross(firstWire[i], firstWire[i+1], secondWire[j], secondWire[j+1]);
					
					if (result != null)
					{
						int distance = Math.Abs(result.x) + Math.Abs(result.y);
						minDistance = Math.Min(minDistance, distance);
					}
				}
			}

			Console.WriteLine(minDistance);
		}

		public static void PartTwo()
		{
			var input = Utils.GetLinesForDay(3);

			List<Coordinate> firstWire = GetCoordinateForWire(input.ElementAt(0));
			List<Coordinate> secondWire = GetCoordinateForWire(input.ElementAt(1));

			int minDistance = Int32.MaxValue;

			int firstDistance = 0;
			for(int i = 0; i < firstWire.Count - 1; i++)
			{
				int secondDistance = 0;
				for (int j = 0; j < secondWire.Count - 1; j++)
				{
					Coordinate result = DoWiresCross(firstWire[i], firstWire[i+1], secondWire[j], secondWire[j+1]);
					
					if (result != null)
					{
						int distance = firstDistance + Math.Abs(firstWire[i].x - result.x + firstWire[i].y - result.y) + secondDistance + Math.Abs(secondWire[j].x - result.x + secondWire[j].y - result.y);
						minDistance = Math.Min(minDistance, distance);
					}

					secondDistance += Math.Abs(secondWire[j].x - secondWire[j+1].x + secondWire[j].y - secondWire[j+1].y);
				}

				firstDistance += Math.Abs(firstWire[i].x - firstWire[i+1].x + firstWire[i].y - firstWire[i+1].y);
			}

			Console.WriteLine(minDistance);
		}
	}
}