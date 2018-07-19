/*

14. Longest Common Prefix

Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

Example 1:
Input: ["flower","flow","flight"]
Output: "fl"

Example 2:
Input: ["dog","racecar","car"]
Output: ""

Explanation: There is no common prefix among the input strings.

Note:
All given inputs are in lowercase letters a-z.

*/


using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class LongestCommonPrefix
	{
		public static void Test()
		{
			Console.WriteLine("14. Longest Common Prefix");
			Console.WriteLine();

			TestCase1();
			TestCase2();
			TestCase3();
		}

		private static string GetResult(string[] strs)
		{
			if (strs.Length < 1)
			{
				return string.Empty;
			}
			else if (strs.Length < 2)
			{
				return strs[0];
			}

			var result =  strs[0];
			
			for (int n = 0; n < strs.Length; n++)
			{
				result = CommonPrefix(result, strs[n]);
			}

			return result;
		}
		
		private static string CommonPrefix(string str1, string str2)
		{
			var res = string.Empty;
			var i = 0;
			var j = 0;
			var minLen = Math.Min(str1.Length, str2.Length);

			while ( i < minLen && str1[i] == str2[j])
			{
				res += str1[i];
				i++;
				j++;
			}

			return res;
		}
		
		private static void TestCase1()
		{
			var input = new[] { "flower", "flow", "flight" };
			var expect = "fl";

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = new[] { "dog", "racecar", "car" };
			var expect = "";

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = new[] { "dog" };
			var expect = "dog";

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
	}
}
