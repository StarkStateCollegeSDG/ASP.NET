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
                        aspnetuserId = c.Int(nullable: false),
                        advvbId = c.Int(nullable: false),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvVBs", t => t.advvbId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
                .Index(t => t.advvbId)
                .Index(t => t.AspNetUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvVBStudents", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AdvVBStudents", "advvbId", "dbo.AdvVBs");
            DropIndex("dbo.AdvVBStudents", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AdvVBStudents", new[] { "advvbId" });
            DropTable("dbo.AdvVBStudents");
        }
    }
}
