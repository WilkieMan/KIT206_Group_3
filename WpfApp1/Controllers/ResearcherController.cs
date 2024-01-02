using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
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
                Console.WriteLine(researcher.ToBasicName());
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Displays a list of researchers. 
        /// </summary>
        /// <param name="list">The list of researchers to display.</param>
        public void DisplayList(List<Researcher> list)
        {
            foreach (Researcher researcher in list)
            {
                Console.WriteLine(researcher.ToBasicName());
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
            var supervisions = from Student s in MasterList
                               where s.SupervisorID == id
                               select s;

            return new List<Student>(supervisions);
        }

        public void GetCummulativeCount()
        {

        }

        //fix
        /*//Cummulative publication count for researcher
        public List<string> displayCommulativePublicationCount
        {
            get
            {
                int commulativeCount = 0;
                List<string> Commulative = new List<string>();

                for (int i = EarliestJobStart.Year; i <= (DateTime.Today.Year); i++)
                {
                    foreach (Publication t in Publications)
                    {
                        if (t.Year == i)
                        {
                            commulativeCount++;
                        }
                    }

                    Commulative.Add("Commulative count in " + i + " is: " + commulativeCount);
                }

                return Commulative;
            }*/

    }

}