using Autofac;
using FirstDemo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public IActionResult Create(CourseCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                model.CreateCourse();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
