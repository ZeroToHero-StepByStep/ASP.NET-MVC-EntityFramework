namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            //use nullable:fase can directly change the convention
//            AddColumn("dbo.Courses", "Name", c => c.String(nullable:false));
//            here use the drop column is very dangerous , becuase it will drop all the data of that column.
//            DropColumn("dbo.Courses", "Title");
            RenameColumn("dbo.Courses" , "Title" , "Name");
            
        }
        
        public override void Down()
        {
//            AddColumn("dbo.Courses", "Title", c => c.String());
//            DropColumn("dbo.Courses", "Name");
            RenameColumn("dbo.Courses" , "Name" , "Title");
        }
    }
}
