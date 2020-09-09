using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP18ObserverV1
{
    /// <summary>
    /// 关注的目标
    /// </summary>
    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void NotifyAllObservers(object args)
        {
            foreach (var observer in this.observers)
            {
                observer.Update(args);
            }
        }
    }

    /// <summary>
    /// 关注目标的对象:观察者
    /// </summary>
    public abstract class Observer
    {
        /// <summary>
        /// 对目标的通知做出响应
        /// </summary>
        public abstract void Update(object args);
    }

    public class BadMan : Subject
    {
        private string _currentLocation = "";

        /// <summary>
        /// 自己的状态,给它的观察者使用
        /// </summary>
        public string CurrentLocation
        {
            get { return _currentLocation; }
           
        }
        /// <summary>
        /// 逃跑,通过父类进行对所有观察者的通知
        /// </summary>
        /// <param name="Location"></param>
        public void RunAway(string Location)
        {
            this._currentLocation = Location;
            base.NotifyAllObservers(Location);
        }
    }
    
    public class PoliceMan : Observer
    {
        private BadMan _target = null;
        public PoliceMan(BadMan target)
        {
            this._target = target;
            this._target.Attach(this);
        }
        public override void Update(object args)
        {
            //var location = this._target.CurrentLocation;

            Console.WriteLine("警察:在{0}部署警力进行围堵", args);
        }
    }

    public class Citizen : Observer
    {
        private BadMan _target = null;
        public Citizen(BadMan target)
        {
            this._target = target;
            this._target.Attach(this);
        }
        public override void Update(object args)
        {
            var location = this._target.CurrentLocation;

            Console.WriteLine("热心市民:打110报警,坏人在:{0}", location);
        }
    }
    
    public class Wife : Observer
    {
        private BadMan _target = null;
        public Wife(BadMan target)
        {
            this._target = target;
            this._target.Attach(this);
        }
        public override void Update(object args)
        {
            //拉模式
            var location = this._target.CurrentLocation;

            Console.WriteLine("老婆:在{0}准备接应.", location);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new BadMan();

            Observer police = new PoliceMan(subject as BadMan);
            Observer citizen = new Citizen(subject as BadMan);
            Observer wife = new Wife(subject as BadMan);

            BadMan badman = subject as BadMan;

            badman.RunAway("广西");
            Console.WriteLine();
            badman.RunAway("海南");
            Console.WriteLine();
            subject.Detach(wife);
            badman.RunAway("美国");

            subject.Detach(police);
            Console.WriteLine();
            badman.RunAway("澳大利亚");
            Console.WriteLine();
            subject.Detach(citizen);
            badman.RunAway("月球");

        }
    }
}
