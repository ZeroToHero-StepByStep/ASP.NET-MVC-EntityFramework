namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RenameTieleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            //use nullable:fase can directly change the convention
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            Sql("UPDATE Courses SET Name = Title");
            //here use the drop column is very dangerous , becuase it will drop all the data of that column.
            DropColumn("dbo.Courses", "Title");

        }

        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable:false));
            //to ensure the downgrade database in case
            Sql("UPDATE Courses SET Title = Name");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
