using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace HW0617
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //小明有個已經養了三年的小豬撲滿裡面，某天他心血來潮把小豬宰了，想把裡面的零錢(一共29580元)全部拿去銀行換成鈔票，但是他的皮夾沒辦法放入太多的鈔票，希望銀行可以換給他最少數量的鈔票，因此在兌換的時候必須優先兌換面額最大的鈔票
            //幣值有： 1000, 500, 100, 50, 10, 5, 1
            //請問要怎麼換才能最優先換完？

            //int amount = 29580;
            //int[,] moneyArray = { { 1000, 0 }, { 500, 0 }, { 100, 0 }, { 50, 0 }, { 5, 0 }, { 1, 0 } };

            //for (int i = 0; i < moneyArray.GetLength(0); i++)
            //{
            //    moneyArray[i, 1] = amount / moneyArray[i, 0];
            //    amount -= moneyArray[i, 1] * moneyArray[i, 0];
            //}
            //for (int i = 0; i < moneyArray.GetLength(0); i++)
            //{
            //    Console.WriteLine($"面額{moneyArray[i, 0]}元，{moneyArray[i, 1]}個");
            //}


            //Dictionary<int, int> dictionary = new Dictionary<int, int>();
            //dictionary.Add(1000, 0);
            //dictionary.Add(500, 0);
            //dictionary.Add(100, 0);
            //dictionary.Add(50, 0);
            //dictionary.Add(5, 0);
            //dictionary.Add(1, 0);

            //int amount1 = 29580; // 你可以设置为任何整数


            //foreach (int key in dictionary.Keys.ToList())
            //{
            //    dictionary[key] = amount1 / key;
            //    amount1 -= key * dictionary[key];
            //    Console.WriteLine($"面額{key}，{dictionary[key]}個");
            //}

            //Dictionary<int, int> anser = Combination(91);
            //foreach (int key in anser.Keys.ToList())
            //{
            //    Console.WriteLine($"面額：{key}元{anser[key]}個");
            //}

            List<int> coins = new List<int> { 10, 7, 5, 2, 1 };

            //Dictionary<int, int> result = DP(coins, 14);
            ////Console.WriteLine(result);
            //foreach (int key in result.Keys.ToList())
            //{
            //    Console.WriteLine($"面額{key}，個數{result[key]}個");
            //}
            int[] coins2 = { 10, 7, 5, 2, 1 };
            (int, List<int>) result2 = MinCoins(coins2, 14);
            Console.WriteLine($"總個數{result2.Item1}");
            foreach (int key in result2.Item2)
            {
                Console.WriteLine($"{key}");
            }


            Console.ReadKey();
            //寇迪扣扣星球總共有 1 元、2 元、7 元、10 元這四種硬幣，獨眼怪在老家買了一瓶 14 元的飲料，
            //一樣若想拿最少數量的硬幣給店員，那怎麼選會比較好呢？



        }
        static private Dictionary<int, int> Combination(int amount)
        {
            int[] coinArray = { 10, 7, 2, 1 };

            int minValueSum = amount;
            Dictionary<int, int> dicts = new Dictionary<int, int>();
            for (int i = 0; i < coinArray.Length; i++)
            {
                for (int j = i + 1; j < coinArray.Length; j++)
                {
                    int amountTemp = amount;

                    int quantity1 = amountTemp / coinArray[i];
                    amountTemp -= quantity1 * coinArray[i];

                    int quantity2 = amountTemp / coinArray[j];
                    amountTemp -= quantity2 * coinArray[j];
                    if (amountTemp != 0)
                    {
                        continue;
                    }
                    if ((quantity1 + quantity2) < minValueSum)
                    {
                        if (dicts.Count > 0)
                        {
                            dicts.Clear();
                        }

                        minValueSum = quantity1 + quantity2;
                        if (quantity1 > 0)
                        {
                            dicts.Add(coinArray[i], quantity1);
                        }
                        if (quantity2 > 0)
                        {
                            dicts.Add(coinArray[j], quantity2);
                        }

                    }
                }
            }
            return dicts;
        }
        static private int[] rankArrayDesc(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[j] > inputArray[i])
                    {
                        int temp = inputArray[i];
                        inputArray[i] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }



        static (int, List<int>) MinCoins(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            int[] coinsUsed = new int[amount + 1];

            // 初始化 dp 陣列
            for (int i = 0; i <= amount; i++)
            {
                dp[i] = int.MaxValue;
                coinsUsed[i] = -1; // 初始為 -1 表示未使用硬幣
            }
            dp[0] = 0; // 組成0元所需硬幣數量是0

            // 動態規劃計算最少硬幣數量
            for (int i = 1; i <= amount; i++)
            {
                foreach (int coin in coins)
                {
                    if (i - coin >= 0 && dp[i - coin] != int.MaxValue)
                    {
                        if (dp[i] > dp[i - coin] + 1)
                        {
                            dp[i] = dp[i - coin] + 1;
                            coinsUsed[i] = coin;
                        }
                    }
                }
            }

            // 如果 dp[amount] 仍然是 int.MaxValue，表示無法組成該金額
            if (dp[amount] == int.MaxValue)
            {
                return (-1, new List<int>());
            }

            // 反向追蹤硬幣面額
            List<int> resultCoins = new List<int>();
            int currentAmount = amount;
            while (currentAmount > 0)
            {
                int coin = coinsUsed[currentAmount];
                resultCoins.Add(coin);
                currentAmount -= coin;
            }

            return (dp[amount], resultCoins);
        }



        static private Dictionary<int, int> DP(List<int> coinsArray, int amount)
        {

            int[] gap = new int[amount + 1];
            int[] dp = new int[amount + 1];
            dp[0] = 0;
            gap[0] = 0;
            for (int i = 1; i < dp.Length; i++)
            {

                int minQuantity = i;
                for (int j = 0; j < coinsArray.Count; j++)
                {

                    if (i == coinsArray[j])
                    {
                        dp[i] = 1;
                        gap[i] = coinsArray[j];
                        break;
                    }

                    if (i >= coinsArray[j])
                    {
                        int temp = i - coinsArray[j];


                        int newQuantity = dp[temp] + 1;
                        if (newQuantity < minQuantity)
                        {
                            dp[i] = newQuantity;
                            minQuantity = newQuantity;
                            gap[i] = coinsArray[j];

                            //if (i == amount)
                            //{
                            //    Console.WriteLine(minQuantity);
                            //}

                        }
                    }
                }


            }

            Dictionary<int, int> result = new Dictionary<int, int>();
            int minCoinAmount = dp[amount]; // 3
            for (int i = 0; i < minCoinAmount; i++)
            {
                if (result.ContainsKey(gap[amount]))
                {
                    result[gap[amount]]++;
                }
                else
                {
                    result.Add(gap[amount], 1);
                }
                amount -= gap[amount];
            }




            return result;

        }

    }
}
