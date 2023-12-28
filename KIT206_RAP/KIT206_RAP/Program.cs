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
            researcherController.DisplayCurrentList();
            testList = researcherController.FilterByName();
            researcherController.DisplayList(testList);
            testList = researcherController.FilterByJobTitle(Position.EmploymentLevel.Student);
            researcherController.DisplayList(testList);
            

        }
    }
}
