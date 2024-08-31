using FirstDemo.Domain.Entities;

namespace FirstDemo.Domain.Features.Training
{
    public interface ICourseManagementService
    {
        Task CreateCourse(string title, uint fees, string description);

        Task<(IList<Course> records, int total, int totalDisplay)>
            GetPagedCoursesAsync(int pageIndex, int pageSize, string searchText, string sortBy);
    }
}