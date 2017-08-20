namespace Fluent_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoverToCoursesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Courses", "CoverId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Covers", "Id", "dbo.Courses");
            DropIndex("dbo.Covers", new[] { "Id" });
            DropColumn("dbo.Courses", "CoverId");
            DropTable("dbo.Covers");
        }
    }
}
