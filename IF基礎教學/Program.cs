using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IF基礎教學
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region 比薩判斷練習
            //#region 卡控
            //Boolean isContinue = false;

            //while (true)
            //{
            //    if (isContinue)
            //    {
            //        Console.WriteLine("請問要繼續嗎?要離開的話請輸入N：");
            //        if (Console.ReadLine() == "N")
            //        {
            //            break;
            //        }
            //    }

            //    Console.WriteLine("請輸入溫度：");
            //    int num1 = numberInput();



            //    if (num1 < 120 || num1 > 125)
            //    {
            //        Console.WriteLine("難吃的比薩：");
            //        isContinue = true;
            //        continue;
            //    }

            //    Console.WriteLine("請輸入濕度：");
            //    int num2 = numberInput();


            //    if (num2 < 5 || num2 > 7)
            //    {
            //        Console.WriteLine("難吃的披薩");
            //        isContinue = true;
            //        continue;
            //    }

            //    #endregion

            //    Console.WriteLine("美味的披薩");
            //    isContinue = true;
            //    
            //}
            #endregion




            #region 貸款償還練習
            //string[] answers = { "y", "yes", "n", "no" };

            //Console.WriteLine("請問是否擁有房產？");
            //String haveHouse = Console.ReadLine().ToLower();

            //if (!answers.Contains(haveHouse))
            //{
            //    Console.WriteLine("請輸入有意義文字!");
            //    return;
            //}

            //if (haveHouse[0].ToString() == "y")
            //{
            //    Console.WriteLine("可以償還!");
            //    return;
            //}
            //Console.WriteLine("請問是否結婚？");
            //String haveMarrige = Console.ReadLine().ToLower();
            //if (!answers.Contains(haveMarrige))
            //{
            //    Console.WriteLine("請輸入有意義文字!");
            //    return;
            //}
            //if (haveMarrige[0].ToString() == "y")
            //{
            //    Console.WriteLine("可以償還!");
            //    return;
            //}
            //Console.WriteLine("請問年收入？");

            //if (!int.TryParse(Console.ReadLine(), out int salary))
            //{
            //    Console.WriteLine("請輸入數值格式");
            //    return;

            //}
            //// 三元運算子 => 針對單一變數進行判斷與指派
            //// salary = (條件判斷) ? xxxx : yyyy;
            //salary = (salary < 10000) ? salary * 10000 : salary;

            //if (salary >= 500000)
            //{
            //    Console.WriteLine("可以償還!");
            //    return;
            //}

            //Console.WriteLine("無法償還!");


            #endregion


            //Console.ReadKey();

            #region BMI練習
            while (true)
            {
                Console.WriteLine("請輸入身高(m)：");
                double height = numberDobuleInput();

                Console.WriteLine("請輸入體重(kg)：");
                double weight = numberDobuleInput();

                double bmiNumber = BMI(height, weight);
                String result = ReturnBmiResult(bmiNumber);

                Console.WriteLine(result);
                Console.WriteLine("請問要繼續嗎?要離開的話請輸入N：");
                if (Console.ReadLine() == "N")
                {
                    break;
                }

            }
            #endregion
            Console.ReadKey();

        }

        private static double numberDobuleInput()
        {
            double num = 0;
            while (true)
            {

                if (!double.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("請輸入正確的數值格式!");

                    continue;
                }
                break;
            }
            return num;

        }

        private static int numberInput()
        {
            int num = 0;
            while (true)
            {

                if (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("請輸入正確的數字格式!");

                    continue;
                }
                break;
            }
            return num;

        }
        /// <summary>
        /// 回傳計算後的BMI數值
        /// </summary>
        /// <param name="height">參數1，身高</param>
        /// <param name="weight">參數2，體重</param>
        /// <returns>根據使用者輸入的身高體重，回傳BMI數值</returns>
        private static double BMI(double height, double weight)
        {
            if (height > 3)
            {
                height = Math.Round(height / 100, 3);
            }
            return Math.Round(weight / Math.Pow(height, 2));

        }

        /// <summary>
        /// 回傳BMI，文字判斷結果
        /// </summary>
        /// <param name="bmiNumber">參數：BMI數值</param>
        /// <returns>回傳BMI，文字判斷結果</returns>
        private static String ReturnBmiResult(double bmiNumber)
        {
            String result = "";
            switch (bmiNumber)
            {
                case double n when (n < 18.5):
                    result = "過輕";

                    break;
                case double n when (n >= 18.5 && n < 24):
                    result = "標準";

                    break;
                case double n when (n >= 24 && n < 27):
                    result = "過重";

                    break;
                case double n when (n >= 27 && n < 30):
                    result = "輕度肥胖";

                    break;
                case double n when (n >= 30 && n < 35):
                    result = "中度肥胖";

                    break;
                case double n when (n >= 35):
                    result = "重度肥胖";

                    break;
                default:
                    result = "無法判斷";

                    break;
            }
            return result;
        }
    }
}
