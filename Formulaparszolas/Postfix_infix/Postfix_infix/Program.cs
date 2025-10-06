using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamologep
{
    internal class Program
    {
        static string operátor = "+-*^%!";
        static string egyjegyu_szam = "0123456789";
        static Dictionary<char, int> prioritas = new Dictionary<char, int>
        {
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '%', 2 },
            { '^', 3 },
            { '!', 4 },
        };

        static string Postfix_infix(string posztfix)
        {
            Stack<string> stack = new Stack<string>();
            foreach (char karakter in posztfix)
            {
                if (operátor.Contains(karakter))
                {
                    switch (karakter)
                    {
                        case '+':
                            string egyik = stack.Pop();
                            string masik = stack.Pop();
                            string eredmeny = $"({egyik}+{masik})";
                            stack.Push(eredmeny);
                            break;
                        case '-':
                            stack.Push($"({stack.Pop()}-{stack.Pop()})");
                            break;
                        case '*':
                            stack.Push($"({stack.Pop()}*{stack.Pop()})");
                            break;
                        case '%':
                            stack.Push($"({stack.Pop()}%{stack.Pop()})");
                            break;
                        case '^':
                            stack.Push($"({stack.Pop()}^{stack.Pop()})");
                            break;
                        case '!':
                            stack.Push($"({stack.Pop()}!)");
                            break;
                    }
                }
                else if (egyjegyu_szam.Contains(karakter))
                {
                    stack.Push(karakter.ToString());
                }
                else
                {
                    throw new Exception("Csak szám vagy karakter jó.");
                }
            }
            if (stack.Count > 1)
            {
                throw new Exception("Rossz formulát adtál meg.");
            }
            return stack.Pop();
        }
        static void Main(string[] args)
        {
            bool kilep_e;
            do
            {
                Console.WriteLine("Adj meg kérlek egy formulát posztfix jelölésben! A műveletek +, -, *, %, ^, !");
                string input = Console.ReadLine();
                kilep_e = input == "exit";
                if (!kilep_e)
                {
                    string eredmeny = Postfix_infix(input);
                    Console.WriteLine($"infix forma: {eredmeny}");
                }
            } while (!kilep_e);
        }
    }
}
