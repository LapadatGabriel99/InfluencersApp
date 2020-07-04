using BusinessLogic.Interfaces;
using BusinessLogic.Models;
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

        [HttpGet]
        public async Task<IActionResult> Rankings(int choice)
        {
            var viewModel = new RankingViewModel();
            
            if (choice == 0)
            {
                ViewData["By"] = "(Score)";

                //viewModel = await _authorService.GetAuthorsByScore();
            }
            else if (choice == 1)
            {
                ViewData["By"] = "(Number Of Articles)";

                //viewModel = await _authorService.GetAuthorsByNumberOfArticles();
            }
            else if (choice == 2)
            {
                ViewData["By"] = "(Number Of Commented Articles)";

                //viewModel = await _authorService.GetAuthorsByCommentedArticles();
            }

            return View(viewModel);
        }                 
    }
}
