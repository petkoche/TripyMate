namespace TelerikAcademy.TripyMate.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TelerikAcademy.TripyMate.Data.Model;

    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        private const string AdministratorUserName = "info@telerikacademy.com";
        private const string AdministratorPassword = "123456";
        private const string UserrPassword = "123456";
        private static string[] SeedMails =
        {
            "bear@me.me",
            "data2@me.me",
            "ponko@me.me",
            "sofiq@me.me",
            "etko@me.me",
            "prucpcu@me.me"
        };
        private static string[] SeedTowns = {
            "Burgas",
            "Sofia",
            "Plovdiv",
            "Varna",
            "Aitos",
            "Pleven"
        };
        private static string[] SeedFirstNames = {
            "Pesho",
            "Stoqn",
            "Dimitar",
            "Krasi",
            "Pencho",
            "Teodor"
        };
        private static string[] SeedLastNames = {
            "Dimitrov",
            "Ivanov",
            "Penev",
            "Kapitanov",
            "Slaveikov",
            "Yanakiev"
        };
        private static string[] SeedPhoneNumbers = {
            "0893356060",
            "0893786060",
            "0893329870",
            "0893567860",
            "0893437560",
            "0893324573"
        };


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
                var roleUser = new IdentityRole { Name = "user" };
                roleManager.Create(role);
                roleManager.Create(roleUser);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    FirstName = "Georgi",
                    LastName = "Bojinov",
                    PhoneNumber = "0893328060",
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);

                for (int i = 0; i < 6; i++)
                {
                    var userU = new User
                    {
                        FirstName = SeedFirstNames[i],
                        LastName = SeedLastNames[i],
                        PhoneNumber = SeedPhoneNumbers[i],
                        UserName = SeedMails[i],
                        Email = SeedMails[i],
                        EmailConfirmed = true,
                    };

                    userManager.Create(userU, AdministratorPassword);
                    userManager.AddToRole(userU.Id, "user");
                }
            }
        }

        private void SeedSampleEndTowns(MsSqlDbContext context)
        {
            if (!context.EndTowns.Any())
            {
                for (int i = 0; i < 6; i++)
                {
                    var endTown = new EndTown()
                    {
                        Name = SeedTowns[i]
                    };

                    context.EndTowns.Add(endTown);
                }
            }
        }

        private void SeedSampleStartTowns(MsSqlDbContext context)
        {
            if (!context.StartTowns.Any())
            {
                for (int i = 5; i >= 0; i--)
                {
                    var startTown = new StartTown()
                    {
                        Name = SeedTowns[i]
                    };

                    context.StartTowns.Add(startTown);
                }
            }
        }

        private void SeedSampleData(MsSqlDbContext context)
        {
            if (!context.Posts.Any())
            {
                int counter = 5;
                for (int i = 0; i < 6; i++)
                {
                    var tmpMail = SeedMails[i];
                    var tmpTown = SeedTowns[i];
                    var tmpEndTown = SeedTowns[counter];

                    var post = new Post()
                    {
                        Title = "Post " + i,
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sit amet lobortis nibh. Nullam bibendum, tortor quis porttitor fringilla, eros risus consequat orci, at scelerisque mauris dolor sit amet nulla.",
                        Author = context.Users.First(x => x.Email == tmpMail),
                        StartTownId = context.StartTowns.First(x => x.Name == tmpTown).ID,
                        StartTown = context.StartTowns.First(x => x.Name == tmpTown),
                        EndTownId = context.EndTowns.First(x => x.Name == tmpTown).ID,
                        EndTown = context.EndTowns.First(x => x.Name == tmpEndTown),
                        CreatedOn = DateTime.Now
                    };

                    context.Posts.Add(post);
                    counter--;
                }
            }
        }


    }
}
