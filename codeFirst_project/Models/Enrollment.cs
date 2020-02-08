using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codeFirst_project.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int EmployeeID { get; set; }
        public int JobID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Job Job { get; set; }
    }
}
