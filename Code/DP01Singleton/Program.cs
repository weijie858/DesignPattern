using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DP01Singleton.V1;

namespace DP01Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
            Singleton s3 = Singleton.Instance;

            Compare(s1, s2,s3);

            s1.Show();
            s2.Show();
            s3.Show();

            NonSingleton n1 = new NonSingleton();
            NonSingleton n2 = n1;
            NonSingleton n3 = new NonSingleton();
            Compare(n1, n2,n3);

            V4.Singleton.Hello();
           V4.Singleton ss = V4.Singleton.Instance;
            V5.Singleton.Hello();
            V5.Singleton sss = V5.Singleton.Instance;
            V5.Singleton sss2 = V5.Singleton.Instance;


        }
        public static void Compare(object n1, object n2,object n3)
        {

            Console.WriteLine(n1 == n2);
            Console.WriteLine(object.Equals(n2, n3));
            Console.WriteLine(object.ReferenceEquals(n2, n3));
        }
    }
}
