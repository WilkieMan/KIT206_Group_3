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
        private List<Researcher> testList = FakeReasearcherData.Generate();

        static void Main(string[] args)
        {
            researcherController.DisplayCurrentList();
            List<Researcher> testList = researcherController.FilterByName();
            researcherController.DisplayList(testList);
            DBAdapter.FetchBasicResearcher();

        }
    }
}
