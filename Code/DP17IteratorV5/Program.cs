using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP17IteratorV5
{


    /// <summary>
    /// 班级
    /// </summary>
    public class Clazz : IEnumerable<Student>
    {
        private List<Student> _students = new List<Student>();
        public void AddStudent(Student student)
        {
            this._students.Add(student);
        }

      

        public IEnumerator<Student> GetEnumerator()
        {
            foreach (var student in this._students)
            {
                yield return student;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var student in this._students)
            {
                yield return student;
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
