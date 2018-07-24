/*

44. Wildcard Matching

Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*'.

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).
The matching should cover the entire input string (not partial).

Note:

s could be empty and contains only lowercase letters a-z.
p could be empty and contains only lowercase letters a-z, and characters like ? or *.

Example 1:
Input:
s = "aa"
p = "a"
Output: false

Explanation: "a" does not match the entire string "aa".

Example 2:
Input:
s = "aa"
p = "*"
Output: true

Explanation: '*' matches any sequence.

Example 3:
Input:
s = "cb"
p = "?a"
Output: false

Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.

Example 4:
Input:
s = "adceb"
p = "*a*b"
Output: true

Explanation: The first '*' matches the empty sequence, while the second '*' matches the substring "dce".

Example 5:
Input:
s = "acdcb"
p = "a*c?b"
Output: false

*/


using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class WildcardMatching
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
			TestCase5();
			TestCase6();
			TestCase7();
			TestCase8();
			TestCase9();
			TestCase10();
			TestCase11();
			TestCase12();
			TestCase13();
			TestCase14();
			TestCase15();
			TestCase16();
			TestCase17();
			TestCase18();
			TestCase19();
			TestCase20();
			TestCase21();
			TestCase22();

			WriteResultStatistic();
		}

		private static bool GetResult(string s, string p)
		{
			int sLen = s.Length;
			int pLen = p.Length;

			if (sLen == 0 && pLen == 0) return true;
			if (sLen > 0 && pLen == 0) return false;

			var dp = new bool[sLen + 1, pLen + 1];

			dp[0, 0] = true;

			for (int i = 1; i <= pLen; i++)
			{
				if (p[i - 1] == '*')
				{
					dp[0, i] = dp[0, i - 1];
				}
				else
				{
					dp[0, i] = false;
				}
			}

			for (int i = 1; i <= sLen; i++)
			{
				for (int j = 1; j <= pLen; j++)
				{
					if (p[j - 1] == s[i - 1] || p[j - 1] == '?')
					{
						dp[i, j] = dp[i - 1, j - 1];
					}
					else if (p[j - 1] == '*')
					{
						dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
					}
					else
					{
						dp[i, j] = false;
					}
				}
			}

			return dp[sLen, pLen];
		}


		private static bool GetResultMy(string s, string p)
		{
			if (p == "")
			{
				return s == "";
			}
			else if (p == "?")
			{
				return s.Length == 1;
			}
			else if (p == "*")
			{
				return true;
			}
			else if (s == "")
			{
				return p == "";
			}

			var dp = new bool[s.Length];
			var pLast = false;
			var i = 0;
			var j = 0;

			while (i < s.Length && j < p.Length)
			{
				var match = j < p.Length && (p[j] == s[i] || p[j] == '?');

				if (match)
				{
					dp[i] = (i == 0) ? true : dp[i - 1];
					i++;
					j++;
				}
				else if (j < p.Length && p[j] == '*')
				{
					dp[i] = (i == 0) ? true : dp[i - 1];

					while (j + 1 < p.Length)
					{
						if (p[j + 1] == '*')
						{
							j++;
						}
						else
						{
							break;
						}
					}

					var found = false;
					pLast = j == p.Length - 1;

					if (!pLast)
					{
						if (j + 1 < p.Length - 1 && p[j + 1] == '?')
						{
							j++;
						}
						else
						{
							for (var k = s.Length - 1; k >= i; k--)
							{
								if (p[j + 1] == s[k] || p[j + 1] == '?')
								{
									found = true;
									dp[k] = dp[i];
									i = k + 1;
									j++;
									break;
								}
							}
						}
					}

					j = pLast ? j : j + 1;
					i = found ? i : i + 1;
				}
				else if (j > 0 && p[j - 1] == '*')
				{
					dp[i] = i > 0 ? dp[i - 1] : true;
					i++;
				}
				else
				{
					pLast = j == p.Length - 1;
					dp[i] = false;
					i++;
					j++;
				}
			}

			if (j <= p.Length - 1)
			{
				for (; j < p.Length; j++)
				{
					if (p[j] != '*')
					{
						return false;
					}
				}
			}

			return dp[s.Length - 1];
		}



		private static void TestCase1()
		{
			var input = "aa";
			var pattern = "a";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase2()
		{
			var input = "aa";
			var pattern = "*";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase3()
		{
			var input = "cb";
			var pattern = "?a";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase4()
		{
			var input = "adceb";
			var pattern = "a*b";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase5()
		{
			var input = "";
			var pattern = "*";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase6()
		{
			var input = "a";
			var pattern = "";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase7()
		{
			var input = "";
			var pattern = "a";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase8()
		{
			var input = "adceb";
			var pattern = "*a*b";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase9()
		{
			var input = "acdcb";
			var pattern = "a*c?b";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase10()
		{
			var input = "cabab";
			var pattern = "*ab";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase11()
		{
			var input = "aa";
			var pattern = "a*";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase12()
		{
			var input = "leetcode";
			var pattern = "*e*t?d*";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase13()
		{
			var input = "c";
			var pattern = "*?*";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase14()
		{
			var input = "ab";
			var pattern = "*?*?*";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase15()
		{
			var input = "b";
			var pattern = "*?*?*";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase16()
		{
			var input = "hi";
			var pattern = "*?";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase17()
		{
			var input = "ho";
			var pattern = "**ho";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase18()
		{
			var input = "aaab";
			var pattern = "b**";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase19()
		{
			var input = "ho";
			var pattern = "ho**";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase20()
		{
			var input = "abce";
			var pattern = "abc*?";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase21()
		{
			var input = "abce";
			var pattern = "abc*??";
			var expect = false;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}

		private static void TestCase22()
		{
			var input = "mississippi";
			var pattern = "m*iss*";
			var expect = true;

			var result = GetResult(input, pattern);

			WriteResult(input, pattern, expect, result);
		}
	}
}
