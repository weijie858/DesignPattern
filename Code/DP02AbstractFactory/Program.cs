using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP02AbstractFactory
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.Run(new Form1());
      

        }
    }


    /// <summary>
    /// 抽象产品A
    /// </summary>
    public abstract class Shoes
    {
    }

    /// <summary>
    /// 抽象的产品B
    /// </summary>
    public abstract class Hat
    {
    }

    /// <summary>
    /// 抽象工厂,负责规定创建产品(多种)
    /// </summary>
    public abstract class SportsShop
    {
        /// <summary>
        /// 创建产品A
        /// </summary>
        /// <returns></returns>
        public abstract Shoes SellShoes();

        /// <summary>
        /// 创建产品B
        /// </summary>
        /// <returns></returns>
        public abstract Hat SellHat();
    }

    /// <summary>
    /// Nike产品A(系列1的产品A)
    /// </summary>
    public class NikeShoes : Shoes
    {
        public override string ToString()
        {
            return "耐克鞋子";
        }
    }

    /// <summary>
    /// Lining产品A(系列2的产品A)
    /// </summary>
    public class LiningShoes : Shoes
    {
        public override string ToString()
        {
            return "李宁鞋子";
        }
    }

    /// <summary>
    /// Nike产品B(系列1的产品B)
    /// </summary>
    public class NikeHat : Hat
    {
        public override string ToString()
        {
            return "耐克帽子";
        }
    }
    /// <summary>
    /// Lining产品B(系列2的产品B)
    /// </summary>
    public class LiningHat : Hat
    {
        public override string ToString()
        {
            return "李宁帽子";
        }
    }

    /// <summary>
    /// 具体的系列1的工厂
    /// </summary>
    public class NikeShop : SportsShop
    {
        public override Shoes SellShoes()
        {
            return new NikeShoes();
        }

        public override Hat SellHat()
        {
            return new NikeHat();
        }
    }
    /// <summary>
    /// 具体的系列2的工厂
    /// </summary>
    public class LiningShop : SportsShop
    {
        public override Shoes SellShoes()
        {
            return new LiningShoes();

        }

        public override Hat SellHat()
        {
            return new LiningHat();
        }
    }

}
