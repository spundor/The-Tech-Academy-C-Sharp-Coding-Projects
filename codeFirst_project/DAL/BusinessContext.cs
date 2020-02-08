using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using codeFirst_project.Models;

namespace codeFirst_project.DAL
{
    public class BusinessContext : DbContext
    {
        public BusinessContext() : base("BusinessContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}