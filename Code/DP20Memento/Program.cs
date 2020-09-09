using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP20Memento
{
    /// <summary>
    /// 备忘:仅封装数据
    /// </summary>
    public class Memento
    {
        public int Life { get; set; }
        public override string ToString()
        {
            return string.Format("当前生命:{0}", this.Life);
        }
    }



    public interface IOriginator
    {
        void Load(Memento memento);
        Memento Save();
    }

    public class Game : IOriginator
    {
        private int _life = 100;
        public void Fight()
        {
            System.Threading.Thread.Sleep(2000);
            this._life -= new Random().Next(100);
        }
        public override string ToString()
        {
            return string.Format("当前生命值:{0},游戏结束?{1}", this._life, this._life < 1);
        }




        public void Load(Memento memento)
        {
            this._life = memento.Life;
        }

        public Memento Save()
        {
            return new Memento() { Life = this._life };
        }
    }

    /// <summary>
    /// 存档管理
    /// </summary>
    public class CareTaker
    {
        private Dictionary<int, Memento> mementos = new Dictionary<int, Memento>();

        public void SaveMemento(int ID, Memento memento)
        {
            this.mementos.Add(ID, memento);
        }
        public Memento LoadMemento(int ID)
        {
            return this.mementos[ID];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.mementos)
            {
                sb.AppendFormat("存档ID:{0}--{1}\r\n",item.Key,item.Value);
            }
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IOriginator originator = new Game();
            Console.WriteLine(originator);

            Memento m = originator.Save();
            Console.WriteLine(m);


            CareTaker caretaker = new CareTaker();
            caretaker.SaveMemento(1, m);//第一次存档

            (originator as Game).Fight();

            Console.WriteLine(originator);

            m = originator.Save();
            Console.WriteLine(m);
            caretaker.SaveMemento(2, m);//第二次存档

            (originator as Game).Fight();

            Console.WriteLine(originator);

            m = originator.Save();
            Console.WriteLine(m);
            caretaker.SaveMemento(3, m);//第三次存档

            Console.WriteLine("-----------");
            Console.WriteLine(caretaker);

            ///还原
            ///

            Game game = originator as Game;

            game.Load(caretaker.LoadMemento(2));
            Console.WriteLine(game);
            game.Load(caretaker.LoadMemento(1));
            Console.WriteLine(game);
            game.Load(caretaker.LoadMemento(2));
            Console.WriteLine(game);
            game.Load(caretaker.LoadMemento(3));
            Console.WriteLine(game);


        }
    }
}
