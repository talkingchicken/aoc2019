using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DaySix
	{

		private static int GetOrbits(Dictionary<string, List<string>> orbits, string startPoint, int depth)
		{
			if (!orbits.ContainsKey(startPoint))
				return depth;

			int total = depth;

			foreach(string orbit in orbits[startPoint])
			{
				total += GetOrbits(orbits, orbit, depth + 1);
			}

			return total;
		}
		public static void PartOne()
		{

			Dictionary<string, List<string>> orbits = new Dictionary<string, List<string>>();

			IEnumerable<string> lines =	Utils.GetLinesForDay(6);

			IEnumerable<string[]> splitLines = lines.Select(x => x.Split(")"));

			foreach (string[] splitLine in splitLines)
			{
				if (!orbits.ContainsKey(splitLine[0]))
				{
					orbits[splitLine[0]] = new List<string>();
				}

				orbits[splitLine[0]].Add(splitLine[1]);
			}
			
			Console.WriteLine(GetOrbits(orbits, "COM", 0));
		}

		private static bool GetPathToNode(Dictionary<string, List<string>> orbits, string target, List<string> currentList)
		{
			string currentNode = currentList.Last();

			if (currentNode == target)
			{
				return true;
			}

			if (!orbits.ContainsKey(currentNode))
			{
				return false;
			}

			foreach (string currentOrbit in orbits[currentNode])
			{
				currentList.Add(currentOrbit);

				bool result = GetPathToNode(orbits, target, currentList);

				if (result)
				{
					return true;
				}

				currentList.RemoveAt(currentList.Count - 1);
			}

			return false;
		}

		public static void PartTwo()
		{
			Dictionary<string, List<string>> orbits = new Dictionary<string, List<string>>();

			IEnumerable<string> lines =	Utils.GetLinesForDay(6);

			IEnumerable<string[]> splitLines = lines.Select(x => x.Split(")"));

			foreach (string[] splitLine in splitLines)
			{
				if (!orbits.ContainsKey(splitLine[0]))
				{
					orbits[splitLine[0]] = new List<string>();
				}

				orbits[splitLine[0]].Add(splitLine[1]);
			}

			List<string> youPath = new List<string>();
			youPath.Add("COM");

			GetPathToNode(orbits, "YOU", youPath);

			List<string> santaPath = new List<string>();
			santaPath.Add("COM");

			GetPathToNode(orbits, "SAN", santaPath);

			int commonIndex = 0;

			while (santaPath[commonIndex] == youPath[commonIndex])
			{
				commonIndex++;
			}

			int transfers = youPath.Count + santaPath.Count - (commonIndex * 2) - 2;

			Console.WriteLine(transfers);
		}
	}
}