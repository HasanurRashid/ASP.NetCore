using FirstDemo.Application.Features.Training.DTOs;
using FirstDemo.Domain;
using FirstDemo.Domain.Repositories;

namespace FirstDemo.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
       ICourseRepository CourseRepository { get;}

        Task<(IList<CourseEnrollmentDTO> records,
            int total, int totalDisplay)> GetCourseEnrollmentsAsync(
            int pageIndex,
            int pageSize,
            string orderBy,
            string courseName,
            string studentName,
            DateTime enrollmentDateFrom,
            DateTime enrollmentDateTo);
    }
}
