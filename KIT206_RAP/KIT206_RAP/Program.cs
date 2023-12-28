using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class Program
    {
        static ResearcherController researcherController = new ResearcherController();
        private static List<Researcher> testList = DBAdapter.FetchBasicResearcher();

        static void Main(string[] args)
        {

            //use case 8 functions
            Console.WriteLine("FIRST LIST");
            researcherController.DisplayCurrentList();


            testList = researcherController.Alphabetise(testList);

            Console.WriteLine("ALPHABETISED LIST");
            researcherController.DisplayList(testList);

            testList = researcherController.FilterByName();
            researcherController.DisplayList(testList);
            testList = researcherController.FilterByJobTitle(Position.EmploymentLevel.Student);
            researcherController.DisplayList(testList);
            
            //use case 16 functions

        }
    }
}
