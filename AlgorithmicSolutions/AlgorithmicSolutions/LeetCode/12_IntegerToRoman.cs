

/*

12. Integer to Roman

Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000

For example, two is written as II in Roman numeral, just two one's added together.
Twelve is written as, XII, which is simply X + II.
The number twenty seven is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right.
However, the numeral for four is not IIII. Instead, the number four is written as IV.
Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX.
There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given an integer, convert it to a roman numeral. Input is guaranteed to be within the range from 1 to 3999.

Example 1:
Input: 3
Output: "III"

Example 2:
Input: 4
Output: "IV"

Example 3:
Input: 9
Output: "IX"

Example 4:
Input: 58
Output: "LVIII"

Explanation: C = 100, L = 50, XXX = 30 and III = 3.

Example 5:
Input: 1994
Output: "MCMXCIV"

Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

 */


using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class IntegerToRoman
	{
		public static void Test()
		{
			Console.WriteLine("12. Integer to Roman");
			Console.WriteLine();

			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
			TestCase5();
			TestCase6();
			TestCase7();
		}

		private static string GetResult(int num)
		{
			var roms = new Dictionary<int, string>() {
				{ 1, "I"}, { 4, "IV"}, { 5, "V" }, { 9, "IX" },
				{ 10, "X" }, { 40, "XL" }, { 50, "L" }, { 90, "XC" },
				{ 100, "C" }, { 400, "CD" }, { 500, "D" }, { 900, "CM" }, { 1000, "M" } };

			var i = 0;
			const int factor = 10;
			var multiplyer = 1;
			var result = new StringBuilder();

			while (num >= 0)
			{
				i = num % factor;
				i *= multiplyer;

				if (i > 0)
				{
					if (roms.ContainsKey(i))
					{
						result.Insert(0, roms[i]);
					}
					else
					{
						var nums = ParseNums(i, multiplyer, roms);
						result.Insert(0, nums);
					}
				}

				if (num < factor)
				{
					break;
				}

				num /= factor;
				multiplyer *= factor;
			}
			
			return result.ToString();
		}

		private static string ParseNums(int num, int multiplyer, Dictionary<int, string> roms)
		{
			switch (multiplyer)
			{
				case var i when i < 10:
					return GetStringRomans(num, 1, "I", roms); // -1
				case var i when i < 100:
					return GetStringRomans(num, 10, "X", roms);  // -10
				case var i when i < 1000:
					return GetStringRomans(num, 100, "C", roms);  // -100
				case var i when i == 1000:
					return GetStringRomans(num, 1000, "M", roms);  // -1000
			}

			return string.Empty;
		}

		private static string GetStringRomans(int num, int substruct, string romNum, Dictionary<int, string> roms)
		{
			var sb = new StringBuilder();

			while (num > 0)
			{
				num -= substruct;
				sb.Insert(0, romNum);
				if (roms.ContainsKey(num))
				{
					sb.Insert(0, roms[num]);
					break;
				}
			}

			return sb.ToString();
		}


		private static void TestCase1()
		{
			var input = 3;
			var expect = "III";

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = 4;
			var expect = "IV";

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = 9;
			var expect = "IX";

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase4()
		{
			var input = 58;
			var expect = "LVIII";

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase5()
		{
			var input = 1994;
			var expect = "MCMXCIV";

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase6()
		{
			var input = 1985;
			var expect = "MCMLXXXV";

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase7()
		{
			var input = 2018;
			var expect = "MMXVIII";

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
	}
}
