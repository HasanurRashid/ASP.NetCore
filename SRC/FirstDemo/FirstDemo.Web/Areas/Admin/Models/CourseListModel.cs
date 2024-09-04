using FirstDemo.Application.Features.Training;
using FirstDemo.Domain.Features.Training;
using FirstDemo.Infrastructure;
using System.Web;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseListModel
    {
        private readonly ICourseManagementService _courseService;
        public CourseListModel()
        {
                
        }
        public CourseListModel(ICourseManagementService courseService)
        {
            _courseService = courseService;
        }
        
        public async Task<object> GetPagedCoursesAsync(DataTablesAjaxRequestUtility dataTablesUtility)
        {
            var data = await _courseService.GetPagedCoursesAsync(
                dataTablesUtility.PageIndex,
                dataTablesUtility.PageSize,
                dataTablesUtility.SearchText,
                //SearchItem.Title,
                //SearchItem.CourseFeesFrom,
                //SearchItem.CourseFeesTo,
                dataTablesUtility.GetSortText(new string[] { "Title",  "Fees" }));

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
