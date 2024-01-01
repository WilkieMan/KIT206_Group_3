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
        /// 
        /// </summary>
        /// <param name="publications"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<Publication> SearchByTitle(List<Publication> publications, string query)
        {
            var pubsByTitle = from p in publications
                              where p.Title.ToLower().Contains(query)
                              select p;

            return new List<Publication>(pubsByTitle);
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="researcher"></param>
        /// <param name="publications"></param>
        /// <returns></returns>
        public static List<Publication> SearchByResearcher(string researcher, List<Publication> publications)
        {
            var pubsByAuthor = from p in publications
                               from author in p.Authors  
                               where author.ToLower().Contains(researcher)
                               select p;

            return (List<Publication>)pubsByAuthor.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publications"></param>
        /// <returns></returns>
        public List<Publication> Sort(List<Publication> publications)
        {
            var sortedYearPublications = publications.OrderBy(p => p.YearOfPublication);

            return new List<Publication>(sortedYearPublications);
        }
    }
}


