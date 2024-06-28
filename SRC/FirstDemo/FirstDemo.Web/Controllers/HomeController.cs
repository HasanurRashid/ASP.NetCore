using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, ISmsSender sender)
        {
            _logger = logger;
            _emailSender = emailSender;
            _smsSender = sender;
        }

        public IActionResult Index()
        {
            var model = new IndexModel();
            model.Message = " Hello Asp.net core";
            _logger.LogInformation("I am in index");
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Test()
        {
            var model = new TestModel();
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Test(TestModel model)
        {
            if(ModelState.IsValid)
            {
                int x;
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
