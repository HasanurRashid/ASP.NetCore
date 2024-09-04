
using FirstDemo.Application;
using FirstDemo.Domain.Repositories;
using FirstDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Save()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
