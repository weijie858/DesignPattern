using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB07Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            职位 p1 = new 董事长();
            职位 p2 = new 办公室主任();


            党内职务 d1 = new 支部书记();
            党内职务 d2 = new 纪检委员();
            党内职务 d3 = new 调研员();

            p1.任命(d1);
            p1.任命(d2);

            p2.任命(d3);
            p2.任命(d2);

            p1.履行职责();
            p2.履行职责();

            //d2.为人民服务();
            //d3.为人民服务();



           
        }
    }

    /// <summary>
    /// 主要抽象
    /// </summary>
    public abstract class 职位
    {
        public abstract string 名称 { get; }

        private List<党内职务> duties = new List<党内职务>();
        public void 任命(党内职务 newDuty)
        {
            this.duties.Add(newDuty);
        }

        public void 履行职责()
        {
            Console.WriteLine("\r\n{0}准备为人民服务了:", this.名称);
            foreach (var item in this.duties)
            {
                item.为人民服务();
            }
            Console.WriteLine("{0}为人民服务完毕", this.名称);
        }

    }

    /// <summary>
    /// 次要抽象,功能的抽象
    /// </summary>
    public abstract class 党内职务
    {
        public abstract void 为人民服务();
    }


    public class 董事长 : 职位
    {

        public override string 名称
        {
            get { return "董事长"; }
        }
    }

    public class 办公室主任 : 职位
    {

        public override string 名称
        {
            get { return "办公室主任"; }
        }
    }

    public class 支部书记 : 党内职务
    {
        public override void 为人民服务()
        {
            Console.WriteLine("组织党员进行思想总结和自我批评");
        }
    }
    public class 纪检委员 : 党内职务
    {
        public override void 为人民服务()
        {
            Console.WriteLine("听取群众的意见和建议");
        }
    }
    public class 调研员 : 党内职务
    {
        public override void 为人民服务()
        {
            Console.WriteLine("调研基层的大好形势");
        }
    }
}
