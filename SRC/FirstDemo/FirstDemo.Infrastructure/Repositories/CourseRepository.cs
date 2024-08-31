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
        public CourseRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

       
        public async Task<bool> IsTitleDuplicate(string title, Guid? id = null)
        {
            if (id.HasValue)
            {
                return await GetCountAsync(x => x.Id == id.Value && x.Title == title) > 0;
            }
            else
            {
                return await GetCountAsync(x => x.Title == title) > 0;
            }
        }
        public async Task<(IList<Course> records, int total, int totalDisplay)>
            GetTableDataAsync(string searchText, string orderBy, int pageIndex, int pageSize)
        {
            return await GetDynamicAsync(x=> x.Title.Contains(searchText), orderBy, null, pageIndex, pageSize, true);
        }
    }
}
