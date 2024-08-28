using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 物件容器介紹
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 已知項目總數 & 項目內容
            //int[] nums = { 1, 2, 3, 4, 5 };

            //// 已知項目總數 但 不知道項目內容
            //int[] numbers = new int[5];

            // 4*3 nubers.length
            //int[,] numbers = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            //Console.WriteLine(numbers.GetLength(1));
            //for (int i = 0; i < numbers.GetLength(0); i++)
            //{
            //    for (int j = 0; j < numbers.GetLength(1); j++)
            //    {
            //        Console.WriteLine(numbers[i, j]);
            //    }
            //}
            //for(int i=0;i<numbers.)

            // 讓使用者自行輸入學生個數 以及有多少考科
            // 並記錄每一位學生的考科成績，輸出學生群中的 總分以及平均
            Console.WriteLine("請輸入學生人數：");
            int.TryParse(Console.ReadLine(), out int studentNum);
            Console.WriteLine("請輸入考科數量：");
            int.TryParse(Console.ReadLine(), out int testNum);
            int[,] scores = new int[studentNum, testNum];
            for (int i = 0; i < studentNum; i++)
            {
                for (int j = 0; j < testNum; j++)
                {
                    Console.WriteLine("請輸入第" + (i + 1) + "位同學成績，test" + (j + 1) + "成績：");
                    int.TryParse(Console.ReadLine(), out int score);
                    scores[i, j] = score;
                }

            }
            int sum = 0;
            for (int i = 0; i < studentNum; i++)
            {
                sum = 0;
                for (int j = 0; j < testNum; j++)
                {
                    sum += scores[i, j];
                }
                Console.WriteLine("第" + (i + 1) + "位同學成績總分：" + sum + "平均：" + sum / testNum);


            }
            Console.ReadKey();
        }
    }
}
