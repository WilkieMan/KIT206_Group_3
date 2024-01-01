using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class PublicationsController
    {
        public enum PerformanceLevel
        {
            Poor, Below_Average, Average, Good, Excellent
        }

        private static List<Publication> publications;

        /*public static List<Publication> LoadAllPublications()
          {
            publications = DBAdapter.LoadAll();
            if (publications != null)
            {
                return publications;
            }
                return null;
          }*/

        public static List<Publication> SearchByTitle()
        {
            Console.Write("Enter publication title: ");
            string searchText = Console.ReadLine().ToLower();

            var pubsByTitle = from pub in publications
                              where pub.Title.ToLower().Contains(searchText)
                              select pub;

            return new List<Publication>(pubsByTitle);
        }



        public static List<Publication> SearchByResearcher(string researcher)
        {

            var pubsByAuthor = from pub in publications
                               from author in pub.Authors  // nested LINQ as there is a list within a list
                               where author.ToLower().Contains(researcher)
                               select pub;

            return (List<Publication>)pubsByAuthor.ToList(); // dynamic typed variable has to be converted(casted) into a strong type (List<Publication>) before return

        }

        public List<Publication> Sort(List<Publication> publications)
        {
            var sortedYearPublications = publications.OrderBy(p => p.YearOfPublication);

            return new List<Publication>(sortedYearPublications);
        }

    }
}


