using FirstDemo.Domain.Entities;
using FirstDemo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
