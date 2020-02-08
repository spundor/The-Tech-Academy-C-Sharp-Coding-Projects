using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using codeFirst_project.Models;

namespace codeFirst_project.DAL
{
    public class BusinessInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<BusinessContext>
    {
        protected override void Seed(BusinessContext context)
        {
            var employees = new List<Employee>
            {
            new Employee{Name="Fred",EnrollmentDate=DateTime.Parse("1995-01-01")},
            new Employee { Name = "Alex", EnrollmentDate = DateTime.Parse("1995-01-01")},
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();
            
            var jobs = new List<Job>
            {
            new Job{JobID=0201,Title="Developer"},
            new Job{JobID=0111,Title="Junior Developer"},
            new Job{JobID=0067,Title="Instructor"},
            };

            jobs.ForEach(s => context.Jobs.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
            new Enrollment{EmployeeID=1, JobID=0201},
            new Enrollment{EmployeeID=1, JobID=0067},
            new Enrollment{EmployeeID=2, JobID=0111},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}