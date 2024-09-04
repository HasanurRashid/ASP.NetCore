using Autofac;
using FirstDemo.Domain.Entities;
using FirstDemo.Domain.Features.Training;
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseUpdateModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required, Range(0, 50000, ErrorMessage = "Fees should be between 0 & 50000")]
        public uint Fees { get; set; }
        public string Description { get; set; }

        private ICourseManagementService _courseService;
       

        public CourseUpdateModel()
        {

        }

        public CourseUpdateModel(ICourseManagementService courseService)
        {
            _courseService = courseService;
         
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _courseService = scope.Resolve<ICourseManagementService>();
           
        }

        internal async Task LoadAsync(Guid id)
        {
            Course course = await _courseService.GetCourseAsync(id);
            if (course != null)
            {
                Id= course.Id;
                Title= course.Title;
                Fees = course.Fees;
                Description= course.Description;
            }
        }

        internal async Task UpdateCourseAsync()
        {
            if (!string.IsNullOrWhiteSpace(Title)
                && Fees >= 0)
            {
                await _courseService.UpdateCourseAsync(Id, Title, Description, Fees);
            }
        }
    }
}
