namespace proyectoApi.Migrations
{
    using proyectoApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<proyectoApi.Models.ApiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "proyectoApi.Models.ApiDbContext";
        }

        protected override void Seed(proyectoApi.Models.ApiDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Cities.AddOrUpdate(
                c => c.Name,
                new City { Name = "Buenos Aires" },
                new City { Name = "Córdoba" },
                new City { Name = "Rosario" },
                new City { Name = "Mendoza" }
                // Agrega más ciudades según sea necesario
            );

        }
    }
}
