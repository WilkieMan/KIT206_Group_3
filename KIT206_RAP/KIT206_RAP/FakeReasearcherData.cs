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
            return new List<Researcher>()
            {
                new Staff(Researcher.Title.Dr, "Albert", "Einstein", Researcher.EmploymentLevel.A),
                new Staff(Researcher.Title.Dr, "Marie", "Curie", Researcher.EmploymentLevel.B),
                new Student(Researcher.Title.Mrs, "Jane", "Doe", Researcher.EmploymentLevel.Student),
                new Student(Researcher.Title.Mr, "John", "Doe", Researcher.EmploymentLevel.Student),
                new Staff(Researcher.Title.Prof, "Stephen", "Hawkings", Researcher.EmploymentLevel.A),
                new Student(Researcher.Title.Ms, "Amelia", "Reagan", Researcher.EmploymentLevel.Student),
                new Student(Researcher.Title.Mrs, "Roberta", "Dawson", Researcher.EmploymentLevel.Student),
                new Staff(Researcher.Title.Rev, "Mark", "Holland", Researcher.EmploymentLevel.E)
            };
        }
    }
}
