using Autofac;
using FirstDemo.Domain.Features.Training;
using FirstDemo.Infrastructure;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseCreateModel
    {
        private ILifetimeScope _scope;
        private ICourseManagementService _courseManagementService;
        public string Title { get; set; }
        public string Description { get; set; }
        public uint Fees { get; set; }
        public CourseCreateModel() { }
        public CourseCreateModel(ICourseManagementService courseManagementService)
        {
                _courseManagementService = courseManagementService;
        }

        internal void Resolve(ILifetimeScope scope)
        {
            
            _scope = scope;
            _courseManagementService = _scope.Resolve<ICourseManagementService>();
        }
        internal async Task CreateCourseAsync()
        {
          await _courseManagementService.CreateCourseAsync(Title, Fees, Description);
        }
    }
}
