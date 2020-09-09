using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DP22StrategyV2;

namespace DP22StrategyDLL
{

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
            if (currentTotal >= 300)
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

}
