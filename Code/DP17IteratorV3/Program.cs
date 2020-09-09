using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP17IteratorV3
{
  

    /// <summary>
    /// 班级
    /// </summary>
    public class Clazz :System.Collections.IEnumerable
    {
        private List<Student> _students = new List<Student>();
        public void AddStudent(Student student)
        {
            this._students.Add(student);
        }
               



        /// <summary>
        /// 按照升序迭代
        /// </summary>
        private class ClazzASCIterator  :System.Collections.IEnumerator
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

            private int currentIndex = -1;





            public object Current
            {
                get { return this.myclass._students[this.currentIndex]; }
            }

            public bool MoveNext()
            {
                this.currentIndex++;
                return this.currentIndex != this.myclass._students.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }




        public System.Collections.IEnumerator GetEnumerator()
        {
            return new ClazzASCIterator(this);
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

            System.Collections.IEnumerator enumerator = (clazz as System.Collections.IEnumerable).GetEnumerator();
            while (enumerator.MoveNext())
            {
                object current = enumerator.Current;
                Console.WriteLine(current);
            }

            foreach (var item in clazz)
            {
                Console.WriteLine(item);
            }
           



        }
    }
}
