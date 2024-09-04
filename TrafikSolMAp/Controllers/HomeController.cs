using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TrafikSolMap.Models;
using TrafikSolMapLibrary.DBF;

namespace TrafikSolMap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public class LoginBE
        {
            #region Declaration of Variable for LoginBE
            public string AdminLoginName { get; set; }
            public string AdminPassword { get; set; }
            #endregion
        }
        public HomeController(IConfiguration config)
        {
            _config = config;

        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            TrafikSolMapDBF.Postgreconnction = _config["PostGresql"];
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginBE model)
        {
           
            return RedirectToAction("DashboardView", "Dashboard");
        }
         

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
