namespace MoroskoWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdvVBs", "AspNetUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AdvVBs", "AspNetUser_Id");
            AddForeignKey("dbo.AdvVBs", "AspNetUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvVBs", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AdvVBs", new[] { "AspNetUser_Id" });
            DropColumn("dbo.AdvVBs", "AspNetUser_Id");
        }
    }
}
