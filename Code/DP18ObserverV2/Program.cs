using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP18ObserverV2
{

    /// <summary>
    /// 逃跑的参数
    /// </summary>
    public class RunArgs
    {
        public string NewLocation { get; set; }
        public string OldLocaion { get; set; }
        public bool Cancel { get; set; }
    }

    /// <summary>
    /// 处理逃跑事件的委托,给事件定义使用
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void RunAwaryHandler(BadMan sender, RunArgs args);

    public class BadMan
    {
        private string _location="居住地";

        public string Location
        {
            get { return _location; }
        }
        /// <summary>
        /// 跑路事件
        /// </summary>
        public event RunAwaryHandler Run = null;

        /// <summary>
        /// 公开一个方法 ,能激发事件
        /// </summary>
        /// <param name="NewLocaion"></param>
        public void RunAway(string NewLocaion)
        {

            //激发事件
            if (this.Run != null)
            {
                RunArgs args = new RunArgs();
                args.NewLocation = NewLocaion;
                args.OldLocaion = this._location;


                this.Run(this, args);
                if (!args.Cancel)
                {
                    this._location = NewLocaion;
                }
                else
                {
                    Console.WriteLine("暂时不跑");
                }
            }
            
        }

        public void RunAway(object sender, EventArgs args)
        {
            Console.WriteLine("听到警察的警笛");
        }
    }

    public class Police
    {
        public void CatchBadMan(BadMan target, RunArgs args)
        {
            //推来的数据
            Console.WriteLine("警察撤销:{0}的警力,重新在:{1}部属警力",args.OldLocaion,args.NewLocation);
        }

        public void Gogogo()
        {
            Console.WriteLine("出警");
            if (this.GoOut!=null)
            {
                this.GoOut(this, null);
            }

        }
        public event EventHandler GoOut = null;
    }

    public class Wife
    {
        public void Pray(BadMan husband, RunArgs args)
        {
            //拉来的数据
            var location = husband.Location;
            Console.WriteLine("老婆为远在:{0}的老公祈祷",location);
            if (args.NewLocation=="海南")
            {
                args.Cancel = true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BadMan man = new BadMan();
            Police police = new Police();
            Wife wife= new Wife();

            police.GoOut += man.RunAway;


            man.Run += new RunAwaryHandler(police.CatchBadMan);
            man.Run += wife.Pray;

            man.Run += (sender, arguments) =>
            {
                Console.WriteLine("热心市民:在{0}看到一个罪犯",arguments.NewLocation);
            };

            man.RunAway("南宁");
            man.RunAway("海南");
            Console.WriteLine("现在所在位置:{0}",man.Location);

            police.Gogogo();
        }
 
    }
}
