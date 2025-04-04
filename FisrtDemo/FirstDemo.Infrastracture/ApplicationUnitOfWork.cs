using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstDemo.Application;
using FirstDemo.Domain.Repositories;
using FirstDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FirstDemo.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ICourseRepository CourseRepository { get; private set; }
        public ApplicationUnitOfWork(ICourseRepository courseRepository, ApplicationDbContext dbContext) : base(dbContext)
        {
            CourseRepository = courseRepository;
        }

    }
}
