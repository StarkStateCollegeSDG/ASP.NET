namespace MoroskoWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvVBStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        aspnetuserId = c.String(maxLength: 128),
                        advvbId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvVBs", t => t.advvbId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.aspnetuserId)
                .Index(t => t.aspnetuserId)
                .Index(t => t.advvbId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvVBStudents", "aspnetuserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdvVBStudents", "advvbId", "dbo.AdvVBs");
            DropIndex("dbo.AdvVBStudents", new[] { "advvbId" });
            DropIndex("dbo.AdvVBStudents", new[] { "aspnetuserId" });
            DropTable("dbo.AdvVBStudents");
        }
    }
}
