using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Domain.Entities
{
    public class CourseEnrollment
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
