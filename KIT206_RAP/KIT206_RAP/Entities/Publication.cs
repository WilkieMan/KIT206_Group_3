using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    // Enum type for Output type
    
    internal class Publication
    {
       
        public string DOI { get; set; } // The unique identifying string for each publications
        public string Title { get; set; } // The title of the publication
        public string CiteAs { get; set; } // The Cite string of the publication
        public List<string> Authors = new List<string>(); // A list of authors involved in the publication
        public OutputType Type { get; set; } // The type of publication
        public int YearOfPublication { get; set; } // The year the publication was published
        public DateTime AvailableFrom { get; set; } // The date on which the publication was first made available
        public JournalRanking Ranking  { get; set; } // The ranking of the journal the publication was published in

        public enum OutputType { Conference, Journal, Other }; // The types of publications
        public enum JournalRanking { Q1, Q2, Q3, Q4 } // The different journal rankings 
        public double Funding { get; set; } // The amount of funding received for this publications

        /// <summary>
        ///  This method adds an author to the list of authors for a given publication.
        /// </summary>
        /// <param name="author">the author to be added.</param>
        public void AddAuthorNames(string author)
        {
            Authors.Add(author);
        }

        /// <summary>
        /// Takes the basic information of the publication and turns it into a concise string to be displayed in a list of publications.
        /// </summary>
        /// <returns>
        /// A string that describes the publication.
        /// </returns>
        public string ToBasicInfo()
        {
            return DOI + " - " + Title + " - " + Authors[0] + "et. al";
        }

        /// <summary>
        /// Creates a publication from the basic information that every publication has to have.
        /// </summary>
        /// <param name="title">The title of the publication.</param>
        /// <param name="doi">The unique string identifier.</param>
        /// <param name="type">The type of publication that it is.</param>
        /// <param name="yearOfPublication">The year the publication was first published.</param>
        /// <param name="availableFrom">The date the publication was publicly available from.</param>
        /// <param name="ranking">The ranking of the journal the publication was published in.</param>
        /// <param name="authors">A list of strings denoting the authors of the publication.</param>
        /// <param name="citeAs">A string for what someone should cite the publication as.</param>
        public Publication(string title, string doi, OutputType type, int yearOfPublication, DateTime availableFrom, JournalRanking ranking, List<String> authors, String citeAs)
        {
            Title = title;
            DOI = doi;
            Type = type;
            YearOfPublication = yearOfPublication;
            AvailableFrom = availableFrom;
            Ranking = ranking;
            Authors = authors;
            CiteAs = citeAs;
            Funding = 0;

        }

        /// <summary>
        /// Calculates the age of the publication in days
        /// </summary>
        /// <returns>
        /// An int of the number of days since it was first available.
        /// </returns>
        public int Age()
        {
            TimeSpan difference = DateTime.Now - AvailableFrom;

            return difference.Days;
        }
      
        /// <summary>
        /// Makes a string of the publication.
        /// </summary>
        /// <returns>
        /// A string representing the publication.
        /// </returns>
        public override string ToString()
        {
            return Title + " Finilised By " + Type + " on " + AvailableFrom.ToShortDateString();
        }

        /// <summary>
        /// Makes a much more in depth representation of the publication.
        /// </summary>
        /// <returns>
        /// A string of all the publications details.
        /// </returns>
        public string ToDetailedString()
        {
            return String.Format("DOI: {0} \n" +
                                 "Title: {1} \n" +
                                 "Authors: {2} et. al \n" +
                                 "Year: {3} \n" +
                                 "Type: {4} \n" +
                                 "Cite as: {5} \n" +
                                 "Available date: {6} \n" +
                                 "Age: {7} day(s)", DOI, Title, Authors[0], YearOfPublication, Type, CiteAs, AvailableFrom.ToString("dd-MM-yyyy"), Age());
        }
    }
}

