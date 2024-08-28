using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 猜數字幾A幾B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //洗牌法
            //HW: 電腦會產生一組任意四個不重複的數字， 玩家同時也要去猜四個不重複的數字是多少(若輸入的數字含有重複 則要求重新輸入)，若數字相同且位置相同 則輸出A 若數字相同但位置不同 則輸出B
            //直到4A 完全答對遊戲才結束，否則一直讓玩家猜下去

            #region 巢狀迴圈產生答案

            for (int k = 0; k < 20; k++)
            {
                int[] answers = new int[4];
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

                for (int i = 0; i < 4; i++)
                {
                    Console.Write(answers[i]);
                }
                Console.WriteLine();

            }






            #endregion

            #region 洗牌法
            //int[] ansArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Random random = new Random();
            //Dictionary<char, int> dicts = new Dictionary<char, int>();
            //for (int i = 0; i < ansArray.Length; i++)
            //{
            //    int changeIndex = random.Next(0, 10);
            //    int tempNum = ansArray[i];
            //    ansArray[i] = ansArray[changeIndex];
            //    ansArray[changeIndex] = tempNum;
            //}
            #endregion



            //while (true)
            //{
            //    Console.Write("請輸入不重複的四個0-9數值：");
            //    int.TryParse(Console.ReadLine(), out int userInputNumber);
            //    if (userInputNumber > 9999)
            //    {
            //        Console.WriteLine("輸入格式錯誤!");
            //        continue;
            //    }
            //    int[] userInputArray = new int[4];
            //    Console.Write("答案是：");
            //    for (int i = 0; i < userInputArray.Length; i++)
            //    {
            //        Console.Write(ansArray[i]);
            //    }
            //    Console.WriteLine();
            //    for (int i = 0; i < userInputArray.Length; i++)
            //    {
            //        userInputArray[i] = userInputNumber / (int)Math.Pow(10, (userInputArray.Length - i - 1));
            //        userInputNumber -= userInputArray[i] * (int)Math.Pow(10, (userInputArray.Length - i - 1));
            //    }

            //    dicts.Clear();
            //    dicts.Add('A', 0);
            //    dicts.Add('B', 0);
            //    for (int i = 0; i < userInputArray.Length; i++)
            //    {
            //        if (ansArray[i] == userInputArray[i])
            //        {
            //            dicts['A']++;
            //            continue;
            //        }
            //        if (Array.IndexOf(ansArray, userInputArray[i]) < 4)
            //        {
            //            dicts['B']++;
            //            continue;
            //        }
            //    }
            //    Console.Write("結果：");
            //    foreach (KeyValuePair<char, int> kvp in dicts)
            //    {
            //        Console.Write("{1}{0}", kvp.Key, kvp.Value);
            //    }
            //    Console.WriteLine();
            //    if (dicts['A'] == 4)
            //    {
            //        Console.WriteLine("請問要繼續嗎?要離開的話請輸入N：");
            //        if (Console.ReadLine() == "N")
            //        {
            //            break;
            //        }
            //        for (int i = 0; i < ansArray.Length; i++)
            //        {
            //            int changeIndex = random.Next(0, 10);
            //            int tempNum = ansArray[i];
            //            ansArray[i] = ansArray[changeIndex];
            //            ansArray[changeIndex] = tempNum;
            //        }
            //        dicts.Clear();
            //    }
            //}

            Console.ReadKey();


        }
    }
}
