namespace DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.RiderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.RiderContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var riders = new List<Rider>
            {
                new Rider { Id = 1, Email = "rider1@example.com", Password = "password1", Name = "Rider One", Phone = "1234567890", AvailabilityStatus = "Available" },
                new Rider { Id = 2, Email = "rider2@example.com", Password = "password2", Name = "Rider Two", Phone = "0987654321", AvailabilityStatus = "Unavailable" }
            };

            riders.ForEach(r => context.Riders.AddOrUpdate(p => p.Id, r));
            context.SaveChanges();

            var reviews = new List<Reviews>
            {
                new Reviews { Id = 1, RiderId = 1, ReviewDate = DateTime.Now, rating = 5, review_text = "Great ride!" },
                new Reviews { Id = 2, RiderId = 2, ReviewDate = DateTime.Now, rating = 4, review_text = "Smooth journey." }
            };

            reviews.ForEach(r => context.Reviews.AddOrUpdate(p => p.Id, r));
            context.SaveChanges();
        }
    }
}
