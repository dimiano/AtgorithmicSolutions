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

Explanation: '*' means zero or more of the precedeng element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".

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
			throw new NotImplementedException("Regular Expression Matching");
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
