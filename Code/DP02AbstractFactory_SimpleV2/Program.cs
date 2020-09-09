using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP02AbstractFactory_SimpleV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数字");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("请输入第二个数字");
            int b = int.Parse(Console.ReadLine());


            Console.WriteLine("请输入运算符号");
            string op = Console.ReadLine();

            int result = Compute(op, a, b);

            Console.WriteLine("{0}{1}{2}={3}", a, op, b, result);
        }


        public static int Compute(string op, int a, int b)
        {
            int result = 0;
            switch (op)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
