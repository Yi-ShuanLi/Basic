using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0605滑塊作業
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hw1: 給予一個任意數列，找出任意組合中 最大總和是多少
            //int[] inputNums = { 7, 6, 2, 9, 5, 4 };
            //int result = FindMaxTotal2(inputNums, 3);
            //Console.WriteLine(result);
            //Console.ReadKey();

            //Hw2: 找出最長的不連續字串 輸出個數以及內容
            //Example 1:
            //Input: s = "abcdabcbb"
            //Output: 4
            //Explanation: The answer is "abcd", with the length of 3.
            //Example 2:

            //Input: s = "bbbbb"
            //Output: 1
            //Explanation: The answer is "b", with the length of 1.
            //Example 3:

            //Input: s = "pwwkew"
            //Output: 3
            //Explanation: The answer is "wke", with the length of 3.
            //Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

            //string input = "xyzzz";
            //int num = input.IndexOf("xyz");
            //Console.WriteLine(input.Substring(3));
            String input1 = "abcdabcbb";
            String input2 = "bbbbb";
            String input3 = "pwwkew";
            String input4 = "babad";
            String input5 = "cbbd";
            //Console.WriteLine(ContinuousAndNonRepeating1(input1));
            //Console.WriteLine(ContinuousAndNonRepeating1(input2));
            //Console.WriteLine(ContinuousAndNonRepeating1(input3));
            Console.WriteLine(GetPalindromicString(input4));
            Console.WriteLine(GetPalindromicString(input5));
            Console.ReadKey();


            //快樂數
            //Console.WriteLine("請輸入數字：");
            //String stringNum = Console.ReadLine();
            //Console.WriteLine(isHappy(stringNum));
            //int count = 0;
            //for (int i = 1; i <= 100; i++)
            //{
            //    if (isHappy(i.ToString()) == true)
            //    {
            //        count++;
            //        Console.WriteLine($"第 {count} 個快樂數，數值：{i}");
            //        //Console.WriteLine(isHappy(i.ToString()));
            //    }
            //}

        }

        static int FindMaxTotal(int[] numbers, int block)
        {
            int max = 0;
            for (int i = 0; i < numbers.Length; i++)
            {

                if (i + block > numbers.Length)
                {
                    break;
                }
                // LINQ

                max = (numbers.Skip(i).Take(block).Sum() > max) ? numbers.Skip(i).Take(block).Sum() : max;

            }
            return max;

        }
        static int FindMaxTotal2(int[] numbers, int block)
        {
            int max_sum = 0;
            for (int i = 0; i < block; i++)
            {
                max_sum += numbers[i];
            }
            int window_sum = max_sum;
            for (int i = block; i < numbers.Length; i++)
            {
                window_sum += numbers[i] - numbers[i - block];
                max_sum = Math.Max(max_sum, window_sum);
            }
            return max_sum;

        }
        static String ContinuousAndNonRepeating(String input)
        {
            List<char> result1 = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                List<char> result2 = new List<char>();
                int index2 = i;
                if (!(result1.Contains(input[i])))
                {
                    result1.Add(input[i]);
                }
                else
                {
                    if (result1.Count == 1)
                    {
                        continue;
                    }
                    for (int j = 0; j < result1.Count + 1; j++)
                    {
                        if ((index2 + result1.Count) > input.Length)
                        {
                            break;
                        }
                        if (!result2.Contains(input[index2]))
                        {
                            result2.Add(input[index2]);
                            index2++;
                        }
                        if (result2.Contains(input[index2]))
                        {
                            break;
                        }
                        if (result2.Count > result1.Count)
                        {
                            result1.Clear();
                        }
                    }
                }




            }
            String str = String.Join("", result1);

            return $"Explanation: The answer is {str} , with the length of {result1.Count}";

        }
        static String ContinuousAndNonRepeating1(String result)
        {
            string maxString = "";
            //while (true)
            //{

            //    string target = GetNonRepeatString(result);
            //    if (target.Length > maxString.Length)
            //        maxString = target;
            //    int index = result.IndexOf(target);
            //    int nextIndex = index + target.Length;

            //    if (nextIndex == result.Length)
            //    {
            //        break;
            //    }

            //    result = result.Substring(nextIndex);
            //}

            HashSet<char> result2 = new HashSet<char>();
            int maxcount = 0;

            for (int i = 0; i < result.Length; i++)
            {
                if (!result2.Add(result[i]))
                {
                    if (result2.Count() > maxcount)
                    {
                        maxcount = result2.Count();
                        maxString = result2.Select(x => x.ToString()).ToString();
                    }
                    result2.Clear();
                }
            }


            return maxString;

        }
        static String GetNonRepeatString(String input)
        {
            List<char> result = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {

                if (!(result.Contains(input[i])))
                {
                    result.Add(input[i]);
                }
                else
                {
                    break;
                }
            }
            String str = String.Join("", result);

            return str;

        }
        static bool isHappy(String inputStringNum)
        {
            HashSet<int> resultList = new HashSet<int>();
            String stringTempNum = inputStringNum;
            int sum = 0;
            while (sum != 1)
            {
                List<int> intNum = new List<int>();
                for (int i = 0; i < stringTempNum.Length; i++)
                {
                    intNum.Add((int)Char.GetNumericValue(stringTempNum[i]));
                }
                sum = 0;
                for (int i = 0; i < intNum.Count; i++)
                {
                    sum += intNum[i] * intNum[i];
                }

                if (resultList.Add(sum))
                {
                    stringTempNum = sum.ToString();
                }
                else
                {
                    break;
                }
                //if (!resultList.Contains(sum))
                //{
                //    resultList.Add(sum);
                //    stringTempNum = sum.ToString();
                //}
                //else
                //{
                //    break;
                //}
            }
            if (sum == 1)
            {
                return true;
            }
            return false;

        }

        static String LongestPalindromicSubstring(String input)
        {
            string maxString = "";
            while (true)
            {

                string target = GetNonRepeatString(input);
                if (target.Length > maxString.Length)
                    maxString = target;
                int index = input.IndexOf(target);
                int nextIndex = index + target.Length;

                if (nextIndex == input.Length)
                {
                    break;
                }

                input = input.Substring(nextIndex);
            }


            return maxString;
        }
        private static string GetPalindromicString(String input)
        {
            string resultString = "";
            for (int i = 0; i < input.Length; i++)
            {
                int count = 2;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (IsPalindrome(input.Substring(i, count)))
                    {
                        if (count > resultString.Length)
                        {
                            resultString = input.Substring(i, count);
                        }

                    }
                    count++;
                }
            }
            return resultString;
        }
        private static bool IsPalindrome(string inputString)
        {

            for (int i = 0; i < inputString.Length / 2; i++)
            {
                if (!(inputString[i] == inputString[inputString.Length - 1 - i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
