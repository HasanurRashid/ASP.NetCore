using FirstDemo.Domain;
using FirstDemo.Domain.Repositories;

namespace FirstDemo.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
       ICourseRepository CourseRepository { get;}
    }
}
