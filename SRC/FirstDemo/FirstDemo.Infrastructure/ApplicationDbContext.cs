using FirstDemo.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstDemo.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    x=> x.MigrationsAssembly(_migrationAssembly));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CourseEnrollment>().ToTable("CourseEnrollments");

            builder.Entity<CourseEnrollment>().HasKey(x => new { x.CourseId, x.StudentId });
            builder.Entity<CourseEnrollment>()
            .HasOne<Course>()
            .WithMany()
            .HasForeignKey(x => x.CourseId);

            builder.Entity<CourseEnrollment>()
           .HasOne<Student>()
           .WithMany()
           .HasForeignKey(x => x.StudentId);

            builder.Entity<Course>().HasData(new Course[]
            {
                new Course {Id= new Guid("169a4106-3052-4a16-bcf7-321330d82507"),Title="C#", Description="Test", Fees=2000},
                new Course {Id= new Guid("55ae7105-4608-4036-94a9-c6fff940c4e1"),Title="Asp.net", Description="Test 2", Fees=3000},
                new Course {Id= new Guid("700ec20c-4f86-4502-b088-894b64177302"),Title="PHP", Description="Test 3", Fees=3000},
                new Course {Id= new Guid("bbae6df5-ce80-4d42-bc90-b3c30a0957c0"),Title="Entity Framework", Description="Test 4", Fees=3000},
                new Course {Id= new Guid("e50ce560-fc0f-4774-a15e-f91b7bb8863e"),Title="Ado.Net", Description="Test 5", Fees=3000},
            });
            base.OnModelCreating(builder);
        }
         public DbSet<Course> Courses { get; set; }
         public DbSet<Student> Students { get; set; }
    }
}
