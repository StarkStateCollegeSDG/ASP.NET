namespace MoroskoWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "AspNetUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetRoles", "AspNetUserId");
            AddForeignKey("dbo.AspNetRoles", "AspNetUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetRoles", "AspNetUserId", "dbo.AspNetUsers1");
            DropIndex("dbo.AspNetRoles", new[] { "AspNetUserId" });
            DropColumn("dbo.AspNetRoles", "AspNetUserId");
        }
    }
}
