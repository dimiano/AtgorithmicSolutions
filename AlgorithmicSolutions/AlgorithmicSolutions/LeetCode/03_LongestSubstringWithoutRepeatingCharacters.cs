/*

3. Longest Substring Without Repeating Characters

DescriptionHintsSubmissionsDiscussSolution
Given a string, find the length of the longest substring without repeating characters.

Examples:

Given "abcabcbb", the answer is "abc", which the length is 3.
Given "bbbbb", the answer is "b", with the length of 1.
Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicSolutions.LeetCode
{
	public static class LongestSubstringWithoutRepeatingCharacters
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
		}

		private static int GetResult(string s)
		{
			char curr;
			var res1 = new HashSet<char>();
			var res2 = new HashSet<char>();
			var list = new List<char>();

			if (s.Length > 0)
			{
				curr = s[0];
				res1.Add(curr);
				list.Add(curr);

				for (int i = 1; i < s.Length; i++)
				{
					if (curr != s[i])
					{
						curr = s[i];

						if (res1.Contains(s[i]))
						{
							if (res1.Count > res2.Count)
							{
								res2.Clear();
								foreach (var item in res1)
								{
									res2.Add(item);
								}
							}
							var tmpCount = list.Count;
							for (int k = 0; k < tmpCount; k++)
							{
								if (list[0] == curr)
								{
									list.RemoveAt(0);
									list.Add(curr);
									break;
								}

								res1.Remove(list[0]);
								list.RemoveAt(0);
							}
						}
						else
						{
							res1.Add(curr);
							list.Add(curr);
						}
					}
					else 
					{
						if (res1.Count > res2.Count)
						{
							res2.Clear();
							foreach (var item in res1)
							{
								res2.Add(item);
							}
						}
						res1.Clear();
						res1.Add(curr);
						list.Clear();
						list.Add(curr);
					}
				}
			}

			return Math.Max(res1.Count, res2.Count);
		}

		private static void TestCase1()
		{
			var input = "abcabcbb";
			var expect = "abc";

			var result = GetResult(input);

			Console.WriteLine(" EXPECTED: " + expect.Length);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase2()
		{
			var input = "bbbbb";
			var expect = "b";

			var result = GetResult(input);

			Console.WriteLine(" EXPECTED: " + expect.Length);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase3()
		{
			var input = "pwwkew";
			var expect = "wke";

			var result = GetResult(input);

			Console.WriteLine(" EXPECTED: " + expect.Length);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase4()
		{
			var input = "dvdf";
			var expect = "vdf";

			var result = GetResult(input);

			Console.WriteLine(" EXPECTED: " + expect.Length);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase5()
		{
			var input = "abcb";
			var expect = "abc";

			var result = GetResult(input);

			Console.WriteLine(" EXPECTED: " + expect.Length);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase6()
		{
			var input = "ohvhjdml";
			var expect = "vhjdml";

			var result = GetResult(input);

			Console.WriteLine(" EXPECTED: " + expect.Length);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase7()
		{
			var input = "jbpnbwwd";
			var expect = "jbpn"; // "pnbw"

			var result = GetResult(input);

			Console.WriteLine(" EXPECTED: " + expect.Length);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase8()
		{
			var input = "yfsrsrpzuya";
			var expect = "srpzuya";

			var result = GetResult(input);

			Console.WriteLine(" EXPECTED: " + expect.Length);
			Console.WriteLine(" RESULT:   " + result);
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

	}
}
