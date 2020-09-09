using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP01Singleton.V5
{
    public sealed class Singleton
    {
    
      
        private Singleton()
        {
        }
        public static Singleton Instance
        {
            get
            {  
                return Nested.instance;
            }
        }


        public static void Hello()
        {
        }

        private class Nested
        {
            internal static readonly Singleton instance = null;
            static Nested()
            {
                instance = new Singleton();
            }
        }
    }

}
