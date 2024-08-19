using FirstDemo.Domain.Entities;
using FirstDemo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Domain.Repositories
{
    public interface ICourseRepository : IRepositoryBase<Course, Guid>
    {
		//Task<bool> IsTitleDuplicateAsync(string title, Guid? id = null);
        
  //      Task<(IList<Course> records, int total, int totalDisplay)>
  //          GetTableDataAsync(string searchTitle, uint searchFeesFrom, 
  //              uint searchFeesTo, string orderBy, int pageIndex, int pageSize);

    }
}
