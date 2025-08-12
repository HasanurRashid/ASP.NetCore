using FirstDemo.Application.Features.Training.DTOs;
using FirstDemo.Domain.Entities;

namespace FirstDemo.Application.Features.Training.Services
{
	public interface ICourseManagementService
	{
		Task CreateCourseAsync(string title, uint fees, string description);
        Task DeleteCourseAsync(Guid id);
        Task<Course> GetCourseAsync(Guid id);
        Task<(IList<Course> records, int total, int totalDisplay)> 
			GetPagedCoursesAsync(int pageIndex, int pageSize, string searchTitle,
            uint searchFeesFrom, uint searchFeesTo, string sortBy);
        Task UpdateCourseAsync(Guid id, string title, string description, uint fees);
        Task<(IList<CourseEnrollmentDTO> records, int total, int totalDisplay)> GetCourseEnrollmentsAsync(
            int pageIndex, int pageSize, string orderBy,
            string courseName, string studentName, DateTime enrollmentDateFrom,
            DateTime enrollmentDateTo);

        Task<IList<Course>>? GetCoursesAsync();
    }
}