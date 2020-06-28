using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinessLogic.Models;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;
using DataAccess.Data.Models;
using Microsoft.AspNetCore.StaticFiles;

namespace InfluencersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IArticleService _articleService;

        private readonly IContactService _contactService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, IContactService contactService)
        {
            _logger = logger;

            _articleService = articleService;

            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {           
            return View(await _articleService.GetListOfIndexViewModels());
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

        public async Task<IActionResult> Contacts()
        {
            return View(await _contactService.GetListOfContactsViewModels());
        }
    }
}
