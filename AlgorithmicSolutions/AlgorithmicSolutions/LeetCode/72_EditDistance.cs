/*

72. Edit Distance

Given two words word1 and word2, find the minimum number of operations required to convert word1 to word2.

You have the following 3 operations permitted on a word:

Insert a character
Delete a character
Replace a character

Example 1:
Input: word1 = "horse", word2 = "ros"
Output: 3

Explanation: 
horse -> rorse (replace 'h' with 'r')
rorse -> rose (remove 'r')
rose -> ros (remove 'e')

Example 2:
Input: word1 = "intention", word2 = "execution"
Output: 5

Explanation: 
intention -> inention (remove 't')
inention -> enention (replace 'i' with 'e')
enention -> exention (replace 'n' with 'x')
exention -> exection (replace 'n' with 'c')
exection -> execution (insert 'u')

*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class EditDistance
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();

			WriteResultStatistic();
		}

		private static int GetResult(string word1, string word2)
		{
			return GetResultDpUp(word1, word2);
			return GetResultRecursion(word1, word2);
		}

		// Bottom-Up
		private static int GetResultDpUp(string a, string b)
		{
			if (a.Length == 0) return b.Length;
			if (b.Length == 0) return a.Length;

			var dp = new int[a.Length + 1, b.Length + 1];

			for (int i = 1; i <= a.Length; i++) // boundary case, b is empty
			{
				dp[i, 0] = i;
			}
			for (int j = 1; j <= b.Length; j++) // boundary case, a is empty
			{
				dp[0, j] = j;
			}

			for (int i = 1; i <= a.Length; i++)
			{
				for (int j = 1; j <= b.Length; j++)
				{
					var diff = (a[i - 1] == b[j - 1]) ? 0 : 1;
					var min = Math.Min(dp[i - 1, j] + 1, // deletion
									   dp[i, j - 1] + 1); // insertion
					min = Math.Min(dp[i - 1, j - 1] + diff, min); // replacement
					dp[i, j] = min;
				}
			}

			return dp[a.Length, b.Length];
		}

		// Well, you may have noticed that each time when we update dp[i][j],
		// we only need dp[i - 1][j - 1], dp[i][j - 1], dp[i - 1][j].
		// In fact, we need not maintain the full m*n matrix. Instead, maintaining one column is enough. 
		// The code can be optimized to O(m) or O(n) space.
		private int MinDistance(string word1, string word2)
		{
			var m = word1.Length;
			var n = word2.Length;
			var cur = new int[m + 1];

			for (int i = 1; i <= m; i++)
			{
				cur[i] = i;
			}

			for (int j = 1; j <= n; j++)
			{
				int pre = cur[0];
				cur[0] = j;

				for (int i = 1; i <= m; i++)
				{
					int temp = cur[i];
					if (word1[i - 1] == word2[j - 1])
					{
						cur[i] = pre;
					}
					else
					{
						var min = Math.Min(cur[i] + 1, cur[i - 1] + 1);
						cur[i] = Math.Min(pre + 1, min);
					};

					pre = temp;
				}
			}
			return cur[m];
		}

		// Recursion 
		private static int GetResultRecursion(string a, string b)
		{
			var mem = new Dictionary<string, int>(a.Length * b.Length);

			return GetResultDpRecursion(0, 0, a, b, mem);
		}

		private static int GetResultDpRecursion(int i, int j, string a, string b, Dictionary<string, int> mem)
		{
			var key = i + ":" + j;
			if (mem.ContainsKey(key)) return mem[key];

			if (a.Length == 0) return b.Length;
			if (b.Length == 0) return a.Length;

			if (i == a.Length - 1 || j == b.Length - 1)
			{
				if (a.Length > b.Length)
				{
					return a.Length - b.Length;
				}

				return b.Length - a.Length;
			}
			var diff = (a[i] == b[j]) ? 0 : 1;
			var result = Math.Min(GetResultDpRecursion(i + 1, j, a, b, mem) + 1, // insert (equal reversed j - 1)
								  GetResultDpRecursion(i, j + 1, a, b, mem) + 1); // delete (equal reversed i -1)
			result = Math.Min(GetResultDpRecursion(i + 1, j + 1, a, b, mem) + diff, result); // replacement
			mem[key] = result;

			return mem[key];
		}



		private static void TestCase1()
		{
			var input1 = "horse";
			var input2 = "ros";
			var expect = 3;

			var result = GetResult(input1, input2);

			WriteResult(input1 + " -> " + input2, expect, result);
		}

		private static void TestCase2()
		{
			var input1 = "intention";
			var input2 = "execution";
			var expect = 5;

			var result = GetResult(input1, input2);

			WriteResult(input1 + " -> " + input2, expect, result);
		}
	}
}

