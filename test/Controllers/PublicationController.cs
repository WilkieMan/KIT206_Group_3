using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class PublicationsController
    {
        /// <summary>
        /// Takes a list of publications and searches their titles for a provided query. 
        /// </summary>
        /// <param name="publications">The list of queried publications.</param>
        /// <param name="query">The string query.</param>
        /// <returns>
        /// A list of publications with satisfy the query.
        /// </returns>
        public static List<Publication> SearchByTitle(List<Publication> publications, string query)
        {
            var pubsByTitle = from p in publications
                              where p.Title.ToLower().Contains(query.ToLower())
                              select p;

            return new List<Publication>(pubsByTitle);
        }

        /// <summary>
        /// Checks if a list of publications for if their author contains a certain string.
        /// </summary>
        /// <param name="publications">The list of publications to check.</param>
        /// <param name="query">The string to query against the authors.</param>
        /// <returns>
        /// A list of publications that satisfy the query.
        /// </returns>
        public static List<Publication> SearchByResearcher(List<Publication> publications, string query)
        {
            var pubsByAuthor = from p in publications
                               from author in p.Authors
                               where author.ToLower().Contains(query.ToLower())
                               select p;

            return (List<Publication>)pubsByAuthor.ToList();
        }

        /// <summary>
        /// Sorts a list of publications by publication date.
        /// </summary>
        /// <param name="publications">The list of publications to sort.</param>
        /// <returns>
        /// The sorted list of publications.
        /// </returns>
        public List<Publication> OldestToNewest(List<Publication> publications)
        {
            var sortedYearPublications = publications.OrderBy(p => p.YearOfPublication);

            return new List<Publication>(sortedYearPublications);
        }

        public List<Publication> NewestToOldest(List<Publication> publications)
        {
            var sortedYearPublications = publications.OrderByDescending(p => p.YearOfPublication);

            return new List<Publication>(sortedYearPublications);
        }

        public List<Publication> FilterByYears(List<Publication> publications, DateTime UpperLimit, DateTime LowerLimit)
        {
            var sortedYearPublications = from p in publications
                                         where (new DateTime(p.YearOfPublication, 1,1) < UpperLimit) && (new DateTime(p.YearOfPublication, 1, 1) > LowerLimit)
                                         select p;

            return new List<Publication>(sortedYearPublications);

        }

    }
}
