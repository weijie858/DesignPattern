using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP03Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            House myhouse = null;
            Director director = new Director();
            myhouse = director.BuildHomeHouse();//普通房子
            Console.WriteLine(myhouse);

            House mygoodhouse = null;
            mygoodhouse = director.BuildGoodHouse();//别墅
            Console.WriteLine(mygoodhouse);
        }
    }

    /// <summary>
    /// 产品
    /// </summary>
    public class House
    {

        /// <summary>
        /// 地基
        /// </summary>
        public string Base;
        /// <summary>
        /// 墙体
        /// </summary>
        public string Wall;
        /// <summary>
        /// 屋顶
        /// </summary>
        public string Roof;

        public override string ToString()
        {
            return string.Format("基地:{0}\r\n墙体:{1}\r\n屋顶:{2}", this.Base, this.Wall, this.Roof);
        }
    }

    /// <summary>
    /// 抽象
    /// </summary>
    public abstract class Builder
    {
        public abstract void BuildPart(House house);

    }

    /// <summary>
    /// 普通房子的建筑队-地基
    /// </summary>
    public class RoomBaseBuilder : Builder
    {
        public override void BuildPart(House house)
        {
            house.Base = "普通房子的地基";
        }
    }
    /// <summary>
    /// 普通房子的建筑队-墙体
    /// </summary>
    public class RoomWallBuilder : Builder
    {
        public override void BuildPart(House house)
        {
            house.Wall = "普通房子的墙体";
        }
    }
    /// <summary>
    /// 普通房子的建筑队-屋顶
    /// </summary>
    public class RoomRoofBuilder : Builder
    {
        public override void BuildPart(House house)
        {

            house.Roof = "普通房子的屋顶";
        }
    }


    /// <summary>
    /// 包工头
    /// </summary>
    public class Director
    {
        private List<Builder> homeBuilders = new List<Builder>();

        private Dictionary<string, Builder> goodHouseBuilders = new Dictionary<string, Builder>();

        /// <summary>
        /// 聚合多个建筑队
        /// </summary>
        public Director()
        {
            this.homeBuilders.Add(new RoomBaseBuilder());
            this.homeBuilders.Add(new RoomWallBuilder());
            this.homeBuilders.Add(new RoomRoofBuilder());


            ///

            this.goodHouseBuilders.Add("Wall", new GoodHouseWallBuilder());
            this.goodHouseBuilders.Add("Base", new GoodHouseBaseBuilder());
            this.goodHouseBuilders.Add("Roof", new GoodHouseRoofBuilder());
        }
        //稳定构造对象的子部分
        public House BuildHomeHouse()
        {
            House house = new House();
            foreach (var builder in this.homeBuilders)
            {
                builder.BuildPart(house);
            }
            return house;
        }

        /// <summary>
        /// 建造别墅
        /// </summary>
        /// <returns></returns>
        public House BuildGoodHouse()
        {
            House house = new House();
            //order:
            Builder builder1 = this.goodHouseBuilders["Base"];
            builder1.BuildPart(house);

            this.goodHouseBuilders["Wall"].BuildPart(house);
            this.goodHouseBuilders["Roof"].BuildPart(house);

            return house;
        }



    }


    /// <summary>
    /// 别墅的地基建筑队-地基
    /// </summary>
    public class GoodHouseBaseBuilder:Builder
    {

        public override void BuildPart(House house)
        {
            house.Base = "别墅的地基";
        }
    }

    /// <summary>
    /// 别墅的 建筑队-
    /// </summary>
    public class GoodHouseWallBuilder : Builder
    {

        public override void BuildPart(House house)
        {
            house.Wall = "别墅的墙体";
        }
    }   /// <summary>
    /// 别墅的 建筑队-屋顶
    /// </summary>
    public class GoodHouseRoofBuilder : Builder
    {

        public override void BuildPart(House house)
        {
            house.Roof = "别墅的屋顶";
        }
    }
}
