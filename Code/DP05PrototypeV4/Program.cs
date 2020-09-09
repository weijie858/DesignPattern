using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP05PrototypeV4
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Phone phone = new Phone();
            phone.Name = "Palm650";
            phone.Price = 3000;
            phone.TheFactory = new Factory() { FactoryName = "Palm inc." };
            phone.TheFactory.TheManager = new Manager() { Name = "Mike" };
 
            Phone p2 = (phone as ICloneable).Clone() as Phone;

            p2.Price = 2000;
            p2.TheFactory.FactoryName = "Orange";
          p2.TheFactory.TheManager.Name = "jack";
            Console.WriteLine(phone);
            Console.WriteLine(p2);
        }
    }

    public class Phone : ICloneable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Factory TheFactory { get; set; }


        public object Clone()
        {
            var newInstance= base.MemberwiseClone() as Phone;
            newInstance.TheFactory = (this.TheFactory as ICloneable).Clone() as Factory;
            return newInstance;
        }
        public override string ToString()
        {
            return string.Format("手机:{0},价格:{1},厂家:{2}", this.Name, this.Price, this.TheFactory);

        }
    }
    public class Factory:ICloneable
    {
        public string FactoryName { get; set; }
        public Manager TheManager { get; set; }
   
        public override string ToString()
        {
            return string.Format("厂家名:{0},负责人:{1}", this.FactoryName, this.TheManager);
        }

        public object Clone()
        {
             var newFactory =  base.MemberwiseClone() as Factory;
             newFactory.TheManager = (this.TheManager as ICloneable).Clone() as Manager;
           
             return newFactory;
        }
    }


    public class Manager:ICloneable
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }
    }


}
