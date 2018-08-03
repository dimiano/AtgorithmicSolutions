﻿/*

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

				max = GetMaxArea(row);
				maxArea = Math.Max(maxArea, max);
			}

			return maxArea;
		}

		private static int GetMaxArea(int[] arr)
		{
			var stack = new Stack<int>();
			var max = 0;
			var i = 0;

			for (i = 0; i < arr.Length;)
			{
				if (stack.Count == 0 || arr[stack.Peek()] <= arr[i])
				{
					stack.Push(i++);
				}
				else
				{
					var area = 0;
					var top = stack.Pop();

					if (stack.Count == 0)
					{
						area = arr[top] * i;
					}
					else
					{
						area = arr[top] * (i - stack.Peek() - 1);
					}
					max = Math.Max(area, max);
				}
			}

			while (stack.Count != 0)
			{
				var area = 0;
				var top = stack.Pop();

				if (stack.Count == 0)
				{
					area = arr[top] * i;
				}
				else
				{
					area = arr[top] * (i - stack.Peek() - 1);
				}
				max = Math.Max(area, max);
			}

			return max;
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

