using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP15Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            SupperMarket mediator = new SupperMarket();
            Colleague c1 = new Customer(mediator,"李阿婆");

            Colleague c3 = new Customer(mediator, "王阿姨");
            Colleague c2 = new Supplier(mediator);

            c2.PublishNotice("厂家促销,买一送一");

            Console.WriteLine();
            mediator.Promot();

            Console.WriteLine();
            (mediator as Mediator).Remove(c2);

            mediator.Promot();

            Console.WriteLine();
            c3.PublishNotice("家乐福最近大米很便宜");
        }
    }

    /// <summary>
    /// 参与交互的对象
    /// </summary>
    public abstract class Colleague
    {
        /// <summary>
        /// 中间人的引用
        /// </summary>
        public Mediator TheMediator { get; set; }

        /// <summary>
        /// 收听中间人的通知
        /// </summary>
        /// <param name="Notice"></param>
        public abstract void ReceiveNotice(string Notice);

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="Notice"></param>
        public void PublishNotice(string Notice)
        {
            this.TheMediator.Bulletin(Notice);
        }
    }

    /// <summary>
    /// 中介者
    /// </summary>
    public abstract class Mediator
    {
        /// <summary>
        /// 对"同事"的聚合
        /// </summary>
        protected List<Colleague> colleagues = new List<Colleague>();

        public void Register(Colleague colleague)
        {
            this.colleagues.Add(colleague);
        }

        public void Remove(Colleague colleague)
        {
            this.colleagues.Remove(colleague);
        }

        public virtual void Bulletin(string Content)
        {
            foreach (var colleague in this.colleagues)
            {
                colleague.ReceiveNotice(Content);
            }
        }

    }


    public class SupperMarket : Mediator
    {
        public override void Bulletin(string Content)
        {
            Console.WriteLine("超市发布新的公告:{0}", Content);
            base.Bulletin(Content);
        }

        public void Promot()
        {
            this.Bulletin("中秋大促销");
        }
    }

    public class Customer : Colleague
    {
        private string _name;

        public Customer(Mediator mediator,string Name)
        {
            this._name = Name;
            base.TheMediator = mediator;
            mediator.Register(this);
        }
        public override void ReceiveNotice(string Notice)
        {
            Console.WriteLine("顾客{1},听到新的通知:{0}", Notice,this._name);
        }
    }
    public class Supplier : Colleague
    {
        public Supplier(Mediator mediator)
        {
            base.TheMediator = mediator;
            mediator.Register(this);
        }

        public override void ReceiveNotice(string Notice)
        {
            Console.WriteLine("供应商听到新的通知:{0}", Notice);
            Console.WriteLine("加大进货或减少库存");
        }
    }
}
