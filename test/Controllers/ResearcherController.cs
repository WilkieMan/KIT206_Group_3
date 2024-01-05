using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class ResearcherController
    {
        private static List<Researcher> MasterList = DBAdapter.FetchBasicResearcher(); // A list of all the researchers and their query-able details.
        // private static List<Researcher> MasterList = FakeReasearcherData.Generate();
        private List<Researcher> ModifiedList = MasterList; // A list to be manipulated 

        /// <summary>
        /// Prints the short hand version of the researchers in the current/modified list.
        /// </summary>
        public void DisplayCurrentList()
        {
            foreach (Researcher researcher in ModifiedList)
            {
                Console.WriteLine(researcher);
            }

            Console.WriteLine();
        }

        public List<Researcher> GetMasterList()
        {
            return Alphabetise(MasterList);
        }

        /// <summary>
        /// Displays a list of researchers. 
        /// </summary>
        /// <param name="list">The list of researchers to display.</param>
        public void DisplayList(List<Researcher> list)
        {
            foreach (Researcher researcher in list)
            {
                Console.WriteLine(researcher);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Sorts a list of researchers alphabetically by family name.
        /// </summary>
        /// <param name="researchers">The list to be sorted.</param>
        /// <returns>The sorted list.</returns>
        public List<Researcher> Alphabetise(List<Researcher> researchers)
        {
            var sortedResearcher = researchers.OrderBy(r => r.FamilyName);

            return new List<Researcher>(sortedResearcher);
        }

        /// <summary>
        /// Filters a researcher list by employment level.
        /// </summary>
        /// <param name="researchers">The list of researchers to be sorted.</param>
        /// <param name="employmentLevel">The employment level to filter by.</param>
        /// <returns>
        /// A filtered list of researchers
        /// </returns>
        public List<Researcher> FilterByJobTitle(List<Researcher> researchers, Position.EmploymentLevel employmentLevel)
        {

            if (employmentLevel == Position.EmploymentLevel.Any)
            {
                return researchers;
            }

            var temp = from Researcher r in researchers
                       where r.EmploymentLevel == employmentLevel
                       select r;

            return new List<Researcher>(temp);
        }

        /// <summary>
        /// Filters a researcher list by name.
        /// </summary>
        /// <param name="researchers">The list of researchers to filter.</param>
        /// <param name="query">The query to filter against their names</param>
        /// <returns>
        /// A list of researchers filtered by name.
        /// </returns>
        public List<Researcher> FilterByName(List<Researcher> researchers, string query)
        {
            if (query == null)
            {
                return researchers;
            }

            var searchResults = from Researcher r in researchers
                                where r.GivenName.ToLower().Contains(query.ToLower()) || r.FamilyName.ToLower().Contains(query.ToLower())
                                select r;

            return new List<Researcher>(searchResults);
        }

        /// <summary>
        /// Returns a list of students that are supervised by a staff.
        /// </summary>
        /// <param name="id">The ID of the staff member.</param>
        /// <returns>
        /// The students that are under that staff members supervision
        /// </returns>
        public static List<Student> GetSupervisions(int id)
        {
            var students = from Researcher r in MasterList
                           where r.EmploymentLevel == Position.EmploymentLevel.Student
                           select r;

            var supervisions = from Student s in students
                               where s.SupervisorID == id
                               select s;

            return new List<Student>(supervisions);
        }

        /// <summary>
        /// Returns the supervisor based on their ID
        /// </summary>
        /// <param name="id"></param>
        /// The researher object
        /// <returns></returns>
        public static Researcher GetSupervisor(int id)
        {
            foreach (Researcher r in MasterList)
            {
                if (r.ID == id)
                {
                    {
                        return r;
                    }
                }
            }

            return null;
        }


        /// <summary>
        /// Generates the reports of each resercher's perormance
        /// </summary>
        /// <param name="performance"></param>
        /// <returns>
        /// List of the researchers in the required bracket
        /// </returns>
        public List<Staff> GenerateReports(string performance)
        {

            double poor = 70.0;
            double belowExpectation = 110.0;
            double minimum = 110.0;
            double star = 200.0;
            List<Staff> staffList = new List<Staff>();

            foreach (Researcher r in MasterList)
            {
                if (r.EmploymentLevel != Position.EmploymentLevel.Student)
                {
                    Staff s = new Staff(r.NameTitle, r.GivenName, r.FamilyName, r.EmploymentLevel, r.ID);
                    staffList.Add(s);
                }
            }
            
            switch (performance) 
            {
                case "poor":
                    var poorPerformers = from Staff s in staffList
                                         where s.Performance3Year <= poor
                                         select s;
                    return new List<Staff>(poorPerformers);
                case "below expectation":
                    var belowExpectationPerformers = from Staff s in staffList
                                                     where s.Performance3Year > poor && s.Performance3Year < belowExpectation
                                                     select s;
                    return new List<Staff>(belowExpectationPerformers);
                case "meeting minimum":
                    var meetingMinimumPerformers = from Staff s in staffList
                                                   where s.Performance3Year > minimum && s.Performance3Year < star
                                                   select s;
                    return new List<Staff>(meetingMinimumPerformers);
                default:
                    var starPerformers = from Staff s in staffList
                                         where s.Performance3Year >= star
                                         select s;
                    return new List<Staff>(starPerformers);
            }


        }

    }
}
