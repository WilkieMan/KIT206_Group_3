using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test.Researcher;

namespace test
{
    internal class Staff : Researcher
    {
        public List<Student> SupervisionsList; // Supervision list of researcher (If available)     
        public int SupervisionsCount = 0; // The number of supervisions they have
        int FundingToMaintin = 0;

        /// <summary>
        /// Staff constructor.
        /// </summary>
        /// <param name="title">The honorific of the staff member.</param>
        /// <param name="givenName">The given name of the staff member.</param>
        /// <param name="familyName">The family name of the staff member.</param>
        /// <param name="employmentLevel">The employment level of the staff member.</param>
        /// <param name="id">The UTas ID of the staff member.</param>
        public Staff(Title title, string givenName, string familyName, Position.EmploymentLevel employmentLevel, int id/*, double fundingToMaintain*/) : base(title, givenName, familyName, employmentLevel, id)
        {
            ID = id;
            GivenName = givenName;
            NameTitle = title;
            EmploymentLevel = employmentLevel;
            FamilyName = familyName;
        }

        public string Funding
        {
            get
            {
                if (FundingToMaintin == 0)
                {
                    return "No funding data available.";
                }

                return FundingToMaintin.ToString() + " AUD";
            }
        }

        /// <summary>
        /// Populates the staff's supervisions using information that is already known.
        /// </summary>
        public List<Student> GetSupervisionsList()
        {
            SupervisionsList = ResearcherController.GetSupervisions(ID);
            SupervisionsCount = SupervisionsList.Count();

            return SupervisionsList;
        }

        /// <summary>
        /// The average number of publications produced per year for the last 3 years.
        /// </summary>
        public double ThreeYearAverage
        {
            get
            {
                double ThreeYearPublicationCount = 0.0;
                DateTime Current = DateTime.Now;

                foreach (Publication t in Publications)
                {
                    DateTime PublicationYear = DateTime.Parse("1/1/" + t.YearOfPublication.ToString());

                    if (PublicationYear.Year >= Current.AddYears(-3).Year)
                    {
                        ThreeYearPublicationCount++;
                    }
                }

                return Math.Round(ThreeYearPublicationCount / 3, 1);
            }
        }

        /// <summary>
        /// A percentage representing the percent of expected publications produced per year over the last 3 years.
        /// </summary>
        /// Written by Sumaiya
        public double Performance3Year
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
        }

        /// <summary>
        /// The number of publications produced per year over their entire tenure.
        /// </summary>
        /// <returns>
        /// The number of publications per year.
        /// </returns>
        public string PerformanceByPublication
        {
            get
            {
                string performance = Math.Round((Publications.Count / Tenure),1).ToString();

                return performance + " publications/yr";
            }
         }

        /// <summary>
        /// The amount of funding received per year for their entire tenure. 
        /// </summary>
        /// <returns>
        /// The amount of funding received per year.
        /// </returns>
        public string PerformanceByFunding
        {
            get
            {
                double TotalFunding = 0.0;

                foreach (Publication p in Publications)
                {
                    TotalFunding += p.Funding;
                } 

                if (TotalFunding == 0.0)
                {
                    return "No funding data available.";
                } else
                {
                    return (Math.Round((TotalFunding / Tenure), 1)).ToString() + " AUD/yr"; 
                }
            }
        }

        /// <summary>
        /// Returns the date they started their current job.
        /// </summary>
        /// Written by Sumaiya
        public DateTime CurrentJobStart                                         //Date of current position of researcher
        {
            get
            {
                var currentJob = from Position p in Positions
                                 orderby p.Start descending
                                 select p;

                return currentJob.First().Start;
            }
        }
    }
}
