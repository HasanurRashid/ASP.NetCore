using FirstDemo.Application.Features.Training.DTOs;
using FirstDemo.Domain.Entities;
using FirstDemo.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Application.Features.Training.Services
{
    public class CourseManagementService : ICourseManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public CourseManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCourseAsync(string title, uint fees, string description)
        {
            bool isDuplicatTitle = await _unitOfWork.CourseRepository.
                IsTitleDuplicateAsync(title);

            if (isDuplicatTitle)
                throw new DuplicateTitleException();

            Course course = new Course
            {
                Title = title,
                Fees = fees,
                Description = description
            };

            await _unitOfWork.CourseRepository.AddAsync(course);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCourseAsync(Guid id)
        {
            await _unitOfWork.CourseRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Course> GetCourseAsync(Guid id)
        {
            return await _unitOfWork.CourseRepository.GetByIdAsync(id);
        }

        public async Task<(IList<Course> records, int total, int totalDisplay)>
            GetPagedCoursesAsync(int pageIndex, int pageSize, string searchTitle,
                uint searchFeesFrom, uint searchFeesTo, string sortBy)
        {
            return await _unitOfWork.CourseRepository.GetTableDataAsync(searchTitle,
                searchFeesFrom, searchFeesTo, sortBy, pageIndex, pageSize);
        }

        public async Task UpdateCourseAsync(Guid id, string title, string description,
            uint fees)
        {
            bool isDuplicatTitle = await _unitOfWork.CourseRepository.
                IsTitleDuplicateAsync(title, id);

            if (isDuplicatTitle)
                throw new DuplicateTitleException();

            var course = await GetCourseAsync(id);
            if (course is not null)
            {
                course.Title = title;
                course.Description = description;
                course.Fees = fees;
            }
            await _unitOfWork.SaveAsync();
        }

        public async Task<(IList<CourseEnrollmentDTO> records, int total, int totalDisplay)> 
            GetCourseEnrollmentsAsync(int pageIndex, int pageSize, string orderBy,
            string courseName, string studentName, DateTime enrollmentDateFrom,
            DateTime enrollmentDateTo)
        {
            return await _unitOfWork.GetCourseEnrollmentsAsync(
                pageIndex, pageSize, orderBy, courseName,
                studentName, enrollmentDateFrom, enrollmentDateTo);
        }

        public async Task<IList<Course>>? GetCoursesAsync()
        {

            return await _unitOfWork.CourseRepository.GetAllAsync();
        }
    }
}
