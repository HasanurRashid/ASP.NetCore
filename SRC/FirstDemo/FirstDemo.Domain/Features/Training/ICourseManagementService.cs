namespace FirstDemo.Domain.Features.Training
{
    public interface ICourseManagementService
    {
        void CreateCourse(string title, uint fees, string description);
    }
}