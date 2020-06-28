using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InfluencersApp.Controllers
{    
    public class AuthorController : Controller
    {        
        private readonly ILogger<AuthorController> _logger;
            
        public AuthorController(ILogger<AuthorController> logger)
        {            
            _logger = logger;
        }
      
        public IActionResult Rankings()
        {
            return View();
        }
    }
}
