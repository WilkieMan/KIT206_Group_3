using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KIT206_RAP.Researcher;

namespace KIT206_RAP
{
    internal class Staff : Researcher
    {
        //Three year average of publications for reseacher
        public List<Student> SupervisionsList;         //Supervision list of researcher (If available)     
        public int SupervisionsCount = 0;
        private double threeYearAverage, FundingReceived;
        public Performance PerformanceByPublication;
        public Performance PerformanceByFunding;
        List<int> FundingList;
        double FundingToMaintain;
        public Staff(int id, string givenName, string FamilyName, Title title, Campus campus, Position.EmploymentLevel employmentLevel, List<int> fundingList, double fundingToMaintain) : base(id, givenName, FamilyName, title, campus, employmentLevel)
        {
            ID = id;
            GivenName = givenName;
            NameTitle = title;
            CampusName = campus;
            EmploymentLevel = employmentLevel;
            FundingList = fundingList;
            FundingToMaintain = fundingToMaintain;
        }

        public enum Performance { A, B, C, D, E }

        public void PopulateSupervisionsList()
        {
            SupervisionsList = ResearcherController.getSupervisions(this.ID);
            SupervisionsCount = SupervisionsList.Count();
        } 

       /*public double threeYearAverage
        {
            get
            {
                double threeYearPublicationCount = 0.0;

                foreach (Publication t in Publications)
                {
                    if ((t.Year >= (DateTime.Today.Year - 3)) && (t.Year <= (DateTime.Today.Year - 1)))
                    {
                        threeYearPublicationCount++;
                    }
                }

                return Math.Round(threeYearPublicationCount / 3, 1);
            }
        }*/

        //Performance of researcher 
        
        public double getPerformance
        {
            get
            {
                double realPublications = threeYearAverage;
                double expectedPublications;

                    switch (Level)
                    {
                        case EmploymentLevel.A:
                            expectedPublications = 0.5;
                            break;
                        case EmploymentLevel.B:
                            expectedPublications = 1;
                            break;
                        case EmploymentLevel.C:
                            expectedPublications = 2;
                            break;
                        case EmploymentLevel.D:
                            expectedPublications = 3;
                            break;
                        default:
                            expectedPublications = 4;
                            break;
                    }

                    return (Math.Round(100 * (realPublications / expectedPublications), 1));
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
