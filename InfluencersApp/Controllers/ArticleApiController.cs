using BusinessLogic.DataTransfer;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace InfluencersApp.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class ArticleApiController : ControllerBase
    {
        private readonly ILogger<ArticleApiController> _logger;

        private readonly IArticleService _articleService;

        public ArticleApiController(ILogger<ArticleApiController> logger, IArticleService articleService)
        {
            _logger = logger;

            _articleService = articleService;
        }

        
        [HttpPost("articleApi/send")]
        public async Task<VoteDataTransfer> Send([FromBody] VoteDataTransfer voteDataTransfer)
        {
            if (await _articleService.UpdateScore(voteDataTransfer))
            {
                voteDataTransfer.Succeded = true;

                return voteDataTransfer;
            }
            else
            {
                voteDataTransfer.Succeded = false;

                return voteDataTransfer;
            }
        }
    }
}
