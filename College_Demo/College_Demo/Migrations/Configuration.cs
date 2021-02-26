namespace College_Demo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<College_Demo.Models.College_DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(College_Demo.Models.College_DBContext db)
        {
            //select top(1) * from tbl_user where role = 'admin'
            var dbAdmin = db.tbl_user.Where(p => p.role == Models.Role.Admin).FirstOrDefault();
            if (dbAdmin == null)
            {
                dbAdmin = new Models.User()
                {
                    role = Models.Role.Admin,
                    full_name = "Super Admin",
                    email = "admin",
                    password = "123"
                };

                db.tbl_user.Add(dbAdmin);

                db.SaveChanges();
            }
        }
    }
}
