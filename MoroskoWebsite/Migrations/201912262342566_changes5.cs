namespace MoroskoWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetRoleAspNetUsers", "AspNetRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetRoleAspNetUsers", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoleAspNetUsers", new[] { "AspNetRole_Id" });
            DropIndex("dbo.AspNetRoleAspNetUsers", new[] { "AspNetUser_Id" });
            AddColumn("dbo.AspNetUsers", "AspNetRole_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetRoles", "AspNetUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "AspNetRole_Id");
            CreateIndex("dbo.AspNetRoles", "AspNetUser_Id");
            AddForeignKey("dbo.AspNetUsers", "AspNetRole_Id", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetRoles", "AspNetUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetRoleAspNetUsers",
                c => new
                    {
                        AspNetRole_Id = c.String(nullable: false, maxLength: 128),
                        AspNetUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AspNetRole_Id, t.AspNetUser_Id });
            
            DropForeignKey("dbo.AspNetRoles", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AspNetRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetRoles", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "AspNetRole_Id" });
            DropColumn("dbo.AspNetRoles", "AspNetUser_Id");
            DropColumn("dbo.AspNetUsers", "AspNetRole_Id");
            CreateIndex("dbo.AspNetRoleAspNetUsers", "AspNetUser_Id");
            CreateIndex("dbo.AspNetRoleAspNetUsers", "AspNetRole_Id");
            AddForeignKey("dbo.AspNetRoleAspNetUsers", "AspNetUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetRoleAspNetUsers", "AspNetRole_Id", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
