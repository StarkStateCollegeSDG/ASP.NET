namespace MoroskoWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvCPP", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdvVBs", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AdvCPP", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AdvVBs", new[] { "AspNetUser_Id" });
            AlterColumn("dbo.AdvCPP", "AspNetUser_Id", c => c.String());
            AlterColumn("dbo.AdvVBs", "AspNetUser_Id", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdvVBs", "AspNetUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.AdvCPP", "AspNetUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AdvVBs", "AspNetUser_Id");
            CreateIndex("dbo.AdvCPP", "AspNetUser_Id");
            AddForeignKey("dbo.AdvVBs", "AspNetUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AdvCPP", "AspNetUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
