using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP17IteratorV2
{

    /// <summary>
    /// 聚合对象(集合)
    /// </summary>
    public abstract class Aggregate
    {
        //
        public abstract Iterator CreateInterator();

    }

    /// <summary>
    /// 迭代器:能遍历一个集合的遍历行为
    /// </summary>
    public abstract class Iterator
    {
        public abstract void Next();
        public abstract object Current();
        public abstract bool Done { get; }
    }


    /// <summary>
    /// 班级
    /// </summary>
    public class Clazz : Aggregate
    {
        private List<Student> _students = new List<Student>();
        public void AddStudent(Student student)
        {
            this._students.Add(student);
        }
 





        public override Iterator CreateInterator()
        {
            return new ClazzDESCIterator(this);
        }



        /// <summary>
        /// 按照升序迭代
        /// </summary>
        private class ClazzASCIterator : Iterator
        {
            /// <summary>
            /// 关联到需要迭代的那个班级(集合)
            /// </summary>
            private Clazz myclass = null;

            /// <summary>
            /// 对班级的依赖
            /// </summary>
            /// <param name="classToInterator"></param>
            public ClazzASCIterator(Clazz classToInterator)
            {
                this.myclass = classToInterator;
            }

            private int currentIndex = 0;

            public override void Next()
            {
                this.currentIndex++;
            }

            public override object Current()
            {
                return this.myclass._students[this.currentIndex];
            }

            public override bool Done
            {
                get
                {
                    return this.currentIndex == this.myclass._students.Count;
                }
            }
        }


        /// <summary>
        /// 按照降序迭代
        /// </summary>
        private class ClazzDESCIterator : Iterator
        {
            /// <summary>
            /// 关联到需要迭代的那个班级(集合)
            /// </summary>
            private Clazz myclass = null;

            /// <summary>
            /// 对班级的依赖
            /// </summary>
            /// <param name="classToInterator"></param>
            public ClazzDESCIterator(Clazz classToInterator)
            {
                this.myclass = classToInterator;
                this.currentIndex = this.myclass._students.Count - 1;
            }

            private int currentIndex;

            public override void Next()
            {
                this.currentIndex--;
            }

            public override object Current()
            {
                return this.myclass._students[this.currentIndex];
            }

            public override bool Done
            {
                get
                {
                    return this.currentIndex == -1;
                }
            }
        }



    }


    public class Student
    {
        public Student(string Name)
        {
            this._Name = Name;
        }
        public string _Name;
        public override string ToString()
        {
            return this._Name;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            Clazz clazz = new Clazz();
            clazz.AddStudent(new Student("张三"));
            clazz.AddStudent(new Student("李四"));
            clazz.AddStudent(new Student("王五"));

            Iterator iterator = (clazz as Aggregate).CreateInterator();
            while (!iterator.Done)
            {
                object current = iterator.Current();
                Console.WriteLine(current);
                iterator.Next();
            }

           
            
        }
    }
}
