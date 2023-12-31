﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class Researcher
    {
        public int ID { get; set; }                                                                     // Researcher ID
        public string GivenName { get; set; }                                                           // Researcher Given name
        public string FamilyName { get; set; }                                                          // Researcher Family name                                                   
        public string Unit { get; set; }                                                                // Researcher School
        public Title NameTitle { get; set; }                                                            // The honorific of the researcher 
        public Campus CampusName { get; set; }                                                          // Researcher's working campus 
        public string Email { get; set; }                                                               // Researcher's email
        public string Photo { get; set; }                                                               // Researcher Photo (URL Type) 
        public Position.EmploymentLevel EmploymentLevel { get; set; }                                   // The current employment level of the researcher
        public List<Publication> Publications = new List<Publication>();                                // Publications list of researcher
        public List<CummulativeCount> CummulativeCounts = new List<CummulativeCount>();                 // A list used to hold cumulative counts 
        public enum Title { Dr, Prof, Mr, Mrs, Miss, Ms, Prov, Rev }                                    // A list of honorifics
        public enum Campus { CradleCoast, Hobart, Launceston };                                         // A list of UTas campus' that the researcher can work at
        public DateTime InstitutionStart { get; set; }                                                  // The date the researcher started at the current institution
        public DateTime CurrentStart { get; set; }                                                      // The date the researcher started their current position
        public List<Position> Positions = new List<Position>();                                         // A list of previous positions they have held at the current institution
        public PublicationsController publicationsController = new PublicationsController();            // A controller for the publications
        
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
        public string Q1Percentage                                                          //The researcher's Q1 percentage
        {
            get
            {
                double Q1Number = 0.0;

                foreach (Publication p in Publications)
                {
                    if (p.Ranking == Publication.JournalRanking.Q1)
                    {
                        Q1Number++;
                    }
                }

                Q1Number = Math.Round(100 * Q1Number / Publications.Count, 1);

                string Q1String = Q1Number.ToString();

                return Q1String + "%";
            }
        }

        /// <summary>
        /// The length of time in fractional years since they started at UTas
        /// </summary>
        /// Written by Sumaiya
        public double Tenure                                                          //The researcher's tenure
        {
            get
            {
                double daysInYear = 365.0;
            
                return Math.Round((DateTime.Today.Subtract(InstitutionStart)).Days / daysInYear, 1);
            }
        }

        public int PublicationCount                                                          //The number of publications the researcher has published
        {
            get
            {
                return Publications.Count;
            }
        }

        /// <summary>
        /// Populates a list with list of publications that ordered by year.
        /// </summary>
        /// <param name="publications">The researchers publications.</param>
        public void PopulateCummulatives(List<Publication> publications)
        {
            bool found = false;
            publications = publicationsController.OldestToNewest(publications);

            //sort every publication
            foreach (Publication p in publications)
            {
                if (CummulativeCounts.Count == 0) //if the list is empty
                {
                    CummulativeCounts.Add(new CummulativeCount(p.YearOfPublication)); //make new instance
                } 
                
                //while the publication has not been placed
                while (found == false)
                {
                    foreach (CummulativeCount c in CummulativeCounts)
                    {
                        if (c.Year == p.YearOfPublication)
                        {
                            c.publications.Add(p);
                            found = true;
                        } 
                    }

                    //if the year did not aleady exist
                    if (found == false)
                    {
                        CummulativeCounts.Add(new CummulativeCount(p.YearOfPublication));

                        foreach (CummulativeCount c in CummulativeCounts)
                        {
                            if (c.Year == p.YearOfPublication)
                            {
                                c.publications.Add(p);
                                found = true;
                            }
                        }
                    }
                }

                //reset
                found = false;
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