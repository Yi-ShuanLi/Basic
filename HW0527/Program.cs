using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW0527
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region HW1: Twosum
            //HW1: Twosum
            //int[] numbers = { 11, 15, 2, 7 };
            //int target = 9;
            //int[] ansArray = TwoSum(numbers, target);
            //PrintArray(ansArray);
            //int[] ansArray = TwoSum2(numbers, target);
            //PrintArray(ansArray);

            #endregion


            //Hw2:股價最大收益判斷
            //int[] numbers = { 7, 1, 5, 3, 6, 4 };
            //int[] maxGap = MaxOrMinProfit2(true, numbers);
            //PrintArray(maxGap);
            //int[] minGap = MaxOrMinProfit2(false, numbers);
            //PrintArray(minGap);

            //int[] numbers2 = { 7, 6, 4, 3, 1 };
            //int[] maxGap = MaxOrMinProfit(true, numbers);
            //Console.WriteLine("最佳的投資index");
            //PrintArray(maxGap);
            //int[] minGap = MaxOrMinProfit(false, numbers);
            //Console.WriteLine("最糟的投資index");
            //PrintArray(minGap);
            //Console.WriteLine("number2是否為熊市?1為牛市，0為熊市");
            //Console.WriteLine(IsUpperArray(numbers2));





            //string input = "AABBCCCCCD";
            //Dictionary<string, int> dicts = new Dictionary<string, int>();

            //for (int i = 0; i < input.Length; i++)
            //{
            //    string word = input[i].ToString();
            //    if (dicts.ContainsKey(word))
            //    {
            //        dicts[word] = dicts[word] + 1;

            //    }
            //    else
            //    {
            //        dicts.Add(word, 1);
            //    }
            //}



            //String keyName = "";
            //int max = 0;
            //foreach (var dict in dicts)
            //{
            //    if (dict.Value > max)
            //    {
            //        max = dict.Value;
            //        keyName = dict.Key;
            //    }
            //}
            //Console.WriteLine(keyName);
            //Console.WriteLine(max);

            // $1,987,654,321
            //string input = "1987654321";
            //int count = 0;
            //string result = "";
            //// 1,987,654,321

            //// 1,987,654,321
            //// 7 4 1
            //for (int i = input.Length - 1; i >= 0; i--)
            //{
            //    count++;
            //    if (count % 3 == 0)
            //    {
            //        input = input.Insert(i, ",");

            //    }

            //}

            //foreach (char c in result.Reverse())
            //{
            //    Console.Write(c);
            //}
            //Console.WriteLine(input);

            #region 透過Dictionary 搭配股價判斷的 一層迴圈技巧 來解決這 TwoSum 問題


            int[] numbers = { 11, 15, 2, 7 };
            int target = 9;
            int[] ansArray = TwoSum2(numbers, target);
            PrintArray(ansArray);




            #endregion


            #region 字串迴文 => 由左至右 & 由右至左 結果均相同 => 透過關注點分離來解決這道題

            //String input = "A man, a plan, a canal: Panama";
            //String input2 = "race a car";
            //Console.WriteLine(IsPalindrome(TransformString(input)));
            //Console.WriteLine(IsPalindrome(TransformString(input2)));





            #endregion
            //s="A man, a plan, a canal: Panama" => true
            //s="race a car"



        }
        /// <summary>
        /// 根據傳入的陣列以及 target的參數，若陣列內的任兩個數字相加能與target相同，則輸出那兩個數字的index
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns>回傳能與target相加的兩個數字的索引位置</returns>
        private static int[] TwoSum(int[] numbers, int target)
        {
            int[] indexArray = new int[2];
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if ((numbers[i] + numbers[j]) == target)
                    {
                        indexArray[0] = i;
                        indexArray[1] = j;
                    }
                }

            }
            return indexArray;
        }
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

        }
        /// <summary>
        /// 根據傳入的陣列，根據股票買低賣高的條件，找出最大的收入是多少
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>最大的收入是多少</returns>
        /// 
        private static int IsUpperArray(int[] array)
        {

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[i - 1])
                {
                    return 1;
                }

            }
            return 0;

        }
        private static int[] MaxOrMinProfit(bool isMaxProfit, int[] numbers)
        {
            int[] indexArray = new int[2];
            int gap = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (isMaxProfit)
                    {
                        if ((numbers[j] - numbers[i]) > gap)

                        {
                            gap = numbers[j] - numbers[i];
                            indexArray[0] = i;
                            indexArray[1] = j;
                        }

                    }
                    else
                    {
                        if ((numbers[j] - numbers[i]) < gap)
                        {
                            gap = numbers[j] - numbers[i];
                            indexArray[0] = i;
                            indexArray[1] = j;
                        }
                    }

                }

            }
            return indexArray;
        }

        private static int[] MaxOrMinProfit2(bool isMaxProfit, int[] numbers)
        {
            int[] indexArray = new int[2];
            int gap = 0;
            int minPrice = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (isMaxProfit)
                {
                    if (numbers[i] < minPrice)
                    {
                        minPrice = numbers[i];
                        indexArray[0] = i;
                    }
                    else if (numbers[i] - minPrice > gap)
                    {
                        gap = numbers[i] - minPrice;
                        indexArray[1] = i;
                    }

                }
                else
                {
                    if (numbers[i] < minPrice)
                    {
                        minPrice = numbers[i];
                        indexArray[1] = i;
                    }
                    else if (numbers[i] - minPrice < gap)
                    {
                        gap = numbers[i] - minPrice;
                        indexArray[0] = i;
                    }
                }

            }
            return indexArray;
        }

        private static int[] TwoSum2(int[] numbers, int target)
        {
            int[] twoSumArray = new int[2];
            Dictionary<int, int> dicts = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int keyIndex = i;
                int valueTargetGap = target - numbers[i];

                if (dicts.ContainsValue(numbers[i]))
                {
                    twoSumArray[0] = dicts.First(d => d.Value == numbers[i]).Key;
                    twoSumArray[1] = i;

                }
                else
                {
                    dicts.Add(keyIndex, valueTargetGap);
                }


            }
            return twoSumArray;
        }

        private static String TransformString(string inputString)
        {
            String TransformString = Regex.Replace(inputString.ToLower(), "[^a-z]", "");
            return TransformString;
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
