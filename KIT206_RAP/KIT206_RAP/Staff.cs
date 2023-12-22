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
        private double FundingReceived;
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
            SupervisionsList = ResearcherController.GetSupervisions(this.ID);
            SupervisionsCount = SupervisionsList.Count();
        }

        /*public double ThreeYearAverage
        {
            get
            {
                double ThreeYearPublicationCount = 0.0;
                int CurrentYear = DateTime.Now.Year;

                foreach (Publication t in Publications)
                {
                    int PublicationYear = t.Year;

                    if (PublicationYear >= (CurrentYear - 3)) & (PublicationYear <= (CurrentYear - 1))
                    {
                        ThreeYearPublicationCount++;
                    }
                }

                return Math.Round(ThreeYearPublicationCount / 3, 1);
            }
        }

    

        //Performance of researcher 
        public double GetPerformanceByPublication
        {
            get
            {
                double realPublications = ThreeYearAverage;
                double expectedPublications;

                    switch (EmploymentLevel)
                    {
                        case Position.EmploymentLevel.A:
                            expectedPublications = 0.5;
                            break;
                        case Position.EmploymentLevel.B:
                            expectedPublications = 1;
                            break;
                        case Position.EmploymentLevel.C:
                            expectedPublications = 2;
                            break;
                        case Position.EmploymentLevel.D:
                            expectedPublications = 3;
                            break;
                        default:
                            expectedPublications = 4;
                            break;
                    }

                    return (Math.Round(100 * (realPublications / expectedPublications), 1));
                
            }
        }*/

        public double GetPerformanceByFunding()
        {
            return 0.0; //finish
        }


        //staff also need a table of all previous positions
    }
}
