
using FirstDemo.Application;
using FirstDemo.Application.Features.Training.DTOs;
using FirstDemo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace FirstDemo.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ICourseRepository CourseRepository { get; private set; }

        public ApplicationUnitOfWork(ICourseRepository courseRepository,
            IApplicationDbContext dbContext) : base((DbContext)dbContext)
        {
            CourseRepository = courseRepository;
        }

        public async Task<(IList<CourseEnrollmentDTO> records,
            int total, int totalDisplay)> GetCourseEnrollmentsAsync(
            int pageIndex,
            int pageSize,
            string orderBy,
            string courseName,
            string studentName,
            DateTime enrollmentDateFrom,
            DateTime enrollmentDateTo)
        {
            var data = await AdoNetUtility.QueryWithStoredProcedureAsync<CourseEnrollmentDTO>(
                "GetCourseEnrollments",
                new Dictionary<string, object>
                {
                    { "PageIndex",  pageIndex},
                    { "PageSize",  pageSize },
                    { "OrderBy",  orderBy },
                    { "CourseName",  courseName},
                    { "StudentName",  studentName },
                    { "EnrollmentDateFrom",  enrollmentDateFrom},
                    { "EnrollmentDateTo",  enrollmentDateTo }
                },
                new Dictionary<string, Type>
                {
                    { "Total",  typeof(int)},
                    { "TotalDisplay",  typeof(int) }
                }
            );

            return (data.result, (int)data.outValues["Total"], (int)data.outValues["TotalDisplay"]);
        }

    }
}
