using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP22Strategy
{
    /// <summary>
    /// Strategy
    /// </summary>
    public abstract class Strategy
    {
        /// <summary>
        /// 算法
        /// </summary>
        /// <param name="currentTotal"></param>
        public abstract void Algorith(ref double currentTotal);
    }


    public class Gift : Strategy
    {

        public override void Algorith(ref double currentTotal)
        {
            Console.WriteLine("送一个玩具");
        }
    }

    public class Discount : Strategy
    {

        public override void Algorith(ref double currentTotal)
        {
            currentTotal *= 0.8;
            Console.WriteLine("打8折");
        }
    }

    /// <summary>
    /// 减法(抵扣)
    /// </summary>
    public class Reduce : Strategy
    {

        public override void Algorith(ref double currentTotal)
        {
            if (currentTotal>=300)
            {
                currentTotal -= 100;
                Console.WriteLine("抵扣100元");
            }
            else
            {
                Console.WriteLine("不够抵扣");
            }
        }
    }


    public class Order
    {
        private double _total;
        public Order(double Total)
        {
            this._total = Total;
        }

        private List<Strategy> _strategies = new List<Strategy>();
        public void AddStrategy(Strategy strategy)
        {
            this._strategies.Add(strategy);
        }

        public void UsePromot()
        {
            foreach (var item in this._strategies)
            {
                this.UsePromot(item);
            }
        }

        public  void UsePromot(Strategy strategy)
        {
            strategy.Algorith(ref this._total);
            Console.WriteLine("最终价格:{0}",this._total);

        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(1000);
            Strategy s1 = new Gift();
            Strategy s2 = new Discount();
            Strategy s3 = new Reduce();

            order.AddStrategy(s1);
            order.AddStrategy(s2);
            order.AddStrategy(s3);

            order.UsePromot();

        }
    }
}
