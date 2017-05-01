namespace NamyWork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "BudgetFrom", c => c.Double(nullable: false));
            AddColumn("dbo.Services", "BudgetTo", c => c.Double(nullable: false));
            DropColumn("dbo.Services", "JobPrice");
            DropColumn("dbo.Services", "Budget");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Budget", c => c.Double(nullable: false));
            AddColumn("dbo.Services", "JobPrice", c => c.String());
            DropColumn("dbo.Services", "BudgetTo");
            DropColumn("dbo.Services", "BudgetFrom");
        }
    }
}
