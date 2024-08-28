using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 關注點分離_HW字串群組
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputs = new List<string>() { "色即是空", "eat", "tea", "tan", "ate", "nat", "bat", "下雨了", "下了雨", "空即是色" };
            //Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

            List<List<string>> results = GroupUpInputString(inputs);
            for (int i = 0; i < results.Count; i++)
            {
                Console.Write("[");
                for (int j = 0; j < results[i].Count; j++)
                {
                    Console.Write(results[i][j]);

                    Console.Write(",");
                }
                Console.WriteLine("]");
            }

            //Console.WriteLine(CheckIsSameString("eat", "tec"));
            Console.ReadKey();

        }

        static bool CheckIsSameString(string input1, string input2)
        {
            if (input1.Count() != input2.Count())
            {
                return false;
            }
            Dictionary<char, int> dicts = new Dictionary<char, int>();
            //先把input1放入 Dictionary ，key是字元，value是出現次數
            for (int i = 0; i < input1.Count(); i++)
            {
                char key = input1[i];
                if (dicts.ContainsKey(key))
                {
                    dicts[key]++;
                }
                else
                {
                    dicts.Add(key, 1);
                }

            }
            //input2跟input1比對，用扣的
            for (int i = 0; i < input2.Count(); i++)
            {
                char key = input2[i];
                if (dicts.ContainsKey(key))
                {
                    dicts[key]--;
                }
                else
                {
                    return false;
                }
            }
            return !(dicts.Values.Any(value => value != 0));

        }
        static List<List<string>> GroupUpInputString(List<string> inputs)
        {
            List<List<string>> results = new List<List<string>>();
            for (int i = 0; i < inputs.Count(); i++)
            {
                List<string> result = new List<string>();
                if (inputs[i] == "")
                {
                    continue;
                }
                result.Add(inputs[i]);
                for (int j = i + 1; j < inputs.Count(); j++)
                {
                    if (inputs[j] == "")
                    {
                        continue;
                    }
                    if (CheckIsSameString(inputs[i], inputs[j]))
                    {
                        result.Add(inputs[j]);
                        inputs[j] = "";
                    }
                }
                inputs[i] = "";
                results.Add(result);
            }
            return results;
        }
        static List<List<string>> GroupUpInputString2(List<string> inputs)
        {
            List<List<string>> results = new List<List<string>>();
            for (int i = 0; i < inputs.Count(); i++)
            {
                List<string> result = new List<string>();
                if (inputs[i] == "")
                {
                    continue;
                }
                result.Add(inputs[i]);
                for (int j = i + 1; j < inputs.Count(); j++)
                {
                    if (inputs[j] == "")
                    {
                        continue;
                    }
                    if (CheckIsSameString(inputs[i], inputs[j]))
                    {
                        result.Add(inputs[j]);
                        inputs[j] = "";
                    }
                }
                inputs[i] = "";
                results.Add(result);
            }
            return results;
        }
    }
}
