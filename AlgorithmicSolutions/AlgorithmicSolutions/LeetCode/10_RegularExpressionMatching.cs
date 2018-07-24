/*

10. Regular Expression Matching

Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*'.

'.' Matches any single character.
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).

Note:

s could be empty and contains only lowercase letters a-z.
p could be empty and contains only lowercase letters a-z, and characters like . or *.

Example 1:
Input:
s = "aa"
p = "a"
Output: false

Explanation: "a" does not match the entire string "aa".

Example 2:
Input:
s = "aa"
p = "a*"
Output: true

Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".

Example 3:
Input:
s = "ab"
p = ".*"
Output: true

Explanation: ".*" means "zero or more (*) of any character (.)".

Example 4:
Input:
s = "aab"
p = "c*a*b"
Output: true

Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore it matches "aab".

Example 5:
Input:
s = "mississippi"
p = "mis*is*p*."
Output: false

*/


using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class RegularExpressionMatching
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
			TestCase5();
		}

		private static bool GetResult(string s, string p)
		{
			return GetResultDpUp(s, p);

			return GetResultDPDown(s, p);

			return IsMatchRecursion(s, p);
		}

		// DP Bottom-Up
		private static bool GetResultDpUp(string s, string p)
		{
			var dp = new bool[s.Length + 1, p.Length + 1];
			dp[s.Length, p.Length] = true;

			for (int i = s.Length; i >= 0; i--) // i = s.Length handles '*' case
			{
				for (int j = p.Length - 1; j >= 0; j--)
				{
					var firstMatch = (i < s.Length && (p[j] == s[i] || p[j] == '.'));

					if (j + 1 < p.Length && p[j + 1] == '*')
					{
						dp[i, j] = dp[i, j + 2] || firstMatch && dp[i + 1, j];
					}
					else
					{
						dp[i, j] = firstMatch && dp[i + 1, j + 1];
					}
				}
			}
			return dp[0, 0];
		}


		/// <summary>
		/// 1, If p[j] == s[i] : dp[i,j] = dp[i - 1,j - 1];
		/// 2, If p[j] == '.' : dp[i,j] = dp[i - 1,j - 1];
		/// 3, If p[j] == '*': 
		/// 	here are two sub conditions:
		/// 		1	if p.charAt(j-1) != s[i] : dp[i,j] = dp[i,j - 2]	// in this case, a* only counts as empty
		/// 		2	if p.charAt(i-1) == s[i] or p.charAt(i-1) == '.':
		/// 				dp[i,j] = dp[i - 1,j]		// in this case, a* counts as multiple a 
		/// 				or dp[i,j] = dp[i,j - 1]	// in this case, a* counts as single a
		/// 				or dp[i,j] = dp[i,j - 2]	// in this case, a* counts as empty
		/// </summary>
		public bool GetResultDpUp0(string s, string p)
		{
			if (s == "" || p == "")
			{
				return false;
			}

			var dp = new bool[s.Length + 1, p.Length + 1];
			dp[0, 0] = true;

			for (int i = 0; i < p.Length; i++)
			{
				if (p[i] == '*' && dp[0, i - 1])
				{
					dp[0, i + 1] = true;
				}
			}

			for (int i = 0; i < s.Length; i++)
			{
				for (int j = 0; j < p.Length; j++)
				{
					if (p[j] == '.')
					{
						dp[i + 1, j + 1] = dp[i, j];
					}
					if (p[j] == s[i])
					{
						dp[i + 1, j + 1] = dp[i, j];
					}
					if (p[j] == '*')
					{
						if (p[j - 1] != s[i] && p[j - 1] != '.')
						{
							dp[i + 1, j + 1] = dp[i + 1, j - 1];
						}
						else
						{
							dp[i + 1, j + 1] = (dp[i + 1, j] || dp[i, j + 1] || dp[i + 1, j - 1]);
						}
					}
				}
			}
			return dp[s.Length, p.Length];
		}


		// DP Top-Down
		enum Valid
		{
			Default,
			TRUE,
			FALSE
		}

		private static bool GetResultDPDown(string s, string p)
		{
			return IsMatch(0, 0, s, p, new Valid[s.Length + 1, p.Length + 1]);
		}

		private static bool IsMatch(int i, int j, string s, string p, Valid[,] cache)
		{
			if (cache[i, j] != Valid.Default)
			{
				return cache[i, j] == Valid.TRUE;
			}

			var result = false;

			if (j == p.Length)
			{
				result = i == s.Length;
			}
			else
			{
				var firstMatch = (i < s.Length) && (s[i] == p[j] || p[j] == '.');

				if (j + 1 < p.Length && p[j + 1] == '*')
				{
					result = (IsMatch(i, j + 2, s, p, cache) || firstMatch && IsMatch(i + 1, j, s, p, cache));
				}
				else
				{
					result = firstMatch && IsMatch(i + 1, j + 1, s, p, cache);
				}
			}
			cache[i, j] = result ? Valid.TRUE : Valid.FALSE;

			return result;
		}

		// Recursion
		private static bool IsMatchRecursion(string text, string pattern)
		{
			if (string.IsNullOrEmpty(pattern))
			{
				return string.IsNullOrEmpty(text);
			}
			var firstMatch = (!string.IsNullOrEmpty(text) && (pattern[0] == text[0] || pattern[0] == '.'));

			if (pattern.Length >= 2 && pattern[1] == '*')
			{
				return (IsMatchRecursion(text, pattern.Substring(2)) || (firstMatch && IsMatchRecursion(text.Substring(1), pattern)));
			}
			else
			{
				return firstMatch && IsMatchRecursion(text.Substring(1), pattern.Substring(1));
			}
		}




		private static void TestCase1()
		{
			var input = "aa";
			var pattern = "a";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = "aa";
			var pattern = "a*";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = "ab";
			var pattern = ".*";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, expect, result);
		}

		private static void TestCase4()
		{
			var input = "aab";
			var pattern = "c*a*b";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, expect, result);
		}

		private static void TestCase5()
		{
			var input = "mississippi";
			var pattern = "mis*is*p*.";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, expect, result);
		}
	}
}
