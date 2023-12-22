using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class Publication
    {
       
        public string DOI { get; set; }
        public string Title { get; set; }
        public string CiteAs { get; set; }
        public List<string> Authors { get; set; }
        public OutputType Type { get; set; }
        public string YearOfPublication { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime Year { get; set; }
        public OutputRanking Ranking { get; set; }

        public enum OutputType { Conference, Journal, Other };
        public enum OutputRanking { Q1, Q2, Q3, Q4 };

        public void AddAuthorNames(string author)
        {
            Authors.Add(author);
        }

        public string ToBasicInfo()
        {
            return DOI + " - " + Title + " - " + Authors[0] + "et. al";
        }

        public Publication(string title, string doi)
        {
            this.Title = title;
            this.DOI = doi;
        }

        public int Age()
        {
            return 1; //fiinish
        }
    }
}

