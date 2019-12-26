namespace MoroskoWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdvCPP", "AspNetUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AdvCPP", "AspNetUser_Id");
            AddForeignKey("dbo.AdvCPP", "AspNetUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvCPP", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AdvCPP", new[] { "AspNetUser_Id" });
            DropColumn("dbo.AdvCPP", "AspNetUser_Id");
        }
    }
}
