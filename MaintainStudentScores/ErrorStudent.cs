using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainStudentScores
{
    public class ErrorStudent : Exception
    {
        public string studentstring;

        public ErrorStudent(string message) : base(message)
        {
            studentstring = message;
        }

        
    }
}
