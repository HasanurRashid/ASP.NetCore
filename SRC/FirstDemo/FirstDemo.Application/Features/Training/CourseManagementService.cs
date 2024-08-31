using FirstDemo.Domain.Entities;
using FirstDemo.Domain.Features.Training;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Application.Features.Training
{
    public class CourseManagementService : ICourseManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public CourseManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task  CreateCourse(string title, uint fees, string description)
        {
            bool isDuplicate = await _unitOfWork.CourseRepository.
                IsTitleDuplicate(title);
            if (isDuplicate)
                throw new InvalidOperationException();

            Course course = new Course
            {
                Title = title,
                Fees = fees,
                Description = description
            };
            _unitOfWork.CourseRepository.Add(course);
            _unitOfWork.Save();

        }

        public async Task<(IList<Course> records, int total, int totalDisplay)> GetPagedCoursesAsync(int pageIndex, int pageSize, string searchText, string sortBy)
        {
            return await _unitOfWork.CourseRepository.GetTableDataAsync(searchText, sortBy,pageIndex,pageSize);
        }
    }
}
