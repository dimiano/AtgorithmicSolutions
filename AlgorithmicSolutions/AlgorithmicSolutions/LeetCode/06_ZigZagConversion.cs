/*

6. ZigZag Conversion

The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R

And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);

Example 1:
Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"

Explanation:
P   A   H   N
A P L S I I G
Y   I   R

Example 2:
Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"

Explanation:

P     I    N
A   L S  I G
Y A   H R
P     I

*/

using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class ZigZagConversion
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
		}

		private static string GetResult(string s, int numRows)
		{
			if (numRows < 2)
			{
				return s;
			}

			var result = new char[s.Length];
			var arr = new char[numRows, s.Length];

			var i = 0;
			var n = 0;
			var j = 0;
			var reverse = false;

			while (i < s.Length)
			{
				arr[n, j] = s[i];
				i++;

				if (!reverse)
				{
					n++;
					if (n == numRows)
					{
						if (numRows >= 2)
						{
							n -= 2;
						}
						else
						{
							n--;
						}

						j++;
						reverse = !reverse;
					}
				}
				else
				{
					n--;

					if (n < 0)
					{
						n = 1;
						j++;
						reverse = !reverse;
					}
				}
			}

			var r = 0;
			for (int k = 0; k < numRows; k++)
			{
				for (int m = 0; m < s.Length; m++)
				{
					if (arr[k, m] != '\0')
					{
						result[r] = arr[k, m];
						r++;
					}
				}
			}

			return new string(result);
		}


		private static void TestCase1()
		{
			var input = "PAYPALISHIRING";
			var num = 3;
			var expect = "PAHNAPLSIIGYIR";

			var result = GetResult(input, num);
			
			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = "PAYPALISHIRING";
			var num = 4;
			var expect = "PINALSIGYAHRPI";
			// P    I    N
			// A  L S  I G
			// Y A  H R
			// P    I

			var result = GetResult(input, num);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = "ABC";
			var num = 1;
			var expect = "ABC";

			var result = GetResult(input, num);

			WriteResult(input, expect, result);
		}

		private static void TestCase4()
		{
			var input = "ABC";
			var num = 2;
			var expect = "ACB";
			// A C
			// B  

			var result = GetResult(input, num);

			WriteResult(input, expect, result);
		}
	}
}
