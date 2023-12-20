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
        public enum Performance {A, B, C, D, E }
        private double year3Avergae, fundingReceived;
        private int supervisions;
        public Performance performanceByPublication;
        public Performance performanceByFunding;

        public Staff(Title title, string givenName, string familyName, EmploymentLevel employmentLevel) : base(title, givenName, familyName, employmentLevel)
        {
            
        }
    }
}
