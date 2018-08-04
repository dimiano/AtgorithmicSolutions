/*

87. Scramble String

Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively.
Below is one possible representation of s1 = "great":

	great
   /    \
  gr    eat
 / \    /  \
g   r  e   at
		   / \
		  a   t
To scramble the string, we may choose any non-leaf node and swap its two children.

For example, if we choose the node "gr" and swap its two children, it produces a scrambled string "rgeat".

	rgeat
   /    \
  rg    eat
 / \    /  \
r   g  e   at
		   / \
		  a   t
We say that "rgeat" is a scrambled string of "great".

Similarly, if we continue to swap the children of nodes "eat" and "at", it produces a scrambled string "rgtae".

	rgtae
   /    \
  rg    tae
 / \    /  \
r   g  ta  e
	   / \
	  t   a
We say that "rgtae" is a scrambled string of "great".

Given two strings s1 and s2 of the same length, determine if s2 is a scrambled string of s1.

Example 1:

Input: s1 = "great", s2 = "rgeat"
Output: true
Example 2:

Input: s1 = "abcde", s2 = "caebd"
Output: false

*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class ScrambleString
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();

			WriteResultStatistic();
		}

		private static bool GetResult(string s1, string s2)
		{
			return GetResultRecursion(s1, s2);
		}

		// Recursion 
		private static bool GetResultRecursion(string s1, string s2)
		{
			return DpRecursion(s1, s2);
		}

		private static bool DpRecursion(string s1, string s2)
		{
			if (s1.Length != s2.Length) return false;
			if (s1 == s2) return true;

			var abcLen = 26;
			var letters = new int[abcLen];

			for (int i = 0; i < s1.Length; i++)
			{
				letters[s1[i] - 'a']++; // 'a' == 61
				letters[s2[i] - 'a']--;
			}

			for (int i = 0; i < abcLen; i++) // check letters are the same
			{
				if (letters[i] != 0)
				{
					return false;
				}
			}

			for (int i = 1; i < s1.Length; i++)
			{
				if (DpRecursion(s1.Substring(0, i), s2.Substring(0, i))
				 && DpRecursion(s1.Substring(i), s2.Substring(i)))
				{
					return true;
				}
				if (DpRecursion(s1.Substring(0, i), s2.Substring(s2.Length - i))
				 && DpRecursion(s1.Substring(i), s2.Substring(0, s2.Length - i)))
				{
					return true;
				}
			}
			return false;
		}



		private static void TestCase1()
		{
			var input1 = "great";
			var input2 = "rgeat";
			var expect = true;

			var result = GetResult(input1, input2);

			WriteResult(input1 + " - " + input2, expect, result);
		}

		private static void TestCase2()
		{
			var input1 = "abcde";
			var input2 = "caebd";
			var expect = false;

			var result = GetResult(input1, input2);

			WriteResult(input1 + " - " + input2, expect, result);
		}
	}
}

