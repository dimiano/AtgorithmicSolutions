/*

4. Median of Two Sorted Arrays

There are two sorted arrays nums1 and nums2 of size m and n respectively.
Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

Example 1:
nums1 = [1, 3]
nums2 = [2]

The median is 2.0
Example 2:
nums1 = [1, 2]
nums2 = [3, 4]

The median is (2 + 3)/2 = 2.5

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicSolutions.LeetCode
{
	public static class MedianOfTwoSortedArrays
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
		}

		private static double GetResult(int[] nums1, int[] nums2)
		{
			double result = 0.0;
			var merged = Merge(nums1, nums2);

			if (merged.Length % 2 == 0)
			{
				var middle2 = merged.Length / 2;
				var middle1 = middle2 - 1;

				result = (double)(merged[middle1] + merged[middle2]) / 2;
			}
			else
			{
				result = merged[merged.Length / 2];
			}

			return result;
		}

		private static int[] Merge(int[] nums1, int[] nums2)
		{
			var high = nums1.Length + nums2.Length;
			var result = new int[high];
			var index = 0;
			var i = 0;
			var j = 0;


			while ((i < nums1.Length || j < nums2.Length) && index < high)
			{
				if (i >= nums1.Length && j < nums2.Length)
				{
					result[index] = nums2[j];
					index++;
					j++;
					continue;
				}
				else if (j >= nums2.Length && i < nums1.Length)
				{
					result[index] = nums1[i];
					index++;
					i++;
					continue;
				}

				if (nums1[i] < nums2[j])
				{
					result[index] = nums1[i];
					index++;
					i++;
				}
				else if (nums1[i] == nums2[j])
				{
					result[index] = nums1[i];
					index++;
					i++;
					result[index] = nums2[j];
					index++;
					j++;
				}
				else
				{
					result[index] = nums2[j];
					index++;
					j++;
				}
			}

			return result;
		}

		private static void TestCase1()
		{
			var nums1 = new int[] { 1, 3 };
			var nums2 = new int[] { 2 };
			var expect = 2.0;

			var result = GetResult(nums1, nums2);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase2()
		{
			var nums1 = new int[] { 1, 2 };
			var nums2 = new int[] { 3, 4 };
			var expect = 2.5; // (2 + 3)/2

			var result = GetResult(nums1, nums2);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase3()
		{
			var nums1 = new int[] { 3, 4 };
			var nums2 = new int[] { };
			var expect = 3.5;

			var result = GetResult(nums1, nums2);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase4()
		{
			var nums1 = new int[] { 3 };
			var nums2 = new int[] { 1, 2 };
			var expect = 2.0;

			var result = GetResult(nums1, nums2);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}
	}
}
