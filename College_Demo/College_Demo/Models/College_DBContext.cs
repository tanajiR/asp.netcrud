using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace College_Demo.Models
{
    public class College_DBContext : DbContext
    {
        public College_DBContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<College_DBContext, College_Demo.Migrations.Configuration>());
        }

        public DbSet<User> tbl_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class User
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string mno { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string addr { get; set; }
        public Role role { get; set; }
    }

    public enum Role
    {
        Student = 1,
        Teacher = 2,
        Admin = 3
    }
}