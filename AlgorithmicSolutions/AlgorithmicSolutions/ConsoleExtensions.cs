using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicSolutions
{
	public static class ConsoleExtensions
	{
		private static int _count = 1;
		private static int _successCount = 0;
		private static int _failedCount = 0;

		#region Write Result

		public static void WriteResult(string input, string expect, string result)
		{
			Console.WriteLine($"{_count++:00}. INPUT: {CheckParam(input)}");
			Console.WriteLine(" EXPECTED: " + CheckParam(expect));
			Console.Write(" RESULT:   " + CheckParam(result));
			var color = Console.ForegroundColor;

			if (expect == result)
			{
				_successCount++;
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(" - CORRECT");
			}
			else
			{
				_failedCount++;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(" - WRONG");
			}
			Console.ForegroundColor = color;

			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		public static void WriteResult(string input1, string input2, string expect, string result)
		{
			Console.WriteLine($"{_count++:00}. INPUT1: {CheckParam(input1)}");
			Console.WriteLine(" INPUT2:    " + CheckParam(input2));
			Console.WriteLine(" EXPECTED:  " + CheckParam(expect));
			Console.Write(" RESULT:    " + CheckParam(result));
			var color = Console.ForegroundColor;

			if (expect == result)
			{
				_successCount++;
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(" - CORRECT");
			}
			else
			{
				_failedCount++;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(" - WRONG");
			}
			Console.ForegroundColor = color;

			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		public static void WriteResult(string[] input, string expect, string result)
		{
			WriteResult(ArrayToString(input), expect, result);
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

		public static void WriteResult(object input1, object input2, object expect, object result)
		{
			WriteResult(input1.ToString(), input2.ToString(), expect.ToString(), result.ToString());
		}

		#endregion Write Result

		public static void WriteResultStatistic()
		{
			var color = Console.ForegroundColor;

			_successCount++;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(" CORRECT : " + _successCount);

			Console.ForegroundColor = color;
			Console.Write(" /");

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(" WRONG : " + _failedCount);

			Console.ForegroundColor = color;

			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static string CheckParam(string val)
		{
			if (val == null)
			{
				val = "<null>";
			}
			else if (val == "")
			{
				val = "\"\"";
			}

			return val;
		}

		private static string ArrayToString(int[] input)
		{
			var builder = new StringBuilder("[");

			builder.Append(string.Join(",", input));
			builder.Append("]");

			return builder.ToString();
		}

		private static string ArrayToString(string[] input)
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