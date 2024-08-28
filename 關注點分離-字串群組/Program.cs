using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 關注點分離_字串群組
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input: strs = ["eat","tea","tan","ate","nat","bat"]
            //Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

            //第一步:將所有的字串陣列全部轉為數值陣列
            //第二步:建立一個Dictionary, Key為ASCII總和 value為該字串(逗號累加)
            //第三步:跑forEach去將字典中的每一筆資料轉成List 並進行字串切割 塞回去List

            List<string> inputs = new List<string>() { "eat", "tea", "tan", "ate", "nat", "bat" };
            var result = GroupStrings(inputs);
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write("[");
                for (int j = 0; j < result[i].Count; j++)
                {
                    Console.Write(result[i][j]);

                    Console.Write(",");
                }
                Console.WriteLine("]");
            }


            Console.ReadKey();

        }

        public static List<int> CovertListInterger(List<string> strs)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < strs.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < strs[i].Length; j++)
                {
                    sum += strs[i][j];

                }
                list.Add(sum);
            }
            return list;
        }

        public static Dictionary<int, string> keyValuePairs(List<int> asciiKey, List<string> strsString)
        {
            Dictionary<int, string> dicts = new Dictionary<int, string>();
            for (int i = 0; i < strsString.Count; i++)
            {
                int key = asciiKey[i];
                String value = strsString[i].ToString();
                if (dicts.ContainsKey(key))
                {
                    String string1 = dicts[key];
                    dicts[key] = string1 + "," + value;
                }
                else
                {
                    dicts.Add(key, value);
                }
            }
            return dicts;

        }
        public static List<List<string>> TransDictionaryToString(Dictionary<int, string> dic)
        {
            List<List<string>> result = new List<List<string>>();

            foreach (KeyValuePair<int, string> kvp in dic)
            {
                List<string> list = kvp.Value.Split(',').ToList();
                result.Add(list);
            }
            return result;
        }


        public static List<string> StringToList(string input)
        {
            List<string> list = input.Split(',').ToList();
            return list;

        }


        public static List<List<string>> GroupStrings(List<string> strings)
        {
            //var dicts = keyValuePairs(asciis, strings);
            //return TransDictionaryToString(dicts);
            Dictionary<int, string> dicts = new Dictionary<int, string>();
            List<List<string>> results = new List<List<string>>();

            //第一步 將字串陣列轉為ascii陣列
            List<int> asciis = CovertListInterger(strings);
            //第二步 dictionary建檔
            for (int i = 0; i < strings.Count; i++)
            {
                if (dicts.ContainsKey(asciis[i]))
                    dicts[asciis[i]] += strings[i] + ",";
                else
                    dicts.Add(asciis[i], strings[i]);
            }

            //第三步 分組
            foreach (var dict in dicts)
            {
                List<string> result = StringToList(dict.Value);
                results.Add(result);
            }

            return results;
        }
    }
}
