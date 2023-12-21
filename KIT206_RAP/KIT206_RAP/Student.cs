using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class Student : Researcher
    {
        private string degree;
        public Staff supervisor;

        public Student(Title title, string givenName, string familyName, EmploymentLevel employmentLevel, int id) : base(title, givenName, familyName, employmentLevel, id)
        {

        }
    }
}
