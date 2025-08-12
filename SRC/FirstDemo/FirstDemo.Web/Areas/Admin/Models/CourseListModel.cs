using Autofac;
using FirstDemo.Application.Features.Training;
using FirstDemo.Application.Features.Training.Services;
using FirstDemo.Infrastructure;
using System.Web;
using static System.Formats.Asn1.AsnWriter;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseListModel
    {
        private ILifetimeScope _scope;
        private ICourseManagementService _courseManagementService;

        private readonly ICourseManagementService _courseService;
       
        public CourseSearch SearchItem { get; set; }
        public CourseListModel()
        {
                
        }
        public CourseListModel(ICourseManagementService courseService)
        {
            _courseService = courseService;
        }
        public void Resolve(ILifetimeScope scope)
        {

            _scope = scope;
            _courseManagementService = _scope.Resolve<ICourseManagementService>();
        }
        public async Task<object> GetPagedCoursesAsync(DataTablesAjaxRequestUtility dataTablesUtility)
        {
            var data = await _courseManagementService.GetPagedCoursesAsync(
                dataTablesUtility.PageIndex,
                dataTablesUtility.PageSize,
                SearchItem.Title,
                SearchItem.CourseFeesFrom.Value,
                SearchItem.CourseFeesTo.Value,
                dataTablesUtility.GetSortText(new string[] { "Title", "Description", "Fees" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                HttpUtility.HtmlEncode(record.Title),
                                HttpUtility.HtmlEncode(record.Description),
                                record.Fees.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
        internal async Task DeleteCourseAsync(Guid id)
        {
          await  _courseService.DeleteCourseAsync(id);
        }
    }
}
