/*

11. Container With Most Water

Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). 
n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). 
Find two lines, which together with x-axis forms a container, such that the container contains the most water.

Note: You may not slant the container and n is at least 2.


Analysis

1. Assume X axis starts from 0 to N-1 
2. Start Calculation of max area from extreme ends of 2d coordinates. (Biggest rectangle over x axis)
3. Area of a rectangle is - Length * Bread. i.e.  [Height * Distance from origin(0-n-1)]
4. While calculation of Area, consider minimum height between 2 coordinates considered.

 */

using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class ContainerWithMostWater
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
		}

		private static int GetResult(int[] height)
		{
			var maxArea = 0;
			var i = 0;
			var j = height.Length - 1;  //x axis coordinates

			while (i < j)
			{
				var minHeight = Math.Min(height[i], height[j]); // water will pour out of the lowest wall
				var distance = (j - i);
				maxArea = Math.Max(maxArea, minHeight * distance);

				if (height[i] < height[j]) // stay at highest wall
				{
					i++;
				}
				else
				{
					j--;
				}
			}
			
			return maxArea;
		}

		private static int GetResultBruteForce(int[] height)
		{
			var maxArea = 0;

			for (int i = 0; i < height.Length; i++)
			{
				for (int j = i + 1; j < height.Length; j++)
				{
					var minHeight = Math.Min(height[i], height[j]); // water will pour out of the lowest wall
					var distance = (j - i);
					maxArea = Math.Max(maxArea, minHeight * distance);
				}
			}

			return maxArea;

		}

		private static int GetResultReady(int[] height)
		{
			var maxArea = 0;
			var i = 0;
			var j = height.Length - 1;  //x axis coordinates

			while (i < j)
			{
				int tempMaxArea = Math.Min(height[i], height[j]) * (j - i);
				maxArea = Math.Max(maxArea, tempMaxArea);

				if (height[i] < height[j])
				{
					i++;
				}
				else
				{
					j--;
				}
			}

			return maxArea;
		}


		private static void TestCase1()
		{
			var input = new int[] { 1, 1 };
			var expect = 1;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = new int[] { 0, 2 };
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
			var expect = 49;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
	}
}
