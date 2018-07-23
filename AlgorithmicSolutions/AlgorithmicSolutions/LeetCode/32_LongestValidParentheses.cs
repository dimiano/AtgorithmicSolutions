/*

32. Longest Valid Parentheses

Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

Example 1:
Input: "(()"
Output: 2

Explanation: The longest valid parentheses substring is "()"

Example 2:
Input: ")()())"
Output: 4

Explanation: The longest valid parentheses substring is "()()"

*/


using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class LongestValidParentheses
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
		}

		private static int GetResult(string s)
		{
			var max = 0;
			var dp = new int[s.Length];
			var i = 1;

			while (i < s.Length)
			{
				if (s[i] == ')')
				{
					var len = 0;

					if (s[i-1] == '(')
					{
						if (i < 2)
						{
							len = 2;
						}
						else
						{
							len = dp[i - 2] + 2;
						}
					}
					else
					{
						var lenPrev = dp[i - 1];

						if (i > lenPrev)
						{
							var prevIndx = i - lenPrev - 1;

							if (s[prevIndx] == '(')
							{
								var prevPrevIndx = prevIndx - 1;
								int extend = (prevPrevIndx >= 0) ? dp[prevPrevIndx] : 0;
								len = lenPrev + 2 + extend;
							}
						}
					}

					dp[i] = len;

					if (len > max)
					{
						max = len;
					}
				}

				i++;
			}

			return max;
		}


		private static int longestValidParentheses(string s)
		{
			var longest = 0;
			var dp = new int[s.Length];
			var i = 1;

			while (i < s.Length)
			{
				if (s[i] == ')')
				{
					var len = 0;

					if (s[i - 1] == '(')
					{
						if (i < 2)
						{
							// found pair at beginning of input; nothing else to check
							len = 2;
						}
						else
						{
							// found pair later in the input; this extends any sequence that was
							// aready found which terminated at the previous character (i - 2)
							len = 2 + dp[i - 2];
						}
					}
					else
					{
						// found a close paren; check the previous index in the dp array to find
						// how long was the longest sequence that ended before this close paren
						int longestPrev = dp[i - 1];

						if (i > longestPrev)
						{
							int beforeLongest = i - longestPrev - 1;
							char charBefore = s[beforeLongest];

							if (charBefore == '(')
							{
								// The character prior to the previous sequence was an open paren, meaning we
								// now completed it.  These two parens surround a known sequence, so we add 2.
								// But the sequence might be even longer than that.  We look at the character
								// before the open paren that we just matched; if that character closed a
								// sequence, we add the length of THAT sequence, too.
								int beforeNew = beforeLongest - 1;
								int nowExtended = (beforeNew >= 0) ? dp[beforeNew] : 0;
								len = longestPrev + 2 + nowExtended;
							}
						}
						// else, the previous sequence started at the beginning of the input, so this close paren
						// cannot possibly extend it
					}
					dp[i] = len;

					if (len > longest)
					{
						longest = len;
					}
				}
				// else (s[i != ')'), so it can't possibly close a sequence, so there's nothing to check
				i++;
			}

			return longest;
		}

		private static int Dp0(string s)
		{
			var maxans = 0;
			var dp = new int[s.Length];

			for (int i = 1; i < s.Length; i++)
			{
				if (s[i] == ')')
				{
					if (s[i - 1] == '(')
					{
						dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
					}
					else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
					{
						dp[i] = dp[i - 1] + ((i - dp[i - 1]) >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
					}

					maxans = Math.Max(maxans, dp[i]);
				}
			}

			return maxans;
		}

		private static int Stack0(string s)
		{
			int maxans = 0;
			var stack = new Stack<int>();
			stack.Push(-1);

			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '(')
				{
					stack.Push(i);
				}
				else
				{
					stack.Pop();
					if (stack.Count == 0)
					{
						stack.Push(i);
					}
					else
					{
						maxans = Math.Max(maxans, i - stack.Peek());
					}
				}
			}
			return maxans;
		}


		private static void TestCase1()
		{
			var input = "(()";
			var expect = 2;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = ")()())";
			var expect = 4;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = "))))";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase4()
		{
			var input = ")((";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase5()
		{
			var input = "";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase6()
		{
			var input = "(()()((()))))))()()()";
			var expect = 12;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase7()
		{
			var input = "()(())";
			var expect = 6;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase8()
		{
			var input = "()(()";
			var expect = 2;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase9()
		{
			var input = "(()(()))";
			var expect = 8;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
	}
}
