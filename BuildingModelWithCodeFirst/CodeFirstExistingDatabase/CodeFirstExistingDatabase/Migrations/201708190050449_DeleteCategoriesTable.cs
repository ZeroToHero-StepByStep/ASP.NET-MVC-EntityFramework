namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoriesTable : DbMigration
    {
        public override void Up()
        {
            //in order to keep the historical data , we can create another table to keep that. 
            //and set data that will be deleted to the new table , same happend to the down method.
 
            CreateTable(
                    "dbo._Categories",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO _Categories(Name) SELECT Name From Categories");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Categories(Name) SELECT Name From _Categories");
            DropTable("dbo._Categories");

        }
    }
}
