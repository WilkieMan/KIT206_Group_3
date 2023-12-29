using System;
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
        public string GivenName { get; set; }                                   //Researcher Given name
        public string FamilyName { get; set; }                                  //Researcher Family name                                                       //Researcher Title
        public string Unit { get; set; }                                      //Researcher School
        public Title NameTitle { get; set; }
        public Campus CampusName { get; set; }                                      //Researcher working campus base
        public string Email { get; set; }                                       //Researcher email
        public string Photo { get; set; }                                       //Researcher Photo (URL Type)   //Past and current positions of researcher
        public Position.EmploymentLevel EmploymentLevel { get; set; }
        public List<Publication> Publications = new List<Publication>();           //Publications list of researche
        public List<CummulativeCount> CummulativeCounts = new List<CummulativeCount>();

        public enum Title { Dr, Prof, Mr, Mrs, Miss, Ms, Prov, Rev}
        public enum Campus { CradleCoast, Hobart, Launceston };

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

            foreach(Publication p in Publications ) 
            {
                if (p.Ranking == Publication.RankingQ1.Q1)
                {
                    Q1Number++;
                }
            }

            return 100 * (Q1Number / GetPublicationCount());
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
                DateTime PublicationYear = p.YearOfPublication;

                if (CummulativeCounts.Count == 0)
                {
                    CummulativeCounts.Add(new CummulativeCount(p.YearOfPublication));
                }

                foreach (CummulativeCount c in CummulativeCounts)
                {
                    if (c.Year.Year == p.YearOfPublication.Year)
                    {
                        c.publications.Add(p);
                    } else
                    {
                        CummulativeCounts.Add(new CummulativeCount(p.YearOfPublication));
                        c.publications.Add(p);
                    }
                }
            }
        }
    }
}
