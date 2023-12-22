using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class Researcher
    {
        public enum EmploymentLevel {Student, A, B, C, D, E};
        public enum Campus { CradleCoast, Hobart, Launceston };
        public string givenName, familyName, email, currentJobTitle;
        private DateTime commencedInstitution, commencedPosition;
        private double tenure, q1Percentage;
        public int publications, funding, id;
        public EmploymentLevel employmentLevel;
        private Campus campus;
        protected Title title;

        public enum Title { Dr, Mr, Mrs, Ms, Prof, Rev };

        public string ToBasicName()
        { 
            return familyName + ", " + givenName + " (" + title + ")";
        }

        /*public Researcher(Title title, string givenName, string familyName, EmploymentLevel employmentLevel, int id)
        {
            this.givenName = givenName;
            this.familyName = familyName;
            this.title = title;
            this.employmentLevel = employmentLevel;
            this.id = id;
        } 
        
     public string GetCurrentJob                                             //Current job of researcher
            {
                get
                {
                    var currentJob = from Position p in Positions
                                     orderby p.Start ascending
                                     select p;

                    return currentJob.First().ToTitle(currentJob.First().Level);
                }
            }
            public string CurrentJobTitle                                         //Date of current position of researcher
            {
                get
                {
                    var currentJob = from Position p in Positions
                                     orderby p.Start descending
                                     select p;

                    return currentJob.First().Title;
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

            //Tenure of researcher
            public double Tenure                                                    
            {
                get
                {
                    double daysInYear = 365.0;

                    return Math.Round((DateTime.Today - EarliestJobStart).Days / daysInYear, 1);
                }
            }
                //Researcher publication count
            public int PublicationCount                                             
            {
                get { return Publications == null ? 0 : Publications.Count(); }
            }
            
           
          

             //Researcher supervisions count (staff)
            public int SupervisionCount                                                 
            {
                get
                {
                    return Supervision.Count();
                }
            }

            //Cummulative publication count for researcher
            public List<string> displayCommulativePublicationCount                      
            {
                get
                {
                    int commulativeCount = 0;
                    List<string> Commulative = new List<string>();

                    for (int i = EarliestJobStart.Year; i <= (DateTime.Today.Year); i++)
                    {
                        foreach (Publication t in Publications)
                        {
                            if (t.Year == i)
                            {
                                commulativeCount++;
                            }
                        }

                        Commulative.Add("Commulative count in " + i + " is: " + commulativeCount);
                    }

                    return Commulative;
                }
            }*/

            //To string method for researcher
            public override string ToString()                                            
            {
                return FamilyName + ", " + GivenName + " (" + Title + ")";
            }
    }
}
