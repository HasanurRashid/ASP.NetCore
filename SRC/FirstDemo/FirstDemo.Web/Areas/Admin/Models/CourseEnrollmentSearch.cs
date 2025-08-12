namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseEnrollmentSearch
    {
        public string CourseName { get; set; }
        public string StudentName { get; set; }
        public DateTime EnrollmentDateFrom { get; set; }
        public DateTime EnrollmentDateTo { get; set; }
    }
}
