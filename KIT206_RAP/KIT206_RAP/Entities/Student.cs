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
        private string Degree;
        public int SupervisorID;
        Position CurrentPosition;

        public Student(int id, string givenName, string FamilyName, Title title, Campus campus, Position.EmploymentLevel employmentLevel, string degree, int supervisorid) : base(id, givenName, FamilyName, title, campus, employmentLevel)
        {
            ID = id;
            GivenName = givenName;
            NameTitle = title;
            CampusName = campus;
            EmploymentLevel = employmentLevel;
            Degree = degree;
            SupervisorID = supervisorid;
        }

        public double Tenure
        {
            get
            {
                double daysInYear = 365.0;

                return Math.Round((DateTime.Today - CurrentPosition.Start).Days / daysInYear, 1);
            }
        }

        public string PrintSupervisonInfo()
        {
            return FamilyName + ", " + GivenName + " (" + NameTitle + ") " + EmploymentLevel;
        }
    }
}