using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DP05PrototypeV1
{
    static class Program
    {

        static void Main()
        {
            Prototype b1 = new Build();
            b1.Number = 8;
            b1.Address = "南京路";

            Prototype b2 = b1.Clone();
         


            Console.WriteLine(b1);
            Console.WriteLine(b2);

            //System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
            //cn.ConnectionString = "data source=.;database=abc;uid=sa;pwd=sa;";

            //System.Data.SqlClient.SqlConnection cn2 = null;

            //cn2 = ((cn as ICloneable).Clone() as System.Data.SqlClient.SqlConnection);
            //Console.WriteLine(cn2.ConnectionString);

       




        }
    }
    /// <summary>
    /// 原型
    /// </summary>
    public abstract class Prototype
    {
        public int Number { get; set; }
        public string Address { get; set; }

        public abstract Prototype Clone();
        public override string ToString()
        {
            return string.Format("门牌号:{0},地址:{1}", this.Number, this.Address);

        }
    }

    public class Build : Prototype
    {
        public override Prototype Clone()
        {
            Build newinstance = new Build();
            newinstance.Number = this.Number + 1;
            newinstance.Address = this.Address;
            return newinstance; 
        }
    }

}
