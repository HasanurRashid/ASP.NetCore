using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FirstDemo.Application;
using FirstDemo.Application.Features.Training;
using FirstDemo.Domain.Features.Training;
using FirstDemo.Domain.Repositories;
using FirstDemo.Infrastructure.Repositories;

namespace FirstDemo.Infrastructure
{
    public class InfrastructureModule : Module
    {
        public readonly string _connectionString;
        public readonly string _migrationAssembly;
        public InfrastructureModule(string connectionString,string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
               .InstancePerLifetimeScope();
        }
    }
}
