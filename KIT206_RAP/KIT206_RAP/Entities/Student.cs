using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KIT206_RAP.Researcher;

namespace KIT206_RAP
{
    internal class Student : Researcher
    {
        public string Degree { get; set; } // A string for the degree that they are undertaking. 
        public int SupervisorID { get; set; } // The ID of their supervisor.
        Position CurrentPosition; // The date they started their research degree. 

        /// <summary>
        /// Student constructor.
        /// </summary>
        /// <param name="title">Their honorific.</param>
        /// <param name="givenName">Their given name.</param>
        /// <param name="familyName">Their family name.</param>
        /// <param name="employmentLevel">Their current employment level (should be Student).</param>
        /// <param name="id">Their ID.</param>
        /// <param name="degree">Their degree as a string.</param>
        /// <param name="supervisorid">Their supervisors ID.</param>
        public Student(Title title, string givenName, string familyName, Position.EmploymentLevel employmentLevel, int id, string degree, int supervisorid) : base(title, givenName, familyName, employmentLevel, id)
        {
            ID = id;
            GivenName = givenName;
            NameTitle = title;
            FamilyName = familyName;
            EmploymentLevel = employmentLevel;
            Degree = degree;
            SupervisorID = supervisorid;
        }

        /// <summary>
        /// Formats a string for displaying basic student information. 
        /// </summary>
        /// <returns>
        /// A string containing their full name title and position.
        /// </returns>
        public string PrintStudentInfo()
        {
            return FamilyName + ", " + GivenName + " (" + NameTitle + ") - " + EmploymentLevel;
        }

        /// <summary>
        /// Return the amount of time they have so far spent on their research degree.
        /// </summary>
        public double DegreeLength
        {
            get
            {
                double daysInYear = 365.0;

                return Math.Round((DateTime.Today - CurrentPosition.Start).Days / daysInYear, 1);
            }
        }
    }
}