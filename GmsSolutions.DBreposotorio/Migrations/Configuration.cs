namespace GmsSolutions.DBreposotorio.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configurations : DbMigrationsConfiguration<GmsSolutions.DBreposotorio.Context.LojaContext>
    {
        public  Configurations()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "GmsSolutions.DBreposotorio.Context.LojaContext";
            
        }

        protected override void Seed(GmsSolutions.DBreposotorio.Context.LojaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }


    }
}
