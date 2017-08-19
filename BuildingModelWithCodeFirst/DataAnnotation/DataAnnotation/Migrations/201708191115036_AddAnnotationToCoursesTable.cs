namespace DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToCoursesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Courses", name: "Author_Id", newName: "AuthorId");
            DropPrimaryKey("dbo.TagCourses");
            AddColumn("dbo.Courses", "Category_Id1", c => c.Int());
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Courses", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.TagCourses", new[] { "Tag_Id", "Course_Id" });
            CreateIndex("dbo.Courses", "AuthorId");
            CreateIndex("dbo.Courses", "Category_Id1");
            AddForeignKey("dbo.Courses", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "Category_Id1", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Category_Id1", "dbo.Categories");
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Courses", new[] { "Category_Id1" });
            DropIndex("dbo.Courses", new[] { "AuthorId" });
            DropPrimaryKey("dbo.TagCourses");
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "AuthorId", c => c.Int());
            AlterColumn("dbo.Courses", "Description", c => c.String());
            DropColumn("dbo.Courses", "Category_Id1");
            AddPrimaryKey("dbo.TagCourses", new[] { "Course_Id", "Tag_Id" });
            RenameColumn(table: "dbo.Courses", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.Courses", "Category_Id");
            CreateIndex("dbo.Courses", "Author_Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Courses", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
