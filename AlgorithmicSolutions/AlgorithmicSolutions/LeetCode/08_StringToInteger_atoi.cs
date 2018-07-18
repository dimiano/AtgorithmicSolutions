/*

8. String to Integer (atoi)

Implement atoi which converts a string to an integer.
The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. 
Then, starting from this character, takes an optional initial plus or minus sign followed by 
as many numerical digits as possible, and interprets them as a numerical value.

The string can contain additional characters after those that form the integral number, 
which are ignored and have no effect on the behavior of this function.

If the first sequence of non-whitespace characters in str is not a valid integral number, 
or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

If no valid conversion could be performed, a zero value is returned.

Note:

Only the space character ' ' is considered as whitespace character.
Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. 
If the numerical value is out of the range of representable values, INT_MAX (231 − 1) or INT_MIN (−231) is returned.

Example 1:
Input: "42"
Output: 42

Example 2:
Input: "   -42"
Output: -42

Explanation: The first non-whitespace character is '-', which is the minus sign.
			 Then take as many numerical digits as possible, which gets 42.

Example 3:
Input: "4193 with words"
Output: 4193

Explanation: Conversion stops at digit '3' as the next character is not a numerical digit.

Example 4:
Input: "words and 987"
Output: 0

Explanation: The first non-whitespace character is 'w', which is not a numerical 
			 digit or a +/- sign. Therefore no valid conversion could be performed.

Example 5:
Input: "-91283472332"
Output: -2147483648

Explanation: The number "-91283472332" is out of the range of a 32-bit signed integer.
			 Thefore INT_MIN (−231) is returned.

*/


using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class StringToIntegerAtoi
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
		}

		private static int GetResult(string str)
		{
			if (str.Length == 0)
			{
				return 0;
			}

			var num = new int[10]; // int.MaxValue length = 10 (2 147 483 647)

			for (int i = 0; i < num.Length; i++)
			{
				num[i] = -1;
			}

			var negative = false;
			var digitPresent = false;
			var plusPresent = false;
			var leadZero = false;
			var n = 0;

			for (int i = 0; i < str.Length; i++)
			{
				if (char.IsDigit(str[i]))
				{
					if (str[i] == '0' && !digitPresent) // ignore leading zero
					{
						leadZero = true;
						continue;
					}
					else if (n >= num.Length) // overflow int32
					{
						return negative ? int.MinValue : int.MaxValue;
					}

					num[n] = GetInt(str[i]);
					n++;
					digitPresent = true;
				}
				else if ((str[i] == ' ') && !digitPresent && !plusPresent && !negative && !leadZero)
				{
					continue;
				}
				else
				{
					if (str[i] == '-' && !digitPresent && !plusPresent && !leadZero && !negative)
					{
						negative = true;
					}
					else if (str[i] == '+' && !plusPresent && !negative && !leadZero)
					{
						plusPresent = true;
					}
					else
					{
						break;
					}
				}
			}

			var result = 0;
			var factor = 1;

			for (int i = num.Length - 1; i >= 0; i--)
			{
				if (num[i] == -1)
				{
					continue;
				}

				if (negative)
				{
					result -= num[i] * factor;
				}
				else
				{
					result += num[i] * factor;
				}

				factor *= 10;
			}

			if (n == 10 && num[0] > 2)
			{
				result = negative ? int.MinValue : int.MaxValue;
			}
			else
			{
				if (result < 0 && !negative) // int32 overflow +
				{
					result = int.MaxValue;
				}
				else if (result > 0 && negative) // int32 overflow -
				{
					result = int.MinValue;
				}
			}

			return result;
		}

		private static int GetInt(char ch)
		{
			switch (ch)
			{
				case '0': return 0;
				case '1': return 1;
				case '2': return 2;
				case '3': return 3;
				case '4': return 4;
				case '5': return 5;
				case '6': return 6;
				case '7': return 7;
				case '8': return 8;
				case '9': return 9;
			}

			throw new ArgumentException(nameof(ch));
		}


		private static void TestCase1()
		{
			var input = "24";
			var expect = 24;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = "   -42";
			var expect = -42;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = "4193 with words";
			var expect = 4193;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase4()
		{
			var input = "words and 987";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase5()
		{
			var input = "-91283472332";
			var expect = int.MinValue;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase6()
		{
			var input = "+1";
			var expect = 1;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase7()
		{
			var input = "  0000000000012345678";
			var expect = 12345678;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase8()
		{
			var input = "+-2";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase9()
		{
			var input = "-+1";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase10()
		{
			var input = "   +0 123";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase11()
		{
			var input = "2147483648";
			var expect = 2147483647;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase12()
		{
			var input = "-2147483649";
			var expect = -2147483648;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase13()
		{
			var input = "-6147483648";
			var expect = -2147483648;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase14()
		{
			var input = "20000000000000000000";
			var expect = 2147483647; // int.Max

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase15()
		{
			var input = "0-1";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase16()
		{
			var input = "0  123";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase17()
		{
			var input = " --2";
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
	}
}
