using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstDemo.Domain;
using FirstDemo.Domain.Repositories;

namespace FirstDemo.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }

    }
}
