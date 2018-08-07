/*

85. Maximal Rectangle

Given a 2D binary matrix filled with 0's and 1's, 
find the largest rectangle containing only 1's and return its area.

Example:

Input:
[
  ["1","0","1","0","0"],
  ["1","0","1","1","1"],
  ["1","1","1","1","1"],
  ["1","0","0","1","0"]
]
Output: 6

*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class MaximalRectangle
	{
		public static void Test()
		{
			TestCase1();

			WriteResultStatistic();
		}

		private static int GetResult(char[,] matrix)
		{
			return GetResultDpUp(matrix);
			return GetResultDpUp1(matrix);
		}

		// Bottom-Up
		private static int GetResultDpUp(char[,] arr)
		{
			var rows = arr.GetLength(0);
			var cols = arr.GetLength(1);
			var max = 0;
			var maxArea = 0;
			var row = new int[cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					row[j] = (arr[i, j] == '1') ? row[j] + 1 : 0;
				}

				max = LargestRectangleInHistogram.GetResult(row);
				maxArea = Math.Max(maxArea, max);
			}

			return maxArea;
		}

		// Bottom-Up
		private static int GetResultDpUp1(char[,] arr)
		{
			var rows = arr.GetLength(0);
			var cols = arr.GetLength(1);
			var max = 0;
			var maxArea = 0;
			var endA = 0;
			var endB = 0;
			var dp = new int[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				dp[i, 0] = arr[i, 0] == '1' ? 1 : 0;
			}

			for (int i = 0; i < cols; i++)
			{
				dp[0, i] = arr[0, i] == '1' ? 1 : 0;
			}

			for (int i = 1; i < rows; i++)
			{
				for (int j = 1; j < cols; j++)
				{
					if (arr[i, j] != '0')
					{
						var min = Math.Min(dp[i, j - 1], dp[i - 1, j]);
						var curr = Math.Min(dp[i - 1, j - 1], min) + 1;
						dp[i, j] = curr;

						if (curr >= max)
						{
							max = curr;
							endA = i;
							endB = j;
						}
					}
				}
			}
			var a = 0;
			for (a = endA - 1; a >= 0; a--)
			{
				if (dp[a, endB] < dp[a + 1, endB])
				{
					break;
				}
			}
			var b = 0;
			for (b = endB - 1; b >= 0; b--)
			{
				if (dp[endA, b] < dp[endA, b + 1])
				{
					break;
				}
			}
			maxArea = (endB - b + 1) * (endA - a + 1);
			return maxArea;
		}


		private static void TestCase1()
		{
			var input = new char[,] {
				{'1','0','1','0','0'},
				{'1','0','1','1','1'},
				{'1','1','1','1','1'},
				{'1','0','0','1','0'}};
			var expect = 6;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
	}
}
