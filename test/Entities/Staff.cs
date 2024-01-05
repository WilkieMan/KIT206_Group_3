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
        public string funding = null;

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
            // FundingToMaintain = fundingToMaintain;
        }

        /// <summary>
        /// The length of time in fractional years since they started at UTas
        /// </summary>
        public double Tenure
        {
            get
            {
                double daysInYear = 365.0;
                // System.Console.WriteLine(Positions.Count());
                // System.Console.WriteLine(EarliestJobStart.ToString());
                return Math.Round((DateTime.Today.Subtract(EarliestJobStart)).Days / daysInYear, 1);
            }
        }

        public string GetFunding()
        {
            if (funding == null)
            {
                return "No funding data available.";
            }

            return funding;
        }

        /// <summary>
        /// Creates a string for the staff's current employment level.
        /// </summary>
        public string CurrentJobTitle                                             //Current job of researcher
        {
            get
            {
                var currentJob = from Position p in Positions
                                 orderby p.Start descending
                                 select p;

                return currentJob.First().ToTitle(CurrentJobLevel);
            }
        }

        /// <summary>
        /// Populates the staff's supervisions using information that is already known.
        /// </summary>
        public List<Student> GetSupervisionsList()
        {
            SupervisionsList = ResearcherController.GetSupervisions(this.ID);
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
        public double GetPerformanceByPublication()
        {
            double PublicationCount = Publications.Count;

            return Math.Round(PublicationCount / Tenure, 1);
        }

        /// <summary>
        /// The amount of funding received per year for their entire tenure. 
        /// </summary>
        /// <returns>
        /// The amount of funding received per year.
        /// </returns>
        public double GetPerformanceByFunding()
        {
            double TotalFunding = 0.0;

            foreach (Publication p in Publications)
            {
                TotalFunding += p.Funding;
            }

            return Math.Round(TotalFunding / Tenure, 1);
        }

        /// <summary>
        /// Returns the employment level of the staff's current job.
        /// </summary>
        public Position.EmploymentLevel CurrentJobLevel                                          //Current job level of researcher
        {
            get
            {
                var currentJob = from Position p in Positions
                                 orderby p.Start descending
                                 select p;

                return currentJob.First().Level;
            }
        }

        /// <summary>
        /// Creates a string describing their current job in the form of job title + date they started.
        /// </summary>
        public string CurrentJob                                         //Date of current position of researcher
        {
            get
            {
                var currentJob = from Position p in Positions
                                 orderby p.Start descending
                                 select p;

                return currentJob.First().ToTitle(CurrentJobLevel) + " started on " + CurrentJobStart.ToString("dd-MM-yyyy");
            }
        }

        /// <summary>
        /// Returns the date they started their current job.
        /// </summary>
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

        /// <summary>
        /// Gets the date that they started at the institution. 
        /// </summary>
        public DateTime EarliestJobStart                                        //Commence date of researcher with the Institution
        {
            get
            {
                var earliestJob = from Position p in Positions
                                  orderby p.Start ascending
                                  select p;

                return earliestJob.First().Start;
            }
        }

        /// <summary>
        /// Returns a list of all the other jobs this person has held.
        /// </summary>
        public List<Position> EarlierJobs                                       //List of earlier jobs of researcher (If available)
        {
            get
            {
                List<Position> pastJob = new List<Position>();

                foreach (Position p in Positions)
                {
                    pastJob.Add(p);
                }

                pastJob.RemoveAt(pastJob.Count - 1);

                return pastJob;
            }
        }
    }
}
