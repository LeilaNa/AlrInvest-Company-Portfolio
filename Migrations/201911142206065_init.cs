namespace AlrInvestSupply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 600),
                        Title = c.String(maxLength: 50),
                        MediaUrl = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        MediaUrl = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(maxLength: 20),
                        Adress = c.String(maxLength: 150),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 300),
                        MediaUrl = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Slogans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BigSlogan = c.String(nullable: false, maxLength: 50),
                        SmallSlogan = c.String(nullable: false, maxLength: 50),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slogans", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Services", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Abouts", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Slogans", new[] { "LanguageId" });
            DropIndex("dbo.Services", new[] { "LanguageId" });
            DropIndex("dbo.Abouts", new[] { "LanguageId" });
            DropTable("dbo.Slogans");
            DropTable("dbo.Services");
            DropTable("dbo.Contacts");
            DropTable("dbo.Clients");
            DropTable("dbo.Admins");
            DropTable("dbo.Languages");
            DropTable("dbo.Abouts");
        }
    }
}
