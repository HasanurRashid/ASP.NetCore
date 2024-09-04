using Autofac;
using FirstDemo.Domain.Exceptions;
using FirstDemo.Infrastructure;
using FirstDemo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Plugins;

namespace FirstDemo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private ILifetimeScope _scope;
        private ILogger<CourseController> _logger;
        public CourseController(ILifetimeScope scope, ILogger<CourseController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Create()
        {
            var model = _scope.Resolve<CourseCreateModel>();
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.CreateCourseAsync();

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Course Created Successfully",
                        Type = ResponseTypes.Success

                    });

                    return RedirectToAction("Index");

                }
                catch (DuplicateTitleException de)
                {
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = de.Message,
                        Type = ResponseTypes.Danger

                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in creating course",
                        Type = ResponseTypes.Danger

                    });
                }
            }
            return View(model);
        }

        
        public async Task<JsonResult> GetCourses()
        {
            var dataTablesModel = new DataTablesAjaxRequestUtility(Request);
            var model = _scope.Resolve<CourseListModel>();

            var data = await model.GetPagedCoursesAsync(dataTablesModel);
            return Json(data);
        }


       
        public async Task<IActionResult> Update(Guid id)
        {
            var model = _scope.Resolve<CourseUpdateModel>();
            await model.LoadAsync(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CourseUpdateModel model)
        {
            model.Resolve(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    await model.UpdateCourseAsync();

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Course Updated Successfully",
                        Type = ResponseTypes.Success

                    });

                    return RedirectToAction("Index");
                }
               
                catch (DuplicateTitleException de)
                {
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = de.Message,
                        Type = ResponseTypes.Danger

                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in updating course",
                        Type = ResponseTypes.Danger

                    });
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _scope.Resolve<CourseListModel>();

            if (ModelState.IsValid)
            {
                try
                {
                    await model.DeleteCourseAsync(id);
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Course Deleted Successfully",
                        Type = ResponseTypes.Success

                    });

                    return RedirectToAction("Index");
                }
                catch (DuplicateTitleException de)
                {
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = de.Message,
                        Type = ResponseTypes.Danger

                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in deleting course",
                        Type = ResponseTypes.Danger

                    });
                }
            }

            return RedirectToAction("Index");
        }
    }
}
