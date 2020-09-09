using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP22Strategy3rdPart
{
    public class Holidy:DP22StrategyV2.Strategy
    {
        public override void Algorith(ref double currentTotal)
        {
            if (currentTotal>20000)
            {
                Console.WriteLine("送你新马泰七日旅游");
            }
            else
            {
                if (currentTotal>10000)
                {
                    Console.WriteLine("九寨沟3日旅游");
                }
            }
        }
    }

    public class Discount : DP22StrategyV2.Strategy
    {
        public override void Algorith(ref double currentTotal)
        {
            currentTotal *= 0.5;
        }
    }

}
