using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP01Singleton.V1
{
    public sealed class Singleton
    {
        static Singleton instance = null;

        public void Show()
        {
            Console.WriteLine(  "instance function");
        }
        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

    public class NonSingleton
    {
    }
}
