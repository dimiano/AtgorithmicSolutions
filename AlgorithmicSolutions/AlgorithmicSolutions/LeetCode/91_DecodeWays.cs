/*

91. Decode Ways

A message containing letters from A-Z is being encoded to numbers using the following mapping:

'A' -> 1
'B' -> 2
...
'Z' -> 26
Given a non-empty string containing only digits, determine the total number of ways to decode it.

Example 1:
Input: "12"
Output: 2

Explanation: It could be decoded as "AB" (1 2) or "L" (12).

Example 2:
Input: "226"
Output: 3

Explanation: It could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).

*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class DecodeWays
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
			TestCase5();

			WriteResultStatistic();
		}

		private static int GetResult(string s)
		{
			//return GetResultDpUp(s);
			return GetResultRecursion(s);
		}

		// Bottom-Up
		private static int GetResultDpUp(string s)
		{
			if (s == "") return 0;

			int n = s.Length;
			var dp = new int[n + 1];
			dp[0] = 1;
			dp[1] = s[0] != '0' ? 1 : 0;

			for (int i = 2; i <= n; i++)
			{
				int first = int.Parse(s.Substring(i - 1, 1));
				int second = int.Parse(s.Substring(i - 2, 2));

				if (first >= 1 && first <= 9)
				{
					dp[i] += dp[i - 1];
				}
				if (second >= 10 && second <= 26)
				{
					dp[i] += dp[i - 2];
				}
			}

			return dp[n];
		}

		// Recursion
		private static int GetResultRecursion(string s)
		{
			if (s == "") return 0;
			var mem = new Dictionary<int, int>();

			return DpRecursion(0, s, mem);
		}

		private static int DpRecursion(int start, string s, Dictionary<int, int> mem)
		{
			if (start >= s.Length) return 1;
			if (mem.ContainsKey(start)) return mem[start];

			var result = 0;
			var num = int.Parse(s.Substring(start, 1));

			if (num <= 26 && num > 0)
			{
				result = DpRecursion(start + 1, s, mem);
			}

			if (start + 2 <= s.Length)
			{
				num = int.Parse(s.Substring(start, 2));

				if (num <= 26)
				{
					result += DpRecursion(start + 2, s, mem);
				}
			}

			mem.Add(start, result);

			return result;
		}



		private static void TestCase1()
		{
			var input = "12";
			var expect = 2;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = "226";
			var expect = 3;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = "567567";
			var expect = 1;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase4()
		{
			var input = "22222";
			var expect = 8;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase5()
		{
			var input = "102030405060708090";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
	}
}
