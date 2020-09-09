using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP12Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IGirlFriend girl = new Classmate();
            girl.WatchFilm();

            Console.WriteLine();
            girl = new Diamond();
            girl.WatchFilm();
        }
    }

    public interface IGirlFriend
    {
        //电影约会
        void WatchFilm();

    }


    /// <summary>
    /// RealSubject:校花
    /// </summary>
    public class SchoolFlower : IGirlFriend
    {
        public void WatchFilm()
        {
            Console.WriteLine("校花看电影");
        }
    }

    /// <summary>
    /// 好友:Proxy
    /// </summary>
    public class Classmate : IGirlFriend
    {
        private SchoolFlower sf = new SchoolFlower();
        public void WatchFilm()
        {
            Console.WriteLine("先铺垫");
            Console.WriteLine("再动员");
            sf.WatchFilm();
            Console.WriteLine("红娘工作完成");
        }
    }


    /// <summary>
    /// 钻石
    /// </summary>
    public class Diamond : IGirlFriend
    {
        private SchoolFlower sf = new SchoolFlower();
        public void WatchFilm()
        {
            Console.WriteLine("鸽子蛋大的钻石Show出来");
            sf.WatchFilm();
            Console.WriteLine("看完电影想干嘛就干嘛");
        }
        public void  Show()
        {
            Console.WriteLine("鸽子蛋大的钻石Show出来");
            sf.WatchFilm();
            Console.WriteLine("看完电影想干嘛就干嘛");

        }


    }


}
