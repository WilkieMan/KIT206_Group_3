using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    class CummulativeCount
    {
        public DateTime Year { get; set; }
        public List<Publication> publications = new List<Publication>();

        public CummulativeCount(DateTime year)
        {
            Year = year;
        }
    }

}
