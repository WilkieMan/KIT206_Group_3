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

        public void DisplayCurrentList()
        {
            foreach (Researcher researcher in modifiedList)
            {
                Console.WriteLine(researcher.ToBasicName());
            }

            Console.WriteLine();
        }
    }
}
