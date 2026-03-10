namespace Pidu_proov.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Pidu_proov.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pidu_proov.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Pidu_proov.Models.ApplicationDbContext";
        }

        protected override void Seed(Pidu_proov.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            // 1. Loo "Admin" roll, kui seda veel pole
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);
            }

            // 2. Loo administraatori kasutaja
            var adminEmail = "tahmazovhussejn@gmail.com";
            var adminUser = context.Users.FirstOrDefault(u => u.Email == adminEmail);

            if (adminUser == null)
            {
                var user = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
                userManager.Create(user, "admin123"); // Vali turvaline parool
                adminUser = user;
            }

            // 3. Seo kasutaja Admin rolliga
            if (!userManager.IsInRole(adminUser.Id, "Admin"))
            {
                userManager.AddToRole(adminUser.Id, "Admin");
            }

            // 4. Seemne pühad, kui tabel on tühi
            if (!context.Pyhad.Any())
            {
                context.Pyhad.AddOrUpdate(p => p.Nimetus,
                    new Pidu_proov.Models.Pyha { Nimetus = "Jõulupidu", Kuupaev = new DateTime(2026, 12, 20), HindMin = 10, HindMax = 50 },
                    new Pidu_proov.Models.Pyha { Nimetus = "Suvepidu", Kuupaev = new DateTime(2026, 6, 21), HindMin = 5, HindMax = 30 },
                    new Pidu_proov.Models.Pyha { Nimetus = "Sünnipäevapidu", Kuupaev = new DateTime(2026, 9, 15), HindMin = 0, HindMax = 20 }
                );
                context.SaveChanges();
            }
        }
    }
}
