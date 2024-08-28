using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ref_out_in三兄弟
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // in => 將資料變數設定為 唯獨
            // 1. 若 該變數是在函數內產生的 const 來宣告該變數是唯獨的 (只能經過第一次宣告的初始化)
            // 2. 若 該變數是在函數外(類別內)產生的 readonly 來宣告變數是唯獨的  (只能經過第一次宣告的初始化)
            // 3. 若 該變數是在函數參數上 產生的 in 來宣告該變數是唯獨的 (只能經過第一次宣告的初始化)
            #region 

            //int normal = 20;
            //int ref_int = 10;
            //int out_int;
            //Method_normal(normal);
            //Method_ref(ref ref_int);
            //Method_out(out out_int);

            //Console.WriteLine($"normal的值為{normal}");
            //Console.WriteLine($"ref_int的值為{ref_int}");
            //Console.WriteLine($"out_int的值為{out_int}");
            //Console.WriteLine($"Press any key for continue...{Environment.NewLine}");
            #endregion


            //int number = 0;
            //int.TryParse(Console.ReadLine(), out number);
            IntTryPrase("290", out int number);
            Console.WriteLine(number);

            Console.ReadKey();

        }
        private static bool IntTryPrase(String input, out int number)
        {
            number = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if ((int)input[i] < 48 || (int)input[i] > 57)
                {
                    return false;
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                number = number * 10 + ((int)input[i] - 48);
            }
            return true;
        }





        private static void Method_normal(int normal)
        {
            normal = 999;
        }
        private static void Method_out(out int out_int)
        {
            out_int = 999;
        }
        private static void Method_ref(ref int ref_int)
        {
            ref_int = 999;
        }

    }
}
