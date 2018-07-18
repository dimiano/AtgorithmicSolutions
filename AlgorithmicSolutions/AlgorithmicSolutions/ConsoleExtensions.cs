using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicSolutions
{
	public static class ConsoleExtensions
	{
		public static void WriteResult(string input, string expect, string result)
		{
			Console.WriteLine(" INPUT:    " + input);
			Console.WriteLine(" EXPECTED: " + expect);
			Console.Write(" RESULT:   " + result);
			var color = Console.ForegroundColor;

			if (expect == result)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(" - CORRECT");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(" - WRONG");
			}
			Console.ForegroundColor = color;

			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		public static void WriteResult(string input, int expect, int result)
		{
			WriteResult(input, expect.ToString(), result.ToString());
		}
		public static void WriteResult(int input, int expect, int result)
		{
			WriteResult(input.ToString(), expect.ToString(), result.ToString());
		}
	}
}