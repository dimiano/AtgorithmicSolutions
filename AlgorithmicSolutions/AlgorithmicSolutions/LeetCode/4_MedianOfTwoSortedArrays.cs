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
		}

		private static double GetResult(int[] nums1, int[] nums2)
		{
			var first = nums1;
			var second = nums2;

			if(nums1.Length < nums2.Length)
			{
				first = nums2;
				second = nums1;
			}

			for (int i = nums1.Length - 1; i >= 0; i--)
			{
				for (int j = 0; j < nums2.Length; j++)
				{
					if (nums1[i] < nums2[j])
					{
						return (double)(nums1[i] + nums2[j]) / 2;
					}
				}
			}

			return 0;
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

	}
}
