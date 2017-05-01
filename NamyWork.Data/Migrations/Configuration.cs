namespace NamyWork.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<NamyWork.Data.DataEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NamyWork.Data.DataEntities context)
        {
            //  This method will be called after migrating to the latest version.

            SeedData.SeedRoles(context);
            SeedData.seedAdminUser(context);
            SeedData.SeedCategories(context);
            SeedData.SeedCity(context);
            SeedData.SeedSkills(context);
        }
    }
}
