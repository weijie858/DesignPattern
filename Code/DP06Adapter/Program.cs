using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP06Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new USAPlayer() { Name = "Kebi" };
            Player p2 = new USAPlayer() { Name = "Jordan" };

            Player p3 = new Translator();

            p1.Attack();
            p2.Defense();
            p3.Attack();
            p3.Defense();


        }
    }

    public abstract class Player
    {
        public string Name { get; set; }

        /// <summary>
        /// 新接口中的方法
        /// </summary>
        public abstract void Attack();
        public abstract void Defense();

        //public void Attack(ChinaCBAPlayer adaptee)
        //{
        //    adaptee.进攻();
        //}
    }

    public class USAPlayer : Player
    {
        public override void Attack()
        {
            Console.WriteLine("{0}-Attack!",base.Name);
        }

        public override void Defense()
        {
            Console.WriteLine("{0}-Defense",base.Name);
        }
    }




    public class ChinaCBAPlayer
    {
        public string Name { get; set; }
        /// <summary>
        /// 老系统
        /// </summary>
        public void 进攻()
        {
            Console.WriteLine("{0}:进攻",this.Name);
        }
        public void 防守()
        {
            Console.WriteLine("{0}:防守",this.Name);
        }
    }


    /// <summary>
    /// 适配器
    /// </summary>
    public class Translator : Player
    {
        /// <summary>
        /// 被适配的对象
        /// </summary>
        private ChinaCBAPlayer _adaptee = new ChinaCBAPlayer() { Name = "姚明" };

        public override void Attack()
        {
           
            //借力打力
            this._adaptee.进攻();
        }

        public override void Defense()
        {
           //移花接木
            this._adaptee.防守();
        }
    }


}
