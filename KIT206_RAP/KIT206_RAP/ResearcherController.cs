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
            //loads the researchers
        }

        public List<Researcher> FilterByJobTitle(Researcher.EmploymentLevel employmentLevel)
        {
           foreach(Researcher r in masterList)
            {
                if (r.employmentLevel == employmentLevel)
                {
                    tempList.Add(r); //add the researcher to temporary list
                }
            }
            return tempList;
        }

        //modify
        public List<Researcher> FilterByName(string name)
        {
            foreach (Researcher r in masterList)
            {
                if (r.givenName == name)
                {
                    tempList.Add(r); //add the researcher to temporary list
                } else if (r.familyName == name)
                {
                    tempList.Add(r); //add the researcher to temporary list
                }
            }

            return tempList;
        }

    }



}
