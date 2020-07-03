using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace InfluencersApp.Controllers
{
    public class AuthorController : Controller
    {        
        private readonly ILogger<AuthorController> _logger;

        private readonly IAuthorService _authorService;

        public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService)
        {            
            _logger = logger;

            _authorService = authorService;
        }
      
        public IActionResult Rankings()
        {
            return View();
        }

        public async Task<IActionResult> ByScore()
        {
            return View();
        }

        public async Task<IActionResult> ByNumberOfArticles()
        {
            return View();
        }
    }
}
