using Autofac;
using FirstDemo.Application.Features.Training.Services;
using FirstDemo.Infrastructure;
using System.Web;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseEnrollmentListModel
    {
        private ILifetimeScope _scope;
        private ICourseManagementService _courseManagementService;

        public CourseEnrollmentSearch SearchItem { get; set; }

        public CourseEnrollmentListModel()
        {
        }

        public CourseEnrollmentListModel(ICourseManagementService courseManagementService)
        {
            _courseManagementService = courseManagementService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _courseManagementService = _scope.Resolve<ICourseManagementService>();
        }

        public async Task<object> GetPagedCourseEnrollmentsAsync(int pageIndex, int pageSize, string orderBy)
        {
            var data = await _courseManagementService.GetCourseEnrollmentsAsync(
                pageIndex,
                pageSize,
                orderBy,
                SearchItem.CourseName,
                SearchItem.StudentName,
                SearchItem.EnrollmentDateFrom,
                SearchItem.EnrollmentDateTo
                );

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                HttpUtility.HtmlEncode(record.StudentName),
                                HttpUtility.HtmlEncode(record.CourseName),
                                record.EnrollmentDate.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
