/*

868. Binary Gap

Difficulty: Easy
Given a positive integer N, find and return the longest distance between two consecutive 1's in the binary representation of N.

If there aren't two consecutive 1's, return 0.

 

Example 1:

Input: 22
Output: 2
Explanation: 
22 in binary is 0b10110.
In the binary representation of 22, there are three ones, and two consecutive pairs of 1's.
The first consecutive pair of 1's have distance 2.
The second consecutive pair of 1's have distance 1.
The answer is the largest of these two distances, which is 2.


Example 2:

Input: 5
Output: 2
Explanation: 
5 in binary is 0b101.


Example 3:

Input: 6
Output: 1
Explanation: 
6 in binary is 0b110.


Example 4:

Input: 8
Output: 0
Explanation: 
8 in binary is 0b1000.
There aren't any consecutive pairs of 1's in the binary representation of 8, so we return 0.
 

Note:
1 <= N <= 10^9

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicSolutions.LeetCode
{
	public class BinaryGap
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
			TestCase5();
			TestCase6();
		}

		private static int GetResult(int N)
		{
			var binary = Convert.ToString(N, 2);
			var lastIndex = binary.Length;
			var firstIndex = 0;
			var distance = 0;
			var prevZero = false;

			for (int i = 0; i < binary.Length; i++)
			{
				if (binary[i] == '1')
				{
					lastIndex = i;

					if (prevZero)
					{
						distance = Math.Max(distance, lastIndex - firstIndex);
						firstIndex = i;
					}

					if (i > 0 && binary[i - 1] == '1')
					{
						distance = Math.Max(distance, 1);
					}

					firstIndex = i;
					prevZero = false;
				}
				else
				{
					prevZero = true;
				}
			}

			return distance;
		}

		private static void TestCase1()
		{
			var num = 22;
			var expect = 2;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase2()
		{
			var num = 5;
			var expect = 2;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase3()
		{
			var num = 6;
			var expect = 1;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase4()
		{
			var num = 8;
			var expect = 0;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase5()
		{
			var num = 7;
			var expect = 1;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase6()
		{
			var num = 2414;
			var expect = 3;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}
	}
}
