using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    public class Position
        {
            public int ID { get; set; }                         //ID of researcher
            public EmploymentLevel Level { get; set; }          //Employment level 
            public DateTime Start { get; set; }                 //Start day 
            public DateTime End { get; set; }                   //End day  


        public Position(int id, EmploymentLevel level, DateTime start, DateTime end)               
        { 
            ID = id;
            Level = level;
            Start = start;
            End = end;
        }

        //To title of the position
        public string ToTitle(EmploymentLevel el)
            {
                string title;                                   //The title of the researcher
                switch (el)
                {
                    case EmploymentLevel.Student:
                        title = "Student";
                        break;
                    case EmploymentLevel.A:
                        title = "Research Associate";
                        break;
                    case EmploymentLevel.B:
                        title = "Lecturer";
                        break;
                    case EmploymentLevel.C:
                        title = "Assistant Professor";
                        break;
                    case EmploymentLevel.D:
                        title = "Associate Professor";
                        break;
                    default:
                        title = "Professor";
                        break;
                }

                return title;
            }

            //ToString method about the position
            public string ToString()
            {
                string start = Start.ToString("dd-MM-yyyy");  //The start date 
                string end;                                   //The end date
                string title = ToTitle(Level);                //Title of the posititon  

                if (DateTime.Compare(End, DateTime.Now) == 1)
                {
                    end = "NULL";
                }
                else
                {
                    end = End.ToString("dd-MM-yyyy");
                }
                return String.Format("Start: {0}, End: {1},  {2}", start, end, title);
            }


        public enum EmploymentLevel {A, B, C, D, E, Student}
        }
}
