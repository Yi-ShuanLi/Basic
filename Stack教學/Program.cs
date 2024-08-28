using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack教學
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 前序計算
            //string input = "-+2*319";
            //Console.WriteLine(preOrder(input));


            //// 後序計算
            //string input2 = "231*+9-";
            //Console.WriteLine(postOrder(input2));

            //311*+
            //String input3 = "3+1*2-3";
            //Console.WriteLine(infixToPostfi(input3));


            string[] opers = { "[]", "()", "{}", "[()]", "[{()}]", "[{}()]", "{([])}", ")(", ")[", "[{(})]" };


            // 括號比對
            // [] => true
            // () => true
            // {} => true
            // [()] => true
            // [{()}] => true
            // [{}()] => true
            // {([])} => true
            // )( => false
            // )[ => false
            // [{(})] => false
            for (int i = 0; i < opers.Length; i++)
            {
                Console.WriteLine(CheckVaildOpers(opers[i]));
            }
        }

        static bool CheckVaildOpers(string oper)
        {
            Dictionary<char, char> dicts = new Dictionary<char, char>();
            Stack<int> stack = new Stack<int>();
            dicts.Add('(', ')');
            dicts.Add('[', ']');
            dicts.Add('{', '}');
            for (int i = 0; i < oper.Length; i++)
            {
                char keyChar = oper[i];
                if (dicts.ContainsKey(keyChar))
                {
                    stack.Push(dicts[keyChar]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    if (keyChar != stack.Pop())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static int preOrder(String input)
        {
            Stack<int> stack = new Stack<int>();
            int result = 0;
            for (int i = input.Length - 1; i >= 0; i--)
            {

                if (!char.IsDigit(input[i]))
                {
                    int num1 = stack.Pop();
                    int num2 = stack.Pop();

                    switch (input[i])
                    {
                        case '+':
                            result = num1 + num2;
                            break;
                        case '-':
                            result = num1 - num2;
                            break;
                        case '*':
                            result = num1 * num2;
                            break;
                        case '/':
                            result = num1 / num2;
                            break;
                        default:
                            // Handle unexpected operator
                            break;
                    }

                    stack.Push(result);
                }
                else
                {
                    int.TryParse(input[i].ToString(), out int num);
                    stack.Push(num);
                }

            }
            return result;
        }
        static int postOrder(String input)
        {
            Stack<int> stack = new Stack<int>();
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {

                if (!char.IsDigit(input[i]))
                {
                    int num2 = stack.Pop();
                    int num1 = stack.Pop();

                    switch (input[i])
                    {
                        case '+':
                            result = num1 + num2;
                            break;
                        case '-':
                            result = num1 - num2;
                            break;
                        case '*':
                            result = num1 * num2;
                            break;
                        case '/':
                            result = num1 / num2;
                            break;
                        default:
                            // Handle unexpected operator
                            break;
                    }

                    stack.Push(result);
                }
                else
                {
                    int.TryParse(input[i].ToString(), out int num);
                    stack.Push(num);
                }

            }
            return result;
        }

        //從左邊開始讀取中序式

        //看到數值直接輸出

        //遇到符號存入stack

        //讀到最後一個字元時，把stack依序輸出
        static String infixToPostfi(String input)
        {
            Stack<char> stack = new Stack<char>();
            String result = "";
            char lastOper = ' ';
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    result += input[i].ToString();
                }
                else
                {
                    if (!CheckPriority(lastOper, input[i]))
                    {
                        for (int j = stack.Count - 1; j >= 0; j--)
                        {
                            result += stack.Pop();
                        }

                    }
                    stack.Push(input[i]);
                    lastOper = input[i];
                }

            }
            for (int j = stack.Count - 1; j >= 0; j--)
            {
                result += stack.Pop();
            }


            return result;
        }

        static int returnCharsNum(Char input)
        {
            int result = 0;
            switch (input)
            {
                case '+':
                    result = 1;
                    break;
                case '-':
                    result = 1;
                    break;
                case '*':
                    result = 2;
                    break;
                case '/':
                    result = 2;
                    break;

                default:
                    result = 0;
                    break;
            }
            return result;
        }

        static bool CheckPriority(char lastOper, char nowOper)
        {
            int char1 = returnCharsNum(lastOper);
            int char2 = returnCharsNum(nowOper);
            if (char2 > char1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
