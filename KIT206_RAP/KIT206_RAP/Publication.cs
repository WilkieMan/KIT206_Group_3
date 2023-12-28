using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
     //Enum type for Output type
    public enum Type { Conference, Journal, Other };
    
    internal class Publication
    {
       
        public string DOI { get; set; }
        public string Title { get; set; }
        public string CiteAs { get; set; }
        public List<string> Authors { get; set; }
        public OutputType Type { get; set; }
        public DateTime YearOfPublication { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime Year { get; set; }
        public Researcher.Q1Percentage Ranking { get; set; }

        public enum OutputType { Conference, Journal, Other };

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
            TimeSpan difference = DateTime.Now - AvailableFrom;

            return difference.Days;
        }
      
        //ToString method to present publication
        public override string ToString()
        {
            return Title + " Finilised By " + Type + " on " + AvailableFrom.ToShortDateString();
        }

            //method to display information  of a publication
        public string ToDetailedString()
        {
            return String.Format("DOI: {0} \n" +
                                 "Title: {1} \n" +
                                 "Authors: {2} \n" +
                                 "Year: {3} \n" +
                                 "Type: {4} \n" +
                                 "Cite as: {5} \n" +
                                 "Available date: {6} \n" +
                                 "Age: {7} day(s)", DOI, Title, Authors, Year, Type, CiteAs, AvailableFrom.ToString("dd-MM-yyyy"), Age());
        }
    }
}

