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
        public enum Title { Dr, Mr, Mrs, Ms, Prof, Rev };
        public string givenName, familyName, email, currentJobTitle;
        private DateTime commencedInstitution, commencedPosition;
        private double tenure, q1Percentage;
        private int publications, funding;
        public EmploymentLevel employmentLevel;
        private Campus campus;
        protected Title title;
        bool isStudent;

        public string ToBasicName()
        { 
            return familyName + ", " + givenName + " (" + title + ")";
        }

        public Researcher(Title title, string givenName, string familyName, EmploymentLevel employmentLevel)
        {
            this.givenName = givenName;
            this.familyName = familyName;
            this.title = title;
            this.employmentLevel = employmentLevel;
        } 
    }
}
