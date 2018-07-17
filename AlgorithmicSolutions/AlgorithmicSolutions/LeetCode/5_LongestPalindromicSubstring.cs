/*

5. Longest Palindromic Substring

Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

Example 1:
Input: "babad"
Output: "bab"
Note: "aba" is also a valid answer.

Example 2:
Input: "cbbd"
Output: "bb"


*/

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicSolutions.LeetCode
{
	public class LongestPalindromicSubstring
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
		}

		private static string GetResult(string s)
		{
			var result = string.Empty;
			var len = s.Length;
			var arr = new bool[len,len];
			var start = 0;
			var end = 0;

			for (int i = len - 1; i >= 0; i--)
			{
				for (int j = i; j < len; j++)
				{
					if (j - i < 3)
					{
						arr[i,j] = (s[i] == s[j]); //base case 
					}
					else
					{
						arr[i,j] = (s[i] == s[j] && arr[i + 1, j - 1]);
					}

					if (arr[i,j] && (end - start <= j - i))
					{
						start = i;
						end = j;
					}
				}
			}

			result = s.Substring(start, (end + 1 - start));
			return result;
		}

		private static int OverlapingSubproblems(string s)
		{
			var len = lps(s, 0, s.Length - 1);
			return len;
		}
		private static int lps(string seq, int i, int j) // length only
		{
			// Base Case 1: If there is only 1 character
			if (i == j)
			{
				return 1;
			}

			// Base Case 2: If there are only 2 characters and both are same
			if (seq[i] == seq[j] && i + 1 == j)
			{
				return 2;
			}

			// If the first and last characters match
			if (seq[i] == seq[j])
			{
				return lps(seq, i + 1, j - 1) + 2;
			}

			// If the first and last characters do not match
			var val1 = lps(seq, i, j - 1);
			var val2 = lps(seq, i + 1, j);

			return Math.Max(val1, val2);
		}

		private static int GetLpsLength(string s)
		{
			var len = s.Length;
			var arr = new int[len, len];

			for (int n = 0; n < len; n++)
			{
				arr[n, n] = 1;
			}

			var i = 0;
			var j = 0;

			for (int clmn = 2; clmn <= len; clmn++)
			{
				for (i = 0; i < len - clmn + 1; i++)
				{
					j = clmn + i - 1;

					if (s[i] == s[j])
					{
						if (clmn == 2)
						{
							arr[i, j] = 2;
						}
						else
						{
							arr[i, j] = arr[i + 1, j - 1] + 2;
						}
					}
					else
					{
						var val1 = arr[i, j - 1];
						var val2 = arr[i + 1, j];

						arr[i, j] = Math.Max(val1, val2);
					}
				}
			}

			var lenLPS = arr[0, len - 1];
			return lenLPS;
		}

		private static void TestCase1()
		{
			var input = "babad";
			var expect1 = "bab";
			var expect2 = "aba";

			var result = GetResult(input);

			Console.WriteLine(" INPUT:    " + input);
			Console.WriteLine(" EXPECTED: " + expect1);
			Console.WriteLine(" EXPECTED: " + expect2);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase2()
		{
			var input = "cbbd";
			var expect = "bb";

			var result = GetResult(input);

			Console.WriteLine(" INPUT:    " + input);
			Console.WriteLine(" EXPECTED: " + expect);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase3()
		{
			var input = "abcda";
			var expect = "a";

			var result = GetResult(input);

			Console.WriteLine(" INPUT:    " + input);
			Console.WriteLine(" EXPECTED: " + expect);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase4()
		{
			var input = "babadada";
			var expect = "adada";

			var result = GetResult(input);

			Console.WriteLine(" INPUT:    " + input);
			Console.WriteLine(" EXPECTED: " + expect);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}
	}
}
