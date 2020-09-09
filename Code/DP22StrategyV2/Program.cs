using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP22StrategyV2
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

        public string UsePromot()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this._strategies)
            {
                sb.Append (this.UsePromot(item));
            }
            return sb.ToString();
        }

        public string UsePromot(Strategy strategy)
        {
            strategy.Algorith(ref this._total);
            return string.Format("最终价格:{0}\r\n", this._total);

        }
    }

     
}
