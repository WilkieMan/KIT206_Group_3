using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    class Position
    {
       public EmploymentLevel Level { get; set; }
       public DateTime Start { get; set; }
       public DateTime End { get; set; }
        
       public enum EmploymentLevel { Student, A, B, C, D, E };


       public string ToTitle()
       {
            return Level + " Start - " + Start + ", End - " + End;
       }
    }
}
