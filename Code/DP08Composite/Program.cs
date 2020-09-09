using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP08Composite
{
    class Program
    {
        static void Main(string[] args)
        {

            Component computer = new Composite();

            Component box = new Composite() { Name = "机箱", Price = 300 };

            Component video = new Leaf() { Name = "显示器", Price = 1500 };

            Component masterboard = new Composite() { Name = "主板", Price =1000 };
            Component harddisk = new Leaf() { Name = "硬盘", Price = 600 };

            Component cpu = new Leaf() { Name = "CPU", Price = 1000 };
            Component videocard = new Leaf() { Name = "显卡", Price = 1200 };
            Component memory = new Leaf() { Name = "内存", Price = 500 };

            computer.Add(box);
            computer.Add(video);

            box.Add(masterboard);
            box.Add(harddisk);

            masterboard.Add(cpu);
            masterboard.Add(videocard);
            masterboard.Add(memory);


          //  masterboard.Remove(videocard);
            int total = computer.TotalPrice();
            Console.WriteLine(total);





        }
    }

    public abstract class Component
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public abstract void Add(Component part);
        public abstract void Remove(Component part);
        /// <summary>
        /// 计算当前的组件的总价
        /// </summary>
        /// <returns></returns>
        public abstract int TotalPrice();

      //  public Component Father { get; set; }
    }
    /// <summary>
    /// 不是容器的组件
    /// </summary>
    public class Leaf : Component
    {
        public override void Add(Component part)
        {
            throw new InvalidOperationException("本节点不允许该操作");
        }

        public override void Remove(Component part)
        {
            throw new InvalidOperationException("本节点不允许该操作");
        }

        public override int TotalPrice()
        {
            return base.Price;
        }
    }


    public class Composite : Component
    {
        private List<Component> _childParts = new List<Component>();
        public override void Add(Component part)
        {
      //      part.Father = this;

            this._childParts.Add(part);
        }

        public override void Remove(Component part)
        {
            this._childParts.Remove(part);
        }

        public override int TotalPrice()
        {
            int total = this.Price;
            foreach (var item in this._childParts)
            {
                total += item.TotalPrice();
            }
            return total;
        }
    }

}
