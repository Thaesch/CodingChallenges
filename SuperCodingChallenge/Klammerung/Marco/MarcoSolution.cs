using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klammerung.Marco
{
    public class MarcoSolution : IProcessable<string, string>
    {
        private Dictionary<char, int> operatorPrecedence = new Dictionary<char, int>();
        public MarcoSolution()
        {
            operatorPrecedence.Add(')',1);
            operatorPrecedence.Add('!',2);
            operatorPrecedence.Add('*',3);
            operatorPrecedence.Add('^',4);
            operatorPrecedence.Add('+',4);
            operatorPrecedence.Add('>',5);
            operatorPrecedence.Add('=',5);
        }
        
        public string Process(string input)
        {
            Console.WriteLine("In: " + input);
            string tmp = input;
            int bracketsOpen = 0;

            tmp = input.Replace("AND", "*");
            tmp = tmp.Replace("OR", "+");
            tmp = tmp.Replace("=>", ">");
            tmp = tmp.Replace("<=>", "=");
            tmp = tmp.Replace("XOR", "^");

            Stack<char> opStack = new Stack<char>();
            string output = "";
            for (int i = tmp.Length -1; i >= 0; i--)
            {
                if (tmp[i] == ' ')
                {
                    continue;
                }

                if (tmp[i] == '+' || tmp[i] == '!' || tmp[i] == '*')
                {
                    char opStackHead = opStack.Peek();
                    while (opStack.Count > 1 && !HasGreaterOrEqualPrecedence(tmp[i], opStackHead))
                    {
                        output += opStack.Pop();
                        opStackHead = opStack.Peek();
                    }
                    opStack.Push(tmp[i]);
                }
                else if (tmp[i] == ')')
                {
                    opStack.Push(tmp[i]);
                }
                else if (tmp[i] == '(')
                {
                    char elem = ' ';
                    do
                    {
                        elem = opStack.Pop();
                        output += elem;
                    } while (elem != ')');
                    opStack.Push(tmp[i]);
                }
                else
                {
                    output += tmp[i];
                }
            }

            while (opStack.Count > 0)
            {
                output += opStack.Pop();
            }

            char[] outArray = output.ToCharArray();
            Array.Reverse(outArray);
            output = new string(outArray);
            Console.WriteLine("Output: " + output);
            // while (tmp != null)
            // {
            //     if (tmp.Trim().StartsWith("NOT"))
            //     {
            //         //Handle NOT
            //     }
            //     else if (tmp.Trim().StartsWith("("))
            //     {
            //         //Handle (
            //     }
            //     else
            //     {
            //         //Handle Variables
            //     }
            //     Console.Write(tmp[i++]);
            // }

            return null;
        }

        private bool HasGreaterOrEqualPrecedence(char check, char stackHead)
        {
            return operatorPrecedence[check] <= operatorPrecedence[stackHead];
        }
    }
}
