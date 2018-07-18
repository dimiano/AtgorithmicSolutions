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

		public static void WriteResult(int[] input, int expect, int result)
		{
			WriteResult(ArrayToString(input), expect.ToString(), result.ToString());
		}

		public static void WriteResult(int[,] input, int expect, int result)
		{
			WriteResult(ArrayToString(input), expect.ToString(), result.ToString());
		}

		public static void WriteResult(object input, object expect, object result)
		{
			WriteResult(input.ToString(), expect.ToString(), result.ToString());
		}


		private static string ArrayToString(int[] input)
		{
			var builder = new StringBuilder("[");

			builder.Append(string.Join(",", input));
			builder.Append("]");

			return builder.ToString();
		}

		private static string ArrayToString(int[,] input)
		{
			var builder = new StringBuilder("[");
			var iMax = input.GetLength(0);
			var jMax = input.GetLength(1);

			for (int i = 0; i < iMax; i++)
			{
				if (i > 0)
				{
					builder.Append(",");
				}

				builder.Append('{');

				for (int j = 0; j < jMax; j++)
				{
					if (j > 0)
					{
						builder.Append(',');
					}
					builder.Append(input[i, j]);
				}
				builder.Append('}');
			}
			builder.Append(']');

			return builder.ToString();
		}
	}
}