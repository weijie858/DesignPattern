using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP05PrototypeV3
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new Phone();
            phone.Name = "Palm650";
            phone.Price = 3000;
            phone.TheFactory = new Factory() { FactoryName = "Palm inc." };

            Phone p2 = (phone as ICloneable).Clone() as Phone;

            p2.Price = 2000;
            p2.TheFactory.FactoryName = "Orange";
            Console.WriteLine(phone);
            Console.WriteLine(p2);
        }
    }

    public class Phone:ICloneable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Factory TheFactory { get; set; }


        public object Clone()
        {
            return base.MemberwiseClone();
        }
        public override string ToString()
        {
            return string.Format("手机:{0},价格:{1},厂家:{2}", this.Name, this.Price, this.TheFactory);

        }
    }
    public class Factory
    {
        public string FactoryName { get; set; }
        public override string ToString()
        {
            return this.FactoryName;
        }
    }

}
