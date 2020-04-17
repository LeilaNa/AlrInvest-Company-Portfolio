namespace AlrInvestSupply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "Title");
            DropColumn("dbo.Abouts", "MediaUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "MediaUrl", c => c.String());
            AddColumn("dbo.Abouts", "Title", c => c.String(maxLength: 50));
        }
    }
}
