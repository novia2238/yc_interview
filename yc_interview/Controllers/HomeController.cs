using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using yc_interview.Models;
using yc_interview.Models.DB;
using yc_interview.Models.ViewModel;
using yc_interview.Service.Customer;

namespace yc_interview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService _service;

        public HomeController(ILogger<HomeController> logger , ICustomerService service)
        {
            _logger = logger;
            _service = service;

        }

        public IActionResult Index()
        {
            var result = _service.GetList();
            return View(result);
        }

        public IActionResult Create() 
        {
            return View();
        }

        public IActionResult CreateData(CustomerViewModel model) 
        {

            return RedirectToAction("Index");
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
