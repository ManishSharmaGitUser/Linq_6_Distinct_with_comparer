using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_6_Distinct_With_Equality_and_Comparer
{
    public class Program
    {
        static void Main(string[] args)
        {

            Student[] Demo_data = { new Student { Id = 1, Name = "Manish" },
                                    new Student { Id = 2, Name = "John" },
                                    new Student { Id = 1, Name = "Manish" } };

            var result = Demo_data.Distinct().ToList(); //Here Distinct will not work due to object type 

            //to compare object with each member value use IEquatable interface or IComparer Interface

            var result1 = Demo_data.Distinct().ToList();


            //after using IEqualityComparer interface

            var result2 = Demo_data.Distinct(new StudentComparer()).ToList();

            foreach (var item in result2)
            {
                Console.WriteLine("Id : " + item.Id + " " + "Name : " + item.Name);
            }
            Console.ReadLine();
        }
    }


    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }


    //public class Student  :IEquatable<Student>
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    public bool Equals(Student other)
    //    {
    //        if (object.ReferenceEquals(other, null))
    //        {
    //            return false;
    //        }
    //        if (object.ReferenceEquals(this,other))
    //        {
    //            return true;
    //        }

    //        return Id.Equals(other.Id) && Name.Equals(other.Name);
    //    }
    //    public override int GetHashCode()
    //    {
    //        int idhashcode = Id.GetHashCode();
    //        int namehashcode = Name.GetHashCode();
    //        return  idhashcode ^ namehashcode;
    //    }
    //}

    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.Id.Equals(y.Id) && x.Name.Equals(y.Name);
        }

        public int GetHashCode(Student obj)
        {
            int idhashcode = obj.Id.GetHashCode();
            int namehashcode = obj.Name.GetHashCode();
            return idhashcode ^ namehashcode;
        }
    }
}
