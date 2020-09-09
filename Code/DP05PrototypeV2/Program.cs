using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP05PrototypeV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Build b1 = new Build();
            b1.Number = 8;
            b1.Address = "南京路";
            
            
            Build b2 = (Build)(b1 as ICloneable).Clone();


            Console.WriteLine(b1);
            Console.WriteLine(b2);
        }
    }

    public  class Build:ICloneable
    {
        public int Number { get; set; }
        public string Address { get; set; }
         
        public override string ToString()
        {
            return string.Format("门牌号:{0},地址:{1}", this.Number, this.Address);

        }

        public object Clone()
        {
            //Build newinstance = new Build();
            //newinstance.Number = this.Number + 1;
            //newinstance.Address = this.Address;
            //return newinstance;

            return base.MemberwiseClone();
        }
    }
}
