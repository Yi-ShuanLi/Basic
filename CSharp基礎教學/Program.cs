
using CSharp基礎教學.Students;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp基礎教學
{
    internal class Program // 只能寫在類別裡面 => 類別是由 欄位 以及方法 所組成的
    {
        static void Main(string[] args) // 程式進入點
        {
            //String a= Console.ReadLine();
            //String b = Console.ReadLine();
            //int sum = int.Parse(a) + int.Parse(b);
            //Console.WriteLine(sum);
            //
            //Console.WriteLine("請輸入第一個值：");
            //String input1= Console.ReadLine();
            //if(int.TryParse(input1,out int number1)) {

            //    Console.WriteLine("請輸入第二個值：");
            //    String input2 = Console.ReadLine();
            //    if (int.TryParse(input2, out int number2))
            //    {
            //        Console.WriteLine(number1+ number2);
            //    }
            //    else
            //    {
            //        Console.WriteLine("請輸入正確的數值格式：");
            //    }
            //}
            //else{
            //    Console.WriteLine("請輸入正確的數值格式：");
            //}


            #region 猜數字-內功心法: 單一職責 + 關注點分離 + 最小知識原則

            //Random rnd = new Random();
            //int answer = rnd.Next(1, 101);

            //int max = 100;
            //int min = 1;

            // 1~100

            // 單一職責 + 關注點分離 + 最小知識原則
            // 75
            // 50 => 50~100
            // 90 => 50~90
            // 80 => 50~80
            // 70 => 70~80



            //while (true)
            //{
            //    Console.WriteLine("請輸入數字：");
            //    int.TryParse(Console.ReadLine(), out int guessNumber);
            //    if (guessNumber > max || guessNumber < min)
            //    {
            //        Console.WriteLine($"看清楚一點!請輸入{min}~{max}區間的數值");
            //        continue;
            //    }

            //    if (guessNumber > answer)
            //    {
            //        max = guessNumber;
            //        Console.WriteLine($"猜小一點!請輸入{min}~{max}區間的數值");
            //        continue;
            //    }
            //    if (guessNumber < answer)
            //    {
            //        min = guessNumber;
            //        Console.WriteLine($"猜大一點!請輸入{min}~{max}區間的數值");
            //        continue;
            //    }
            //    if (guessNumber == answer)
            //    {
            //        Console.WriteLine("恭喜猜中!");
            //        break;
            //    }
            //}

            #endregion


            #region random種子知識+畫三角型
            //for (int i = 0; i < 20; i++)
            //{
            //    Random rnd = new Random(new Student().GetHashCode());

            //    int number = rnd.Next(1, 11);
            //    Console.WriteLine(number);

            //}


            //Student student = new Student();
            //Student student2 = student;

            //Console.WriteLine(student.GetHashCode());
            //Console.WriteLine(student2.GetHashCode());



            //*
            //***
            //*****
            //*******
            //*********
            //for (int i = 1; i <= 5; i++)
            //{
            //    for (int j = 0; j < (i * 2) - 1; j++)
            //    {
            //        Console.Write("＊");
            //    }
            //    Console.WriteLine("");
            //}


            //*********
            // *******
            //  *****
            //   ***
            //    *
            //for (int i = 5; i >= 1; i--)
            //{
            //    for (int j = 0; j < (i * 2) - 1; j++)
            //    {
            //        Console.Write("＊");
            //    }
            //    Console.WriteLine("");
            //}

            //    *
            //   ***
            //  *****
            // *******
            //*********
            //for (int i = 1; i <= 5; i++)
            //{
            //    for (int k = 4; k >= i; k--)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int j = 0; j < (i * 2) - 1; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine("");
            //}

            //*********
            // *******
            //  *****
            //   ***
            //    *
            //for (int i = 5; i >= 1; i--)
            //{
            //    for (int k = 0; k < 5 - i; k++)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int j = 0; j < (i * 2) - 1; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine("");
            //}

            #endregion

            //HW1:讓使用者自行輸入一個數字，判斷該數字是否為質數
            //Hw2:輸出從1-100內的所有質數

            #region HW1:讓使用者自行輸入一個數字，判斷該數字是否為質數
            Boolean isContinue = false;
            while (true)
            {
                if (isContinue)
                {
                    Console.WriteLine("請問要繼續嗎?要離開的話請輸入N：");
                    if (Console.ReadLine() == "N")
                    {
                        break;
                    }
                }
                Console.WriteLine("請輸入數值：");
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine("請輸入數值格式!");
                    continue;
                }
                bool ans = CheckIsPrimeNumber(num);
                if (ans)
                {
                    isContinue = true;
                    Console.WriteLine("是值數!");
                }
                else
                {
                    isContinue = true;
                    Console.WriteLine("不是值數!");
                }

            }



            #endregion

            #region 輸出從1-100內的所有質數
            //int count = 0;
            //for (int i = 2; i < 100; i++)
            //{

            //    bool ans = CheckIsPrimeNumber(i);
            //    if (ans)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            #endregion

            #region FIZZBUZZ
            // 請輸出1-100內的所有數字
            // 若該數字可以被3整除 則輸出FIZZ
            // 若該數字可以被5整除 則輸出BUZZ
            // 若該數字可以被7整除 則輸出AIZZ
            // 若該數字可以同時被3和5整除 則輸出FIZZBUZZ
            // 若該數字可以同時被3和7整除 則輸出FIZZAIZZ
            // 若該數字可以同時被5和7整除 則輸出BUZZAIZZ
            // 以上條件若都不成立，則輸出原有的數字
            //for (int i = 1; i <= 100; i++)
            //{
            //    String ans = "";


            //    if (i % 3 == 0)
            //    {
            //        ans += "FIZZ";

            //    }
            //    if (i % 5 == 0)
            //    {
            //        ans += "BUZZ";

            //    }
            //    if (i % 7 == 0)
            //    {
            //        ans += "AIZZ";
            //    }
            //    if (ans == "")
            //    {
            //        Console.WriteLine(i);
            //    }
            //    else
            //    {
            //        Console.WriteLine(ans);
            //    }



            //}

            #endregion







            Console.ReadKey();

        }
        /// <summary>
        /// 檢查是否為值數的方法，根據參數int num，回傳boolean值
        /// </summary>
        /// <param name="num">請放入要求得結果的數值</param>
        /// <returns>boolean，true=是值數，false=不是值數</returns>
        private static bool CheckIsPrimeNumber(int num)
        {
            bool result = true;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    result = false;
                    break;
                }
                if (i >= Math.Sqrt(num))
                {
                    break;
                }
            }
            return result;
        }

        private static void PrintStars(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                for (int k = num; k > i; k--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < (i * 2) - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
            for (int i = (num - 1); i >= 1; i--)
            {
                for (int k = 0; k < num - i; k++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < (i * 2) - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }
    }


}
