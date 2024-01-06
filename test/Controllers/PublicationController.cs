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
        /// Sorts a list of publications by publication date from oldest to newest.
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

        /// <summary>
        /// Sorts a list of publications by publication date from newest to oldest.
        /// </summary>
        /// <param name="publications">The list of publications to sort.</param>
        /// <returns>
        /// The sorted list of publications.
        /// </returns>
        public List<Publication> NewestToOldest(List<Publication> publications)
        {
            var sortedYearPublications = publications.OrderByDescending(p => p.YearOfPublication);

            return new List<Publication>(sortedYearPublications);
        }

        /// <summary>
        /// Filters a list of publications by publication date using an upper and lower limit.
        /// </summary>
        /// <param name="publications">The list of publications to filter</param>
        /// <param name="UpperLimit">The largest year to filter by</param>
        /// <param name="LowerLimit">The smallest year to filter by</param>
        /// <returns>
        /// The filtered list of publications.
        /// </returns>
        public List<Publication> FilterByYears(List<Publication> publications, string upperLimit, string lowerLimit)
        {

            //reset the list if either field is empty
            if (upperLimit == "" || lowerLimit == "")
            {
                return publications;
            }

            //convert to a int
            int upperLimitInt = int.Parse(upperLimit);
            int lowerLimitInt = int.Parse(lowerLimit);

            var sortedYearPublications = from p in publications
                                         where p.YearOfPublication <= upperLimitInt && p.YearOfPublication >= lowerLimitInt
                                         select p;

            return new List<Publication>(sortedYearPublications);
        }
    }
}
