using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KIT206_RAP.Researcher;

namespace KIT206_RAP
{
      namespace Researcher
    {
        //Three year average of publications for reseacher

        public double threeYearAverage
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
        }

        //Performance of researcher 

        public double getPerformance
        {
            get
            {
                if (Type == "Staff")
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
    internal class Staff : Researcher
    {
        public enum Performance {A, B, C, D, E }
        private double year3Avergae, fundingReceived;
        private int supervisions;
        public Performance performanceByPublication;
        public Performance performanceByFunding;

        public Staff(Title title, string givenName, string familyName, EmploymentLevel employmentLevel, int id) : base(title, givenName, familyName, employmentLevel, id)
        {
            
        }
    }
}
