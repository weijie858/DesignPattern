using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP13TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            厨师 cooker1 = new 大排档师傅();
            厨师 cooker2 = new 五星级大厨();

            cooker1.工作();
            Console.WriteLine();
            cooker2.工作();
        }
    }

    public abstract class 厨师
    {
        private void 上班()
        {
            Console.WriteLine("{0}开始上班", this.姓名);
        }
        private void 下班()
        {
        }

        /// <summary>
        /// 模板方法:步骤不变的,具体实现过程,可以给子类再在运行时决定
        /// </summary>
        public void 工作()
        {
            Console.WriteLine("{0}开始工作",this.姓名);
            this.上班();
            this.洗菜();
            this.炒菜();
            this.盛菜();
            this.下班();
            
        }

        /// <summary>
        /// 以下3个方法,是交给子类实现 的具体子步骤
        /// </summary>
        protected abstract void 洗菜();
        protected abstract void 炒菜();
        protected abstract void 盛菜();

        /// <summary>
        /// 钩子:模板方法(交给子类实现),在父类中调用
        /// </summary>
        public abstract string 姓名
        {
            get;
        }

    }

    public class 大排档师傅 : 厨师
    {
        protected override void 洗菜()
        {
            Console.WriteLine("大排档师傅:洗菜");
        }

        protected override void 炒菜()
        {

            Console.WriteLine("大排档师傅:炒菜");
        }

        protected override void 盛菜()
        {

            Console.WriteLine("大排档师傅:盛菜");
        }

        public override string 姓名
        {
            get { return "张师傅"; }
        }
    }

    public class 五星级大厨 : 厨师
    {
        protected override void 洗菜()
        {
            Console.WriteLine("五星级大厨:洗菜");
        }

        protected override void 炒菜()
        {
            Console.WriteLine("五星级大厨:炒菜");
        }

        protected override void 盛菜()
        {
            Console.WriteLine("五星级大厨:盛菜");
        }

        public override string 姓名
        {
            get {
                return "大牛";
            }
        }
    }

}
