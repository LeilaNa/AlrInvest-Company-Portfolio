namespace AlrInvestSupply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Description", c => c.String(maxLength: 300));
        }
    }
}
