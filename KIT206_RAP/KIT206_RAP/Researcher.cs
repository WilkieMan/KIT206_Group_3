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
        public int ID { get; set; }                                             //Researcher ID
        public string GivenName { get; set; }                                   //Researcher Given name
        public string FamilyName { get; set; }                                  //Researcher Family name                                                       //Researcher Title
        public string School { get; set; }                                      //Researcher School
        public Title NameTitle { get; set; }
        public Campus CampusName { get; set; }                                      //Researcher working campus base
        public string Email { get; set; }                                       //Researcher email
        public string Photo { get; set; }                                       //Researcher Photo (URL Type)   //Past and current positions of researcher
        public Position EmploymentLevel { get; set; }
        public List<Publication> publications = new List<Publication>();           //Publications list of researcher
        public int Tenure;
        public int PublicationCount;
        public Q1Percentage Q1;

        public enum Title { Dr, Prof, Mr, Mrs, Miss, Ms, Prov, Rev}
        public enum Q1Percentage { Q1, Q2, Q3, Q4}
        public enum Campus { CradleCoast, Hobart, Launceston };


        public string ToBasicName()
        { 
            return FamilyName + ", " + GivenName + " (" + NameTitle + ")";
        }

        public Researcher(int id, string givenName, string FamilyName, Title title, Campus campus, Position employmentLevel)
        {
            ID = id;
            GivenName = givenName;
            NameTitle = title;
            CampusName = campus;
            EmploymentLevel = employmentLevel;
        }


        /*  public string GetCurrentJob                                             //Current job of researcher
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

    }
}
