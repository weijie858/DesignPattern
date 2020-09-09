using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP01Singleton.V4
{
    public sealed class Singleton
    {
       private static readonly Singleton instance = null;
       static Singleton()
       {
           instance = new Singleton();
       }
        private Singleton()
        {
        }
        public static Singleton Instance
        {
            get
            {  
                return instance;
            }
        }


        public static void Hello()
        {
        }


    }

}
