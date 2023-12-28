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

        public static List<int> fake1 = new List<int>();
        public static Staff a = new Staff(111111, "Marie", "Curie", Researcher.Title.Dr, Researcher.Campus.Launceston, Position.EmploymentLevel.B, 7000.0);

        static void Main(string[] args)
        {

            fake1.Add(10000);
            fake1.Add(15000);
            fake1.Add(12000);

            a.Positions.Add(new Position(111111, Position.EmploymentLevel.C, new DateTime(2020, 3, 20), new DateTime(2020, 12, 31)));
            a.Positions.Add(new Position(111111, Position.EmploymentLevel.B, new DateTime(2021, 1, 1), new DateTime(2022, 1, 1)));
            a.Positions.Add(new Position(111111, Position.EmploymentLevel.A, new DateTime(2022, 1, 2), DateTime.Now));

            a.FundingList.Add(2000.0);
            a.FundingList.Add(5000.0);
            a.FundingList.Add(3000.0);
            a.FundingList.Add(4000.0);

            a.Publications.Add(new Publication("A", "123121"));

            //use case 8 functions
            //Console.WriteLine("FIRST LIST");
            //researcherController.DisplayCurrentList();
            //testList = researcherController.Alphabetise(testList);
            //Console.WriteLine("ALPHABETISED LIST");
            //researcherController.DisplayList(testList);
            //testList = researcherController.FilterByName();
            //researcherController.DisplayList(testList);
            //testList = researcherController.FilterByJobTitle(Position.EmploymentLevel.Student);
            //researcherController.DisplayList(testList);

            //use case 16 functions
            Console.WriteLine(a.CurrentJob);
            Console.WriteLine(a.CurrentJobTitle);
            Console.WriteLine(a.CurrentJobStart);
            Console.WriteLine(a.EarliestJobStart);
            Console.WriteLine(a.CurrentJobTitle);
            
            foreach (Position p in a.EarlierJobs)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine(a.Tenure);
            Console.WriteLine(a.ThreeYearAverage);






        }
    }
}
