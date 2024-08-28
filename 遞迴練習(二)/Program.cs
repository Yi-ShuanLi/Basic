using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 遞迴練習_二_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var steps = new List<Step>
            {
                new Step { StepOrder = 1, StageName = "MP3V5004GP_6L_14_FH1_01_ASE-KR" },
                new Step { StepOrder = 2, StageName = "MP3V5004GP_1A_14_FC2_01_ASE-KR" },
                new Step { StepOrder = 2, StageName = "MP3V5004GP_1B_14_FC2_01_ASE-KR" },
                new Step { StepOrder = 2, StageName = "MP3V5004GP_6L_14_FC2_01_ASE-KR" },
                new Step { StepOrder = 3, StageName = "MP3V5005GA_1A_14_FC2_01_ASE-KR" },
                new Step { StepOrder = 3, StageName = "MP3V5005GA_1B_14_FC2_01_ASE-KZ" },
                new Step { StepOrder = 3, StageName = "MP3V5005GA_6L_14_FC2_01_ASE-KC" }
            };

            // 按 StepOrder 分组
            var stepGroups = steps.GroupBy(s => s.StepOrder)
                .OrderBy(g => g.Key)
                .Select(g => g.Select(s => s.StageName).ToList())
                .ToList();

            var combinations = GetCombination(stepGroups);
            foreach (var combination in combinations)
            {
                Console.WriteLine(combination);
            }

            var listOfLists = new List<List<String>>
            {
            new List<String> {"A"},
            new List<String> {"B", "C", "D"},
            new List<String> {"E", "F", "G"}
            };
            List<String> results = GetCombination(listOfLists);
            // 打印每个内部列表的内容
            foreach (var innerList in results)
            {
                Console.WriteLine(innerList);
            }


            //MP3V5004GP_6L_14_FH1_01_ASE - KR, MP3V5004GP_1A_14_FC2_01_ASE - KR, MP3V5005GA_1A_14_FC2_01_ASE - KR
            //MP3V5004GP_6L_14_FH1_01_ASE - KR, MP3V5004GP_1A_14_FC2_01_ASE - KR, MP3V5005GA_1B_14_FC2_01_ASE - KZ
            //MP3V5004GP_6L_14_FH1_01_ASE - KR, MP3V5004GP_1A_14_FC2_01_ASE - KR, MP3V5005GA_6L_14_FC2_01_ASE - KC
            //MP3V5004GP_6L_14_FH1_01_ASE - KR, MP3V5004GP_1B_14_FC2_01_ASE - KR, MP3V5005GA_1A_14_FC2_01_ASE - KR
            //MP3V5004GP_6L_14_FH1_01_ASE - KR, MP3V5004GP_1B_14_FC2_01_ASE - KR, MP3V5005GA_1B_14_FC2_01_ASE - KZ
            //MP3V5004GP_6L_14_FH1_01_ASE - KR, MP3V5004GP_1B_14_FC2_01_ASE - KR, MP3V5005GA_6L_14_FC2_01_ASE - KC
            //MP3V5004GP_6L_14_FH1_01_ASE - KR, MP3V5004GP_6L_14_FC2_01_ASE - KR, MP3V5005GA_1A_14_FC2_01_ASE - KR
            //MP3V5004GP_6L_14_FH1_01_ASE - KR, MP3V5004GP_6L_14_FC2_01_ASE - KR, MP3V5005GA_1B_14_FC2_01_ASE - KZ
            //MP3V5004GP_6L_14_FH1_01_ASE - KR, MP3V5004GP_6L_14_FC2_01_ASE - KR, MP3V5005GA_6L_14_FC2_01_ASE - KC


        }
        static List<String> GetCombination(List<List<String>> inputList)
        {
            List<string> result = new List<string>();
            Combination(inputList, "", result);
            return result;
        }
        static void Combination(List<List<String>> inputList, String currentString, List<String> result)
        {
            if (inputList.Count == 0)
            {
                result.Add(currentString);
            }
            else
            {
                for (int i = 0; i < inputList[0].Count; i++)
                {
                    List<List<String>> newInputList = inputList.GetRange(1, inputList.Count - 1);
                    if (newInputList.Count == 0)
                    {
                        Combination(newInputList, currentString + inputList[0][i], result);
                    }
                    else
                    {
                        Combination(newInputList, currentString + inputList[0][i] + ", ", result);
                    }
                }
            }
        }
    }
}
