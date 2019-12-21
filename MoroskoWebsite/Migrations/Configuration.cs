namespace MoroskoWebsite.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MoroskoWebsite.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoroskoWebsite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoroskoWebsite.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Create the role of admin and assign it to a new user.
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            if (!context.Users.Any(u => u.UserName == "admin@domain.com"))
            {
                var user = new ApplicationUser
                {
                    //UserName and Email must have the same values.
                    //If not login will not work.
                    UserName = "admin@domain.com",
                    Email = "admin@domain.com"
                };
                //Need to create and save the user to database.
                IdentityResult result = userManager.Create(user, "K@pp@ Th3t@");
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();
                //Separate save because now we need to 
                //save the users new role.
                userManager.AddToRole(user.Id, "Admin");
                context.SaveChanges();
            }
        }
    }
}
