﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Researcher
    {
        public int ID { get; set; } // Researcher ID
        public string GivenName { get; set; } // Researcher Given name
        public string FamilyName { get; set; } // Researcher Family name                                                   
        public string Unit { get; set; } // Researcher School
        public Title NameTitle { get; set; } // The honorific of the researcher 
        public Campus CampusName { get; set; } // Researcher's working campus 
        public string Email { get; set; } // Researcher's email
        public string Photo { get; set; } // Researcher Photo (URL Type) 
        public Position.EmploymentLevel EmploymentLevel { get; set; } // The current employment level of the researcher
        public List<Publication> Publications = new List<Publication>(); // Publications list of researcher
        public List<CummulativeCount> CummulativeCounts = new List<CummulativeCount>(); // A list used to hold cumulative counts 
        public enum Title { Dr, Prof, Mr, Mrs, Miss, Ms, Prov, Rev } // A list of honorifics
        public enum Campus { CradleCoast, Hobart, Launceston }; // A list of UTas campus' that the researcher can work at
        public DateTime InstitutionStart { get; set; } // The date the researcher started at the current institution
        public DateTime CurrentStart { get; set; } // The date the researcher started their current position
        public List<Position> Positions = new List<Position>(); // A list of previous positions they have held at the current institution
        public PublicationsController publicationsController = new PublicationsController();
        /// <summary>
        /// Creates a string of their name and honorific to use in a list.
        /// </summary>
        /// <returns>
        /// A string for use in lists.
        /// </returns>
        public override string ToString()
        {
            return FamilyName + ", " + GivenName + " (" + NameTitle + ")";
        }
        


        /// <summary>
        /// The constructor for a researcher object. 
        /// </summary>
        /// <param name="title">Their honorific</param>
        /// <param name="givenName">Their given name.</param>
        /// <param name="familyName">Their family name</param>
        /// <param name="employmentLevel">Their current employment level</param>
        /// <param name="id">Their institution ID</param>
        public Researcher(Title title, string givenName, string familyName, Position.EmploymentLevel employmentLevel, int id)
        {
            ID = id;
            GivenName = givenName;
            FamilyName = familyName;
            NameTitle = title;
            EmploymentLevel = employmentLevel;
        }

        /// <summary>
        /// Calculates the percentage of publications that are published in Q1 journals.
        /// </summary>
        /// <returns>
        /// A double indicating a percentage.
        /// </returns>
        public double Q1Percentage()
        {
            double Q1Number = 0.0;

            foreach (Publication p in Publications)
            {
                if (p.Ranking == Publication.JournalRanking.Q1)
                {
                    Q1Number++;
                }
            }

            return 100 * (Q1Number / GetPublicationCount());
        }

        /// <summary>
        /// Calculates the number of publications the researcher has published.
        /// </summary>
        /// <returns>
        /// The number of publications.
        /// </returns>
        public int GetPublicationCount()
        {
            return Publications == null ? 0 : Publications.Count();
        }

        /// <summary>
        /// Populates a list with list of publications that ordered by year.
        /// </summary>
        /// <param name="publications">The researchers publications.</param>
        public void PopulateCummulatives(List<Publication> publications)
        {
            foreach (Publication p in publications)
            {
                DateTime PublicationYear = DateTime.Parse(p.YearOfPublication.ToString());

                if (CummulativeCounts.Count == 0)
                {
                    CummulativeCounts.Add(new CummulativeCount(DateTime.Parse(p.YearOfPublication.ToString())));
                }

                foreach (CummulativeCount c in CummulativeCounts)
                {
                    if (c.Year.Year == p.YearOfPublication)
                    {
                        c.publications.Add(p);
                    }
                    else
                    {
                        CummulativeCounts.Add(new CummulativeCount(DateTime.Parse(p.YearOfPublication.ToString())));
                        c.publications.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a publication to the researchers list.
        /// </summary>
        /// <param name="publication">The publication to be added.</param>
        public void AddPublication(Publication publication)
        {

            Publications.Add(publication);
            Publications = publicationsController.NewestToOldest(Publications);
        }

        /// <summary>
        /// Adds a previous position to a researcher.
        /// </summary>
        /// <param name="position">The previous position to be added.</param>
        public void AddPosition(Position position)
        {
            Positions.Add(position);
        }
    }
}