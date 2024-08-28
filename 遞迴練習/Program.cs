using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 遞迴練習
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hw1: 用遞迴方式 輸出1-100的費式數列
            //Hw2: 使用者自行輸入一個數字，找出該數字下的費式數列 
            //Hw3: 研究 河內塔
            //List<int> result = printFibonacci(100);
            //foreach (int i in result)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(SumOneToAny(10));

            //FibonacciNumberByMaxNum(100);
            //Console.WriteLine();
            //Console.WriteLine(FibonacciRecursionByCount(11));
            //TowerOfHanoi(2, 'A', 'C', 'B');
            //Console.WriteLine("請輸入字串：");
            //String inputString = Console.ReadLine();


            //給定任何n個不重複的字元，並找出所有的排列組合
            //例如：  輸入 a, b, c
            //輸出：
            //abc
            //acb
            //bac
            //bca
            //cba
            //cab
            //Console.WriteLine("Enter a string to generate permutations:");
            //string input = Console.ReadLine();

            //Console.WriteLine($"All permutations of \"{input}\" are:");
            //GeneratePermutations(input.ToCharArray(), 0, input.Length - 1);
            //PermutationByTeacherCode();

            string input = "abc";
            List<string> permutations = GetPermutations(input);

            foreach (string permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }
        static List<int> printFibonacci(int maxInputNum)
        {
            List<int> result = new List<int>();
            result.Add(1);
            result.Add(1);

            int index = result.Count();
            while (true)
            {
                int firstNum = result[index - 2];
                int secondNum = result[index - 1];
                int thirdNum = firstNum + secondNum;
                if (thirdNum > maxInputNum)
                {
                    break;
                }
                result.Add(thirdNum);
                index++;
            }


            return result;
        }
        static int SumOneToAny(int maxNum)
        {
            if (maxNum == 1)
            {
                return 1;
            }
            return maxNum + SumOneToAny(maxNum - 1);
        }

        static void FibonacciNumberByMaxNum(int inputMaxNum)
        {
            int count = 1;
            while (true)
            {
                int result = FibonacciRecursionByCount(count);
                if (result > inputMaxNum)
                {
                    break;
                }
                Console.Write(result + " ");
                count++;
            }
        }

        static int FibonacciRecursionByCount(int count)
        {
            if (count == 1 || count == 2)
            {
                return 1;
            }
            return FibonacciRecursionByCount(count - 2) + FibonacciRecursionByCount(count - 1);
        }

        static void TowerOfHanoi(int n, char from, char to, char buf)
        {
            if (n == 1)
            {
                Console.WriteLine($"Move No.{n} from {from} to {to}  ");
            }
            else
            {
                TowerOfHanoi(n - 1, from, buf, to);
                Console.WriteLine($"Move No.{n} from {from} to {to} ");
                TowerOfHanoi(n - 1, buf, to, from);
            }

        }

        private static void GeneratePermutations(char[] str, int left, int right)
        {
            if (left == right)
            {
                Console.WriteLine(new string(str));
            }
            else
            {
                for (int i = left; i <= right; i++)
                {
                    Swap(ref str[left], ref str[i]);
                    GeneratePermutations(str, left + 1, right);
                    Swap(ref str[left], ref str[i]); // Backtrack
                }
            }
        }
        private static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
        private static void PermutationByTeacherCode()
        {
            string input = "abcd";
            List<string> result = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                string dropString = input[i].ToString();
                string remainString = input.Remove(i, 1);
                result.Add(dropString + remainString);
                result.Add(dropString + SwapString(remainString));
            }

            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
        }

        static string SwapString(string str)
        {
            char[] input = str.ToCharArray();
            (input[0], input[1]) = (input[1], input[0]);
            return new string(input);
        }




        static List<string> GetPermutations(string input)
        {
            List<string> results = new List<string>();
            Permute(input, "", results);
            return results;
        }

        static void Permute(string input, string current, List<string> results)
        {
            if (input.Length == 0)
            {
                results.Add(current);
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    string newInput = input.Substring(0, i) + input.Substring(i + 1);
                    Permute(newInput, current + input[i], results);
                }
            }
        }

    }

}

