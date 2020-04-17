namespace AlrInvestSupply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abouts", "Description", c => c.String(maxLength: 600));
        }
    }
}
