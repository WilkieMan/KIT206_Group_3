using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
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
        public List<Publication> Sort(List<Publication> publications)
        {
            var sortedYearPublications = publications.OrderBy(p => p.YearOfPublication);

            return new List<Publication>(sortedYearPublications);
        }
    }
}


