using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotation;

namespace Fluent_API
{
    public class Cover
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }

    }
}
