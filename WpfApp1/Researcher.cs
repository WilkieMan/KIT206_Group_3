﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static KIT206_RAP.Researcher;

namespace KIT206_RAP
{
    internal class Researcher
    {
        public int ID { get; set; }                                             //Researcher ID
        public string GivenName { get; set; }                                   //Researcher given name
        public string FamilyName { get; set; }                                  //Researcher family name                                                    
        public string Unit { get; set; }                                        //Researcher school/Unit
        public Title NameTitle { get; set; }                                    //Researcher title
        public Campus CampusName { get; set; }                                  //Researcher working campus base
        public string Email { get; set; }                                       //Researcher email
        public string Photo { get; set; }                                       //Researcher photo (URL Type)   
        public Position.EmploymentLevel EmploymentLevel { get; set; }           //Researcher current employment level
        public List<Publication> Publications = new List<Publication>();        //Publications list of researcher
        public List<CummulativeCount> CummulativeCounts = new List<CummulativeCount>();         //Researcher's publications in each year
        public List<Position> Positions = new List<Position>();                 //Past and current positions of researcher

        public enum Title { Dr, Prof, Mr, Mrs, Miss, Ms, Prov, Rev }
        public enum Campus { CradleCoast, Hobart, Launceston };
        public DateTime InstitutionStart { get; set; }
        public DateTime CurrentStart { get; set; }

        public string ToBasicName()
        {
            return FamilyName + ", " + GivenName + " (" + NameTitle + ")";
        }

        public Researcher(int id, string givenName, string familyName, Title title, Campus campus)
        {
            ID = id;
            GivenName = givenName;
            FamilyName = familyName;
            NameTitle = title;
            CampusName = campus;
        }

        public Researcher(Title title, string givenName, string familyName, Position.EmploymentLevel employmentLevel, int id)
        {
            ID = id;
            GivenName = givenName;
            FamilyName = familyName;
            NameTitle = title;
            EmploymentLevel = employmentLevel;
        }

        public double GetQ1Percentage()
        {
            double Q1Number = 0.0;

            foreach (Publication p in Publications)
            {
                if (p.Ranking == Publication.JournalRanking.Q1)
                {
                    Q1Number++;
                }
            }

            return Math.Round(100 * (Q1Number / GetPublicationCount()), 1);
        }

        //Researcher publication count
        public int GetPublicationCount()
        {
            return Publications == null ? 0 : Publications.Count();
        }

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

        public void AddPublication(Publication publication)
        {
            Publications.Add(publication);
        }
        public void AddPosition(Position position)
        {
            Positions.Add(position);
        }

    }
}
