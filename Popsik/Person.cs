using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popsik
{
   public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Departmets Department { get; set; }
        public override string ToString()
        {
            return $"{Id}{Name}{Age}";
        }

    }
  public class Departmets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Couty { get; set; }
        public List<Person> People { get; set; }
    }
}