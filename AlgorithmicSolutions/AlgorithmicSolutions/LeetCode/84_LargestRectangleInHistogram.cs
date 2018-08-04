/*

84. Largest Rectangle in Histogram

Given n non-negative integers representing the histogram's bar height where 
the width of each bar is 1, find the area of largest rectangle in the histogram.

Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].
The largest rectangle is shown in the shaded area, which has area = 10 unit.

Example:

Input: [2,1,5,6,2,3]
Output: 10

*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class LargestRectangleInHistogram
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();

			WriteResultStatistic();
		}

		private static int GetResult(int[] heights)
		{
			return GetResultDpUp(heights);
		}

		// Bottom-Up
		private static int GetResultDpUp(int[] arr)
		{
			var stack = new Stack<int>();
			var maxArea = 0;
			var i = 0;

			while (i < arr.Length)
			{
				if (stack.Count == 0 || arr[stack.Peek()] <= arr[i])
				{
					stack.Push(i);
					i++;
				}
				else
				{
					var top = stack.Pop();
					var width = stack.Count == 0 ? i: i - 1 - stack.Peek();
					var area = arr[top] * width;
					maxArea = Math.Max(area, maxArea);
				}
			}

			while (stack.Count > 0)
			{
				var top = stack.Pop();
				var width = stack.Count == 0 ? i : i - 1 - stack.Peek();
				var area = arr[top] * width;
				maxArea = Math.Max(area, maxArea);
			}

			return maxArea;
		}

		private static int GetResultDpUp0(int[] arr)
		{
			var stack = new Stack<int>();
			var max = 0;
			var i = 0;

			while (i < arr.Length)
			{
				if (stack.Count == 0 || arr[stack.Peek()] <= arr[i])
				{
					stack.Push(i);
					i++;
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
			var input = new int[] { 2, 1, 5, 6, 2, 3 };
			var expect = 10;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
		private static void TestCase2()
		{
			var input = new int[] { 2, 1, 2 };
			var expect = 3;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
	}
}

