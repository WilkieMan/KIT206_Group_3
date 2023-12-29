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
        public static Staff a = new Staff(111111, "Marie", "Curie", Researcher.Title.Dr, Researcher.Campus.Launceston, 7000.0);

        static void Main(string[] args)
        {

            a.Positions.Add(new Position(111111, Position.EmploymentLevel.C, new DateTime(2020, 3, 20), new DateTime(2020, 12, 31)));
            a.Positions.Add(new Position(111111, Position.EmploymentLevel.B, new DateTime(2021, 1, 1), new DateTime(2022, 1, 1)));
            a.Positions.Add(new Position(111111, Position.EmploymentLevel.A, new DateTime(2022, 1, 2), DateTime.Now));

            a.Publications.Add(new Publication("A", "430211", Publication.OutputType.Journal, new DateTime(2020, 4, 1), new DateTime(2020, 4, 1), Publication.RankingQ1.Q1));
            a.Publications.Add(new Publication("B", "123121", Publication.OutputType.Other, new DateTime(2021, 4, 1), new DateTime(2021, 4, 1), Publication.RankingQ1.Q3));
            a.Publications.Add(new Publication("C", "103901", Publication.OutputType.Conference, new DateTime(2022, 12, 1), new DateTime(2022, 12, 1), Publication.RankingQ1.Q1));
            a.Publications.Add(new Publication("D", "129010", Publication.OutputType.Conference, new DateTime(2023, 4, 1), new DateTime(2023, 4, 1), Publication.RankingQ1.Q2));

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

            Console.WriteLine("Publication count");
            Console.WriteLine(a.GetPublicationCount());
            Console.WriteLine("Tenure");
            Console.WriteLine(a.Tenure);
            Console.WriteLine("3 Year Average");
            Console.WriteLine(a.ThreeYearAverage);
            Console.WriteLine("Q1");
            Console.WriteLine(a.GetQ1Percentage() + "%");
            Console.WriteLine("Performance 3 year");
            Console.WriteLine(a.Performance3Year + "%");
            Console.WriteLine("Performance By Publication");
            Console.WriteLine(a.GetPerformanceByPublication() + " publications per year");
            Console.WriteLine("Performance By Funding");
            //Console.WriteLine(a.GetPerformanceByFunding() + " AUD per year");

        }
    }
}
