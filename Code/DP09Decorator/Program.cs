using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP09Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IDecoratable camera = new Canon500D();

            Decorator flash = new 闪光灯();
            Decorator thri = new 三脚架();
            Decorator jingtou = new 镜头();

            //thri.ObjetoToDecorate = jingtou;
            //jingtou.ObjetoToDecorate = flash;
            //flash.ObjetoToDecorate = camera;

         //   thri.Decorate(jingtou).Decorate(flash).Decorate(camera);


            flash.Decorate(thri).Decorate(jingtou).Decorate(camera);

            (camera as IDecoratable).Decorate();

           

        }
    }

    /// <summary>
    /// 可以动态添加新功能的接口
    /// </summary>
    public interface IDecoratable
    {
        /// <summary>
        /// 添加并运行新功能
        /// </summary>
        void Decorate();
    }

    /// <summary>
    /// 相机
    /// </summary>
    public abstract class Camera : IDecoratable
    {
        /// <summary>
        /// 拍照
        /// </summary>
        public abstract void TakePhoto();

        /// <summary>
        /// 实现接口中定义的新的功能 
        /// </summary>
        public void Decorate()
        {
            //转化为相机自身的功能:拍照
            this.TakePhoto();
        }
    }
    public class Canon500D : Camera
    {

        public override void TakePhoto()
        {
            Console.WriteLine("500D拍照");
        }
    }


    /// <summary>
    /// 所有的动态添加的功能的抽象
    /// </summary>
    public abstract class Decorator : IDecoratable
    {
        /// <summary>
        /// 这个功能去添加的对象
        /// </summary>
        public IDecoratable ObjetoToDecorate { get; set; }
        public Decorator Decorate(Decorator objectToDecorate)
        {
            this.ObjetoToDecorate = (IDecoratable)objectToDecorate;
            return objectToDecorate;
        }
        public  void Decorate(IDecoratable objectToDecorate)
        {
            this.ObjetoToDecorate = objectToDecorate; 
        }

        public virtual void Decorate()
        {
            if (this.ObjetoToDecorate!=null)
            {
                this.ObjetoToDecorate.Decorate();
            }
        }
    }

    public class 三脚架 : Decorator
    {
        public override void Decorate()
        {
            Console.WriteLine("树立三脚架,稳定相机");

            base.Decorate();

        }
    }

    public class 闪光灯 : Decorator
    {
        public override void Decorate()
        {
            Console.WriteLine("闪光灯充电并闪光");

            base.Decorate();

        }
    }

    public class 镜头 : Decorator
    {
        public override void Decorate()
        {
            Console.WriteLine("安装镜头,并调整焦距和光圈");

            base.Decorate();

        }
    }
}
