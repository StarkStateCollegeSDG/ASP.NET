namespace MoroskoWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvCPPStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        aspnetuserId = c.String(maxLength: 128),
                        advcppId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvCPPs", t => t.advcppId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.aspnetuserId)
                .Index(t => t.aspnetuserId)
                .Index(t => t.advcppId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvCPPStudents", "aspnetuserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdvCPPStudents", "advcppId", "dbo.AdvCPPs");
            DropIndex("dbo.AdvCPPStudents", new[] { "advcppId" });
            DropIndex("dbo.AdvCPPStudents", new[] { "aspnetuserId" });
            DropTable("dbo.AdvCPPStudents");
        }
    }
}
