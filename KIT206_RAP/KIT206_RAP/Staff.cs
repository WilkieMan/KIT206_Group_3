﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KIT206_RAP.Researcher;

namespace KIT206_RAP
{
    internal class Staff : Researcher
    {
        private double year3Avergae, funidngReceived, performanceByPublication, performanceByFunding;
        private int supervisions;

        public Staff(Title title, string givenName, string familyName) : base(title, givenName, familyName)
        {
            
        }
    }
}