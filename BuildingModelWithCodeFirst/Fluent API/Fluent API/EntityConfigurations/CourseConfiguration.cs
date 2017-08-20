using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotation;

namespace Fluent_API.EntityConfigurations
{
    class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            //always put table overiddes at the very beginning 
            ToTable("dbo.Courses");
            
            //overrides primary key 
            HasKey(c => c.Id);


            //overrides properties , alphabetical order 
            HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);


            Property(c => c.Description)
            .HasMaxLength(2000);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);


            //overrides relationships 

            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);

            HasMany(c => c.Tags)
            .WithMany(t => t.Courses)
            .Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseId");
                m.MapRightKey("TagId");

            });



        }

    }
}
