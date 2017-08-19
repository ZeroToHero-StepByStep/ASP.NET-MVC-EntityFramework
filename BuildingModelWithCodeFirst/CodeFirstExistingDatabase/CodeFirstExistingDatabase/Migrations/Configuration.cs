using System.Collections.Generic;

namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstExistingDatabase.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirstExistingDatabase.PlutoContext context)
        {
            context.Authors.AddOrUpdate(a => a.Name,
                new Author()
                {
                    Name = "Author 1",
                    Courses = new List<Course>()
                    {
                        new Course() {Name = "Course for Author 1 ", Description = "Decription 1"}
                    }

                });

        }
    }
}
