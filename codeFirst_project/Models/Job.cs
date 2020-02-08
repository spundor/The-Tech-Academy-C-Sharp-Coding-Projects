using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace codeFirst_project.Models
{
    public class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}