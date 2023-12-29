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
        private double FundingReceived { get; set; }
        public List<double> FundingList;
        double FundingToMaintain { get; set; }
        public List<Position> Positions = new List<Position>();

        public Staff(int id, string givenName, string FamilyName, Title title, Campus campus, double fundingToMaintain) : base(id, givenName, FamilyName, title, campus)
        {
            ID = id;
            GivenName = givenName;
            NameTitle = title;
            CampusName = campus;
            FundingToMaintain = fundingToMaintain;
        }

        public enum Performance { A, B, C, D, E }

        public double Tenure
        {
            get
            {
                double daysInYear = 365.0;

                return Math.Round((DateTime.Today - EarliestJobStart).Days / daysInYear, 1);
            }
        }

        public void PopulateSupervisionsList()
        {
            SupervisionsList = ResearcherController.GetSupervisions(this.ID);
            SupervisionsCount = SupervisionsList.Count();
        }

        public double ThreeYearAverage
        {
            get
            {
                double ThreeYearPublicationCount = 0.0;
                DateTime Current = DateTime.Now;

                foreach (Publication t in Publications)
                {
                    DateTime PublicationYear = t.YearOfPublication;

                    if (PublicationYear.Year >= Current.AddYears(-3).Year)
                    {
                        ThreeYearPublicationCount++;
                    }
                }

                return Math.Round(ThreeYearPublicationCount / 3, 1);
            }
        }

    

        //Performance of researcher 
        public double Performance3Year
        {
            get
            {
                double realPublications = ThreeYearAverage;
                double expectedPublications;

                    switch (CurrentJobLevel)
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

        public double GetPerformanceByPublication()
        {
            double PublicationCount = GetPublicationCount();

            return PublicationCount / Tenure;
        }

        public double GetPerformanceByFunding()
        {
            double TotalFunding = 0.0;

            foreach (int f in FundingList)
            {
                TotalFunding = TotalFunding + f;
            }

            return TotalFunding / Tenure;
        }

        public string CurrentJob                                             //Current job of researcher
        {
            get
            {
                var currentJob = from Position p in Positions
                                 orderby p.Start descending
                                 select p;

                return currentJob.First().ToTitle(currentJob.First().Level);
            }
        }

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

        public string CurrentJobTitle                                         //Date of current position of researcher
        {
            get
            {
                var currentJob = from Position p in Positions
                                 orderby p.Start descending
                                 select p;

                return currentJob.First().ToString();
            }
        }

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

        //staff also need a table of all previous positions - view??
    }
}
