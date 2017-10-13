namespace TelerikAcademy.TripyMate.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TelerikAcademy.TripyMate.Data.Model;

    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        private const string AdministratorUserName = "info@telerikacademy.com";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedSampleStartTowns(context);
            this.SeedSampleEndTowns(context);
            this.SeedUsers(context);
            this.SeedSampleData(context);

            base.Seed(context);
        }

        private void SeedUsers(MsSqlDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    FirstName = "Georgi",
                    LastName = "Bojinov",
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedSampleEndTowns(MsSqlDbContext context)
        {
            if (!context.EndTowns.Any())
            {
                var endTown = new EndTown()
                    {
                        Name = "Sofia"
                    };

                context.EndTowns.Add(endTown);
            }
        }

        private void SeedSampleStartTowns(MsSqlDbContext context)
        {
            if (!context.StartTowns.Any())
            {
                    var startTown = new StartTown()
                    {
                        Name = "Burgas"
                    };

                    context.StartTowns.Add(startTown);
            }
        }

        private void SeedSampleData(MsSqlDbContext context)
        {
            if (!context.Posts.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var post = new Post()
                    {
                        Title = "Post " + i,
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sit amet lobortis nibh. Nullam bibendum, tortor quis porttitor fringilla, eros risus consequat orci, at scelerisque mauris dolor sit amet nulla. Vivamus turpis lorem, pellentesque eget enim ut, semper faucibus tortor. Aenean malesuada laoreet lorem.",
                        Author = context.Users.First(x => x.Email == AdministratorUserName),
                        StartTown = context.StartTowns.First(x => x.Name == "Burgas"),
                        EndTown = context.EndTowns.First(x => x.Name == "Sofia"),
                        CreatedOn = DateTime.Now
                    };

                    context.Posts.Add(post);
                }
            }
        }


    }
}
