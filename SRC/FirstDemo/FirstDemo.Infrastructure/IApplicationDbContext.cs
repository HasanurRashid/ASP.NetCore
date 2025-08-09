using FirstDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstDemo.Infrastructure
{
    public interface IApplicationDbContext
    {
       DbSet<Course> Courses { get; set; }
       DbSet<Student> Students { get; set; }
    }
}