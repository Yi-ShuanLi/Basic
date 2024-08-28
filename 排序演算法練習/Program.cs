using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序演算法練習
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = { 44, 44, 74, 18, 94, 34, 54, 7, 61, 1 };
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    for (int j = i + 1; j < numbers.Length; j++)
            //    {
            //        if (numbers[j] < numbers[i])
            //        {

            //            (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            //            //int temp = numbers[i];
            //            //numbers[i] = numbers[j];
            //            //numbers[j] = temp;
            //        }
            //    }
            //}

            //Console.WriteLine(findTargetCount(numbers, 7));

            int[] numbers = { 66, 30, 69, 67, 62, 47, 68, 32, 64, 79 };

            RankIntArray(numbers, 0, numbers.Length - 1);







            foreach (int i in numbers)
            {
                Console.Write(i + "   ");
            }
        }
        static int findTargetCount(int[] inputArray, int target)
        {
            int lastIndex = inputArray.Length - 1;
            int firstIndex = 0;
            int count = 0;
            while (true)
            {
                int index = (firstIndex + lastIndex) / 2;
                if (target > inputArray[index])
                {
                    firstIndex = index;
                }
                else
                {
                    lastIndex = index;
                }

                if (target == inputArray[index])
                {
                    count = index;
                    break;
                }

            }
            return count;
        }
        static void RankIntArray(int[] numbers, int startIndex, int endIndex)
        {
            int leftIndex = startIndex;
            int rightIndex = endIndex;
            int target = numbers[leftIndex];
            while (leftIndex != rightIndex)
            {
                while (numbers[rightIndex] > target && leftIndex != rightIndex)
                {
                    rightIndex--;
                }
                if (numbers[rightIndex] < target && leftIndex != rightIndex)
                {
                    (numbers[leftIndex], numbers[rightIndex]) = (numbers[rightIndex], numbers[leftIndex]);
                }
                while (numbers[leftIndex] < target && leftIndex != rightIndex)
                {
                    leftIndex++;
                }
                if (numbers[leftIndex] > target && leftIndex != rightIndex)
                {
                    (numbers[leftIndex], numbers[rightIndex]) = (numbers[rightIndex], numbers[leftIndex]);
                }
            };
            if (startIndex != leftIndex)
            {
                RankIntArray(numbers, startIndex, leftIndex - 1);
            }
            if (rightIndex != endIndex)
            {
                RankIntArray(numbers, rightIndex + 1, endIndex);
            }
        }

    }
}
