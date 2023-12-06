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
                new Staff(Researcher.Title.Dr, "Albert", "Einstein"),
                new Staff(Researcher.Title.Dr, "Marie", "Curie"),
                new Student(Researcher.Title.Mrs, "Jane", "Doe"),
                new Student(Researcher.Title.Mr, "John", "Doe"),
                new Staff(Researcher.Title.Prof, "Stephen", "Hawkings"),
                new Student(Researcher.Title.Ms, "Amelia", "Reagan"),
                new Student(Researcher.Title.Mrs, "Roberta", "Dawson"),
                new Staff(Researcher.Title.Rev, "Mark", "Holland")
            };
        }
    }
}
