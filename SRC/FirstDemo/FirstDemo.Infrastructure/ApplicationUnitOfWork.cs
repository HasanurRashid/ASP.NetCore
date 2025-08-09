
using FirstDemo.Application;
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
    }
}
