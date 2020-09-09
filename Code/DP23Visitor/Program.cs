using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP23Visitor
{
    #region 访问者模式  C#设计模式-访问者模式

    //游客
    public abstract class Vistitor
    {
        public abstract void VisitChinaMuseum(ChinaMuseum museum);
        public abstract void VisitEnglandMuseum(EnglandMuseum museum);
    }

    //现有的对象结构(element)
    //抽象节点角色（Element）
    public abstract class Museum
    {
        /// <summary>
        /// 接待游客
        /// </summary>
        /// <param name="visitor"></param>
        public abstract void Accept(Vistitor visitor);
    }

    public class ChinaMuseum : Museum
    {
        public override void Accept(Vistitor visitor)
        {
            this.Dance();
            visitor.VisitChinaMuseum(this);

        }

        /// <summary>
        /// 具体element特有的方法或行为
        /// </summary>
        public void Dance()
        {
            Console.WriteLine("56个民族56朵花,跳56个民族舞蹈");
        }
        public void Paint()
        {
            Console.WriteLine("表演中国绘画");
        }
    }

    public class EnglandMuseum : Museum
    {
        public override void Accept(Vistitor visitor)
        {
            this.Play();
            visitor.VisitEnglandMuseum(this);
        }

        /// <summary>
        /// 具体element特有的方法或行为
        /// </summary>
        private void Play()
        {
            Console.WriteLine("演奏风笛");
        }
    }


    public class GoodVisitor : Vistitor
    {
        /// <summary>
        /// 录像
        /// </summary>
        private void Video()
        {
            Console.WriteLine("全程录像");
        }
        public override void VisitChinaMuseum(ChinaMuseum museum)
        {
            Console.WriteLine("崇拜地看舞蹈");
            museum.Paint();
            Console.WriteLine("为精美的绘画鼓掌");
            this.Video();//新增的行为或功能
        }

        public override void VisitEnglandMuseum(EnglandMuseum museum)
        {
            Console.WriteLine("为风笛的演奏喝彩");
            this.Video();
        }
    }

    public class BadVisitor : Vistitor
    {
        public override void VisitChinaMuseum(ChinaMuseum museum)
        {
            Console.WriteLine("乱吆喝,吹口哨");
        }

        public override void VisitEnglandMuseum(EnglandMuseum museum)
        {
            Console.WriteLine("中途打电话");
        }
    }

    public class Expo
    {
        private List<Museum> museums = new List<Museum>();
        public Expo()
        {
            this.museums.Add(new ChinaMuseum());
            this.museums.Add(new EnglandMuseum());
        }

        public void Welcome(Vistitor visitor)
        {
            foreach (var museum in this.museums)
            {
                museum.Accept(visitor);
            }
        }
    } 
    #endregion


    class Program
    {
        static void Main(string[] args)
        {
            Expo expo = new Expo();

            Vistitor v1 = new GoodVisitor();
            Vistitor v2 = new BadVisitor();
            expo.Welcome(v1);

            Console.WriteLine();
            expo.Welcome(v2); 


        }
    }
}
