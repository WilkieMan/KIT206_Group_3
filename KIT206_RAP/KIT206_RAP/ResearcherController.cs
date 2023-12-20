using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{

    internal class ResearcherController
    {
        private static List<Researcher> masterList = FakeReasearcherData.Generate();
        private List<Researcher> modifiedList = masterList;
        private List<Researcher> tempList = new List<Researcher>();

        public void DisplayCurrentList()
        {
            foreach (Researcher researcher in modifiedList)
            {
                Console.WriteLine(researcher.ToBasicName());
            }

            Console.WriteLine();
        }

        public void DisplayList(List<Researcher> list)
        {
            foreach (Researcher researcher in list)
            {
                Console.WriteLine(researcher.ToBasicName());
            }

            Console.WriteLine();
        }

        public void LoadResearchers()
        {
            
        }

        public List<Researcher> FilterByJobTitle(Researcher.EmploymentLevel employmentLevel)
        {
            var temp = from Researcher r in masterList
                       where r.employmentLevel == employmentLevel
                       select r;

            return new List<Researcher>(temp);
        }

        public List<Researcher> FilterByName()
        {

            Console.Write("Enter search text: ");
            string searchText = Console.ReadLine().ToLower();

            var searchResults = from Researcher r in masterList
                                where r.givenName.ToLower().Contains(searchText) || r.familyName.ToLower().Contains(searchText)
                                select r;

            return new List<Researcher>(searchResults);
        }

        public List<Student> getSupervisions(int id)
        {
            var supervisions =  from Student s in masterList
                                where s.supervisor.id == id
                                select s;

            return new List<Student>(supervisions);
        }

    }

}