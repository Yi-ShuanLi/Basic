using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 幾A幾B_函數版
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入猜數字遊戲的數值個數：");
            int.TryParse(Console.ReadLine(), out int num);
            int[] ansArray = GetRandomGessArray(num);
            for (int i = 0; i < ansArray.Length; i++)
            {
                Console.Write(ansArray[i]);
            }
            while (true)
            {
                int[] suerInputArray = UserInputArray(num);
                (int A, int B) = CheckAnser(suerInputArray, ansArray);
                Console.WriteLine($"結果：{A}Ａ {B}Ｂ");
                if (A == num)
                {
                    Console.WriteLine("請問要繼續嗎?要離開的話請輸入N：");
                    if (Console.ReadLine() == "N")
                    {
                        break;
                    }
                    else
                    {
                        ansArray = GetRandomGessArray(num);
                    }
                }
            }
            Console.ReadKey();



        }
        /// <summary>
        /// 產生一組亂數生成且數值不重複的答案，input放答案的數值個數(位數)，每個數值範圍0-9，output int [] array
        /// </summary>
        /// <param name="num">input放答案的數值個數(位數)</param>
        /// <returns> output int [] array </returns>
        static int[] GetRandomGessArray(int num)
        {
            int[] answers = new int[num];
            for (int i = 0; i < 4; i++)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                answers[i] = random.Next(0, 10);
                for (int j = 0; j < i; j++)
                {
                    if (answers[i] == answers[j])
                    {
                        answers[i] = random.Next(0, 10);
                        j = -1;
                    }
                }
            }
            return answers;
        }
        /// <summary>
        /// 根據使用者傳入的 input參數 要求使用者輸入並回傳對等數量的隨機不重複亂數陣列
        /// </summary>
        /// <param name="input">指定陣列回傳的長度</param>
        /// <returns></returns>
        static int[] UserInputArray(int input)
        {
            int[] userInputArray = new int[input];
            while (true)
            {
                Console.WriteLine("請輸入數值：");
                String str = Console.ReadLine();
                if (str.Length != input)
                {
                    Console.WriteLine("輸入格式錯誤!");
                    continue;
                }
                if (!(int.TryParse(str, out int num)))
                {
                    Console.WriteLine("輸入格式錯誤!");
                    continue;
                }

                for (int i = 0; i < userInputArray.Length; i++)
                {
                    userInputArray[i] = num / (int)Math.Pow(10, (userInputArray.Length - i - 1));
                    num -= userInputArray[i] * (int)Math.Pow(10, (userInputArray.Length - i - 1));
                }

                if (CheckRepeatNumber(userInputArray))
                {
                    Console.WriteLine("數值重複了!");
                    continue;
                }
                break;
            }

            return userInputArray;
        }
        /// <summary>
        /// 判斷一個int [] 裡面的數值是否有重複，有重複的話回傳false，沒有重複的話回傳true
        /// </summary>
        /// <param name="array">被判斷的int陣列</param>
        /// <returns>有重複的話回傳false，沒有重複的話回傳true</returns>
        static bool CheckRepeatNumber(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                if (array.Contains(array[i]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 比對兩組陣列，若內容跟index都相等時為A，若內容相等但index位置不同為B，回傳格式為「幾A幾B」
        /// </summary>
        /// <param name="userInputArray">被比對的 int  Array</param>
        /// <param name="anserArray">答案 int Array</param>
        /// <returns>比對結果「幾A幾B」</returns>
        static (int, int) CheckAnser(int[] userInputArray, int[] anserArray)
        {
            int A = 0;
            int B = 0;
            for (int i = 0; i < userInputArray.Length; i++)
            {
                if (anserArray[i] == userInputArray[i])
                {
                    A++;
                    continue;
                }
                if (anserArray.Contains(userInputArray[i]))
                {
                    B++;
                    continue;
                }
            }
            return (A, B);
        }

    }
}
