using System.Data.Entity.Migrations;

namespace NamyWork.Web
{
    public class DataBaseConfig
    {
        public static void MigrateToLatest()
        {
            var configuration = new Data.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }
    }
}