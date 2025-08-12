using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Application.Features.Training.DTOs
{
    public class CourseEnrollmentDTO
    {
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
