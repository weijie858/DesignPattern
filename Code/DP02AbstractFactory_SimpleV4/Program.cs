using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP02AbstractFactory_SimpleV4
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

            int result;

            //////////////////////////////


            Computer com = null;

          

            switch (op)
            {
                case "+":
                    com = new AddComputer();
                  
                    break;
                case "-":

                      com  = new JianComputer();
                  
                    break;
                case "*":

                      com  = new ChenComputer();
                  
                    break;
                case "/":

                      com  = new ChuComputer();
                 
                    break;
                default:
                    com = new AddComputer();
                    break;
            }
            com.NumberA = a;
            com.NumberB = b;
            result = com.Result;

            //////////////////////////////

            Console.WriteLine("{0}{1}{2}={3}", a, op, b, result);
        }



    }

    /// <summary>
    /// 运算
    /// </summary>
    public abstract class Computer
    {
        protected int _NumberA;

        public int NumberA
        {
            get { return _NumberA; }
            set { _NumberA = value; }
        }

        protected int _NumberB;

        public int NumberB
        {
            get { return _NumberB; }
            set { _NumberB = value; }
        }

        /// <summary>
        /// 子类必须完成的功能:计算结果并返回结果
        /// </summary>
        public abstract int Result
        {
            get;
        }
    }


    public class AddComputer : Computer
    {
        public override int Result
        {
            get
            {
                return base._NumberA + base._NumberB;
            }
        }
    }


    public class JianComputer : Computer
    {
        public override int Result
        {
            get
            {
                return base._NumberA - base._NumberB;
            }
        }
    }

    public class ChenComputer : Computer
    {
        public override int Result
        {
            get
            {
                return base._NumberA * base._NumberB;
            }
        }
    }
    public class ChuComputer : Computer
    {
        public override int Result
        {
            get
            {
                if (base._NumberB == 0)
                {
                    throw new ArgumentException("被除数不能为零");
                }
                return base._NumberA / base._NumberB;
            }
        }
    }


}
