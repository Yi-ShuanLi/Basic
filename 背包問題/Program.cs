using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 背包問題
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 背包問題
            //假設有一個背包的負重最多可達8公斤，而希望在背包中裝入負重範圍內可得之總價物品，
            //假設是水果好了，水果的編號、單價與重量如下所示： 
            //0   李子  4KG NT$4500
            //1   蘋果  5KG NT$5700
            //2   橘子  2KG NT$2250
            //3   草莓  1KG NT$1100
            //4   甜瓜  6KG NT$6700

            //Ans: 草莓、橘子與蘋果，而總價為9050元

            //Dictionary<string, int> result = Backpack(20);
            //foreach (var item in result.Keys.ToList())
            //{
            //    Console.WriteLine($"商品{item}，數量{result[item]}");
            //}

            //情境2:潛入珠寶店的小偷帶了一個後背包可以負重20kg，因為空間有限，所以他只能挑選最有價值的寶石裝進背包，
            //讓他可以最大化今晚的獲利，可以看到下表有所有的寶石的價格和庫存，在挑選寶石除了選最貴的之外還要考量到重量的問題，
            //那麼，就開始來選擇要優先帶走那些寶石吧!
            //1000萬x1 + 700萬x1+ 500萬x2 + 100萬x1 = 2800萬

            //Dictionary<string, int> result1 = BackpackDiamond(20);
            //foreach (var item in result1.Keys.ToList())
            //{
            //    Console.WriteLine($"商品{item}，數量{result1[item]}");
            //}

            //Console.WriteLine(BackpackDiamond(20));
            Dictionary<String, int> result = BackpackDiamond(20);

            foreach (string key in result.Keys.ToList())
            {
                Console.WriteLine($"商品名稱：{key}，個數：{result[key]}");
            }


        }
        static Dictionary<string, int> Backpack(int inputKg)
        {
            string[] productName = { "李子", "蘋果", "橘子", "草莓", "甜瓜" };
            int[] productKg = { 4, 5, 2, 1, 6 };
            int[] productPrice = { 4500, 5700, 2250, 1100, 6700 };

            int[] resultTotalQuantity = new int[inputKg + 1];
            int[] resultMaxValue = new int[inputKg + 1];
            int[] firstDeductIndex = new int[inputKg + 1];
            for (int i = 1; i <= inputKg; i++)
            {
                int maxValueByKg = i;
                for (int j = 0; j < productKg.Length; j++)
                {
                    if (i == productKg[j])
                    {
                        resultTotalQuantity[i] = 1;
                        resultMaxValue[i] = productPrice[j];
                        firstDeductIndex[i] = j;
                        break;
                    }
                    if (i > productKg[j])
                    {
                        int temp = i - productKg[j];
                        int newValue = resultMaxValue[temp] + productPrice[j];
                        if (newValue > maxValueByKg)
                        {
                            maxValueByKg = newValue;
                            resultTotalQuantity[i] = resultTotalQuantity[temp] + 1;
                            resultMaxValue[i] = newValue;
                            firstDeductIndex[i] = j;
                        }
                    }
                }
            }
            Console.WriteLine($"總價值為：{resultMaxValue[inputKg]}");
            Console.WriteLine($"總商品數量為：{resultTotalQuantity[inputKg]}");
            Dictionary<string, int> dicts = new Dictionary<string, int>();
            int buyQuantity = resultTotalQuantity[inputKg];
            for (int i = 0; i < buyQuantity; i++)
            {
                int productIndex = firstDeductIndex[inputKg];
                if (dicts.ContainsKey(productName[productIndex]))
                {
                    dicts[productName[productIndex]]++;
                }
                else
                {
                    dicts.Add(productName[productIndex], 1);
                }
                inputKg -= productKg[productIndex];
            }
            return dicts;
        }
        static Dictionary<string, int> BackpackDiamond(int inputKg)
        {
            string[] productName = { "鑽石", "紅寶石", "藍寶石", "祖母綠", "蛋白石" };
            int[] productKg = { 6, 5, 4, 2, 1 };
            int[] productPrice = { 1000, 700, 500, 200, 100 };
            int[] stock = { 1, 1, 2, 3, 5 };

            // 動態規劃陣列
            int[] dpValue = new int[inputKg + 1];
            int[] dpCount = new int[inputKg + 1];
            int[,] usedStock = new int[inputKg + 1, productName.Length];

            for (int i = 0; i <= inputKg; i++)
            {
                for (int j = 0; j < productKg.Length; j++)
                {
                    if (productKg[j] <= i)
                    {
                        int newValue = dpValue[i - productKg[j]] + productPrice[j];
                        if (newValue > dpValue[i] && usedStock[i - productKg[j], j] < stock[j])
                        {
                            dpValue[i] = newValue;
                            dpCount[i] = dpCount[i - productKg[j]] + 1;
                            Array.Copy(usedStock, (i - productKg[j]) * productName.Length, usedStock, i * productName.Length, productName.Length);
                            usedStock[i, j]++;
                        }
                    }
                }
            }

            // 顯示結果
            int maxValue = dpValue[inputKg];
            int totalItems = dpCount[inputKg];

            Console.WriteLine($"總價值為：{maxValue * 10000} 萬");
            Console.WriteLine($"總商品數量為：{totalItems}");

            Dictionary<string, int> resultItems = new Dictionary<string, int>();
            for (int j = 0; j < productName.Length; j++)
            {
                if (usedStock[inputKg, j] > 0)
                {
                    resultItems[productName[j]] = usedStock[inputKg, j];
                }
            }

            foreach (var item in resultItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value} 個");
            }

            return resultItems;
        }


        static Dictionary<String, int> BackpackDiamond1(int inputKg)
        {
            string[] productName = { "鑽石", "紅寶石", "藍寶石", "祖母綠", "蛋白石" };
            int[] productKg = { 6, 5, 4, 2, 1 };
            int[] productPrice = { 1000, 700, 500, 200, 100 };
            int[] stock = { 1, 1, 2, 3, 5 };


            //計算每公斤的價值
            int[] perKgValue = new int[productName.Length];
            for (int i = 0; i < productKg.Length; i++)
            {
                perKgValue[i] = productPrice[i] / productKg[i];
            }

            //依照每公斤的價值把所有資訊排序
            for (int i = 0; i < perKgValue.Length; i++)
            {
                for (int j = i + 1; j < perKgValue.Length; j++)
                {
                    if (perKgValue[i] < perKgValue[j])
                    {
                        int tempIndex = perKgValue[i];
                        perKgValue[i] = perKgValue[j];
                        perKgValue[j] = tempIndex;

                        //
                        String tempName = productName[i];
                        productName[i] = productName[j];
                        productName[j] = tempName;
                        //
                        int tempKg = productKg[i];
                        productKg[i] = productKg[j];
                        productKg[j] = tempKg;

                        //
                        int tempProductPrice = productPrice[i];
                        productPrice[i] = productPrice[j];
                        productPrice[j] = tempProductPrice;

                        //
                        int tempStock = stock[i];
                        stock[i] = stock[j];
                        stock[j] = tempStock;
                    }
                }
            }

            //做成一個kg的list，裡面的內容是每個kg出現的次數
            //=>{6,5,4,4,2,2,2,1,1,1,1,1}
            List<int> list = new List<int>();
            for (int i = 0; i < productKg.Length; i++)
            {
                for (int j = 0; j < stock[i]; j++)
                {
                    list.Add(productKg[i]);
                }
            }

            //回傳結果
            Dictionary<String, int> dict = new Dictionary<String, int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (inputKg - list[i] >= 0)
                {
                    int index = Array.IndexOf(productKg, list[i]);
                    String key = productName[index];
                    if (dict.ContainsKey(key))
                    {
                        dict[key]++;
                    }
                    else
                    {
                        dict.Add(key, 1);
                    }
                    inputKg -= productKg[index];
                }
            }

            return dict;
        }
    }
}
