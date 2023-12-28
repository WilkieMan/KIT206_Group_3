using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class FakeReasearcherData
    {
        public static List<Researcher> Generate()
        {

            List<int> fake1 = new List<int>();

            fake1.Add(10000);
            fake1.Add(15000);
            fake1.Add(12000);

            List<int> fake2 = new List<int>();

            fake1.Add(2000);
            fake1.Add(5000);
            fake1.Add(6000);
            fake1.Add(10000);
            fake1.Add(8000);


            return new List<Researcher>()
            {
                new Student(123456, "Jane", "Doe", Researcher.Title.Miss, Researcher.Campus.Hobart, Position.EmploymentLevel.Student, "Medicine", 111111),
                //new Staff(111111, "Marie", "Curie", Researcher.Title.Dr, Researcher.Campus.Launceston, Position.EmploymentLevel.B, fake1, 7000.0),
                //new Student(Researcher.Title.Mrs, "Jane", "Doe", Researcher.EmploymentLevel.Student, 3),
                //new Student(Researcher.Title.Mr, "John", "Doe", Researcher.EmploymentLevel.Student, 4),
                //new Staff(222222, "Stephen", "Hawkings", Researcher.Title.Prof, Researcher.Campus.Hobart, Position.EmploymentLevel.A, fake2, 5000.0),
                new Student(112233, "Amelia", "Reagan", Researcher.Title.Ms, Researcher.Campus.CradleCoast, Position.EmploymentLevel.Student, "Arts", 222222),
                //new Student(Researcher.Title.Mrs, "Roberta", "Dawson", Researcher.EmploymentLevel.Student, 7),
                //new Staff(Researcher.Title.Rev, "Mark", "Holland", Researcher.EmploymentLevel.E, 8)*/
            };
        }
    }
}