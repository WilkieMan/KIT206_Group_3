using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Position
    {
        /// Written by Sumaiya
        public int ID { get; set; } // ID of researcher
        public EmploymentLevel Level { get; set; } // Employment level 
        public DateTime Start { get; set; } // Start day 
        public DateTime End { get; set; } // End day  
        public enum EmploymentLevel { A, B, C, D, E, Student, Any} // The different employment levels a researcher can be

        /// <summary>
        /// The position constructor.
        /// </summary>
        /// <param name="id">Their ID</param>
        /// <param name="level">Their employment level.</param>
        /// <param name="start">The start date of the position.</param>
        /// <param name="end">The end date of the position (if applicable)</param>
        public Position(int id, EmploymentLevel level, DateTime start, DateTime end)
        {
            ID = id;
            Level = level;
            Start = start;
            End = end;
        }

        /// <summary>
        /// Turns an employment level into a string representing the job title of that level.
        /// </summary>
        /// <param name="el">Their employment level.</param>
        /// <returns>
        /// Their job title.
        /// </returns>
        /// Written by Sumaiya
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

        /// <summary>
        /// Formats a string to represent the position.  
        /// </summary>
        /// <returns>
        /// A string representing the position.</returns>
        /// Written by Sumaiya
        public override string ToString()
        {
            string start = Start.ToString("dd-MM-yyyy");  //The start date 
            string end;                                   //The end date
            string title = ToTitle(Level);                //Title of the posititon  

            if (DateTime.Compare(End, DateTime.Now) == 1)
            {
                end = "Current";
            }
            else
            {
                end = End.ToString("dd-MM-yyyy");
            }
            return String.Format("Start: {0}, End: {1},  {2}", start, end, title);
        }
    }
}
