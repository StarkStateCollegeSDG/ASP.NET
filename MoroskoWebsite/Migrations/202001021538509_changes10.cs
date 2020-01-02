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
                .ForeignKey("dbo.AspNetUsers", t => t.aspnetuserId)
                .Index(t => t.aspnetuserId)
                .Index(t => t.advcppId);
            //Had to use this method instead of the typical
            //.ForeignKey() method to get this to work. It does
            //the exact same thing.
            AddForeignKey("dbo.AdvCPPStudents", "advcppId", "dbo.AdvCPP", "Id");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvCPPStudents", "aspnetuserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdvCPPStudents", "advcppId", "dbo.AdvCPP");
            DropIndex("dbo.AdvCPPStudents", new[] { "advcppId" });
            DropIndex("dbo.AdvCPPStudents", new[] { "aspnetuserId" });
            DropTable("dbo.AdvCPPStudents");
        }
    }
}
