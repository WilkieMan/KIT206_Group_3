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
        public enum EmploymentLevel { Student, A, B, C, D, E };
        public enum Campus { CradleCoast, Hobart, Launceston };
        public enum Title { Dr, Mr, Mrs, Ms, Prof, Rev };
        private string givenName, familyName, email, currentJobTitle;
        private DateTime commencedInstitution, commencedPosition;
        private double tenure, q1Percentage;
        private int publications;
        private EmploymentLevel employmentLevel;
        private Campus campus;
        private Title title; 

        public string ToBasicName()
        { 
            return familyName + ", " + givenName + "(" + title + ")";
        }

        public Researcher(Title title, string givenName, string familyName)
        {
            this.givenName = givenName;
            this.familyName = familyName;
            this.title = title;
        } 
    }
}
