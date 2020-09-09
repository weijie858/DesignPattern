using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP01Singleton.V2
{
    public sealed class Singleton
    {
        static Singleton instance = null;
        private static readonly object padlock = new object();

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }

                return instance;
            }
        }
    }

}
