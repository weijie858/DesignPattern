using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP21State
{
    /// <summary>
    /// State
    /// </summary>
    public abstract class BodyState
    {
        public abstract void Work();

    }

    public class GoodState : BodyState
    {
        public override void Work()
        {
            Console.WriteLine("精力充沛地工作");
        }
    }

    public class ColdState : BodyState
    {
        public override void Work()
        {
            Console.WriteLine("打喷嚏+咳嗽工作");
        }
    }


    /// <summary>
    /// Context
    /// </summary>
    public class Teacher
    {
        private Dictionary<int, BodyState> _states = new Dictionary<int, BodyState>();
        public Teacher()
        {
            this._states.Add(1, new GoodState());
            this._states.Add(2,new ColdState());
        }
 
        /// <summary>
        /// Request
        /// </summary>
        public void Teach(bool Good)
        {
          
            if (Good)
            {
                this._states[1].Work();
            }
            else
            {
                this._states[2].Work();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Teacher t = new Teacher();
            t.Teach(true);
            t.Teach(false);
        }
    }
}
