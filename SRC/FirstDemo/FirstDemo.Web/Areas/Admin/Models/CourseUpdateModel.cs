using Autofac;
using AutoMapper;
using FirstDemo.Application.Features.Training;
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
        private IMapper _mapper;
        
       

        public CourseUpdateModel()
        {

        }

        public CourseUpdateModel(ICourseManagementService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
         
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _courseService = scope.Resolve<ICourseManagementService>();
            _mapper = scope.Resolve<IMapper>();
           
        }

        internal async Task LoadAsync(Guid id)
        {
            Course course = await _courseService.GetCourseAsync(id);
            if (course != null)
            {
                //Id= course.Id;
                //Title= course.Title;
                //Fees = course.Fees;
                //Description= course.Description;
                _mapper.Map(course, this);
                
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
