using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP14Command
{
    /// <summary>
    /// 网络
    /// </summary>
    public static class NetWork
    {
        /// <summary>
        /// 网络是否通畅
        /// </summary>
        public static bool Online = true;

    }

    /// <summary>
    /// Receiver:命令的真正的执行者(接收者)
    /// </summary>
    public class WebService
    {

        /// <summary>
        /// Action
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="Total"></param>
        /// <param name="Customer"></param>
        public void NewOrder(Guid OrderNumber, int Total, string Customer)
        {
            Console.WriteLine("{0}在{1}下订单,订单金额为:{2},订单编号为:{3}", Customer, DateTime.Now, Total, OrderNumber);
        }
    }

    /// <summary>
    /// 命令的抽象
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// 执行命令
        /// </summary>
        public abstract void Execute();

        public abstract Guid CommandID { get; }

    }
    /// <summary>
    /// 具体的命令
    /// </summary>
    public class OrderCommand : Command
    {
        private WebService receiver = new WebService();///真的接收者的关联

        ///实现父类中的方法 
        public override void Execute()
        {
            this.receiver.NewOrder(this.OrderNumber, this.Total, this.Customer);
        }
        private Guid id = Guid.Empty;
        public OrderCommand()
        {
            this.id = Guid.NewGuid();
        }
        public override Guid CommandID
        {
            get { return this.id; }
        }

        //以下三个属性是属于具体命令的特有的state
        public int Total { get; set; }
        public Guid OrderNumber
        {
            get
            {
                return this.CommandID;
            }
        }
        public string Customer { get; set; }

        public override string ToString()
        {
            return string.Format("订单:{0},客户:{1},金额:{2}", this.id, this.Customer, this.Total);
        }
    }


    /// <summary>
    /// 调度者
    /// </summary>
    public class Invoker
    {
        private Dictionary<Guid, Command> commands = new Dictionary<Guid, Command>();


        public void AddCommand(Command cmd)
        {
            if (!this.commands.ContainsKey(cmd.CommandID))
            {
                this.commands.Add(cmd.CommandID, cmd);
                Console.WriteLine("命令已添加:{0}", cmd);
            }
            else
            {
                Console.WriteLine("不重复添加同一命令");
            }
        }
        public void RemoveCommand(Command cmd)
        {
            if (this.commands.ContainsKey(cmd.CommandID))
            {
                this.commands.Remove(cmd.CommandID);
                Console.WriteLine("命令已删除:{0}", cmd);
            }
            else
            {
                Console.WriteLine("该命令不存在");
            }
        }

        public void ExceuteAllCommand()
        {
            if (NetWork.Online)
            {
                foreach (var keyvaluePair in this.commands)
                {
                    Command cmd = keyvaluePair.Value;

                    cmd.Execute();
                    Console.WriteLine("{0}在线执行完毕",cmd);
                }
                this.commands.Clear();
            }
            else
            {
                Console.WriteLine("现在不在线,当前{0}个命令先不执行,缓存在本地",this.commands.Count);
            }
        }

    }

    class Program
    {


        static void Main(string[] args)
        {

            Invoker invoker = new Invoker();

            Command cmd1 = new OrderCommand() { Total = 200, Customer = "张三" };
            Command cmd2 = new OrderCommand() { Total = 800, Customer = "李四" };
            Command cmd3 = new OrderCommand() { Total = 500, Customer = "王五" };

            invoker.AddCommand(cmd1);
            Console.WriteLine();

            invoker.AddCommand(cmd2);
            Console.WriteLine();

            invoker.AddCommand(cmd3);

            Console.WriteLine();

            invoker.RemoveCommand(cmd3);

            NetWork.Online = false;

            Console.WriteLine();

            invoker.ExceuteAllCommand();

            NetWork.Online = true;

            Console.WriteLine();

            invoker.ExceuteAllCommand();

            Console.WriteLine();

            invoker.ExceuteAllCommand();



        }
    }
}
