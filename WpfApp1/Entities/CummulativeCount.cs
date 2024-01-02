using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    class CummulativeCount
    {
        public DateTime Year { get; set; } // The year this cumulative count represents 
        public List<Publication> publications = new List<Publication>(); // The list of publications published in this year 

        /// <summary>
        /// Cumulative count constructor.
        /// </summary>
        /// <param name="year">The year of this cumulative count</param>
        public CummulativeCount(DateTime year)
        {
            Year = year;
        }

        /// <summary>
        /// Adds a publication to the cumulative count.
        /// </summary>
        /// <param name="publication">The publication to add.</param>
        public void AddPublication(Publication publication)
        {
            publications.Add(publication);
        }

        /// <summary>
        /// Returns the number of publications in this cumulative count.
        /// </summary>
        /// <returns>
        /// An int of the number of publications.
        /// </returns>
        public int NumberOfPublications()
        {
            return publications.Count;
        }
    }
}
