﻿using BusinessLogic.DataTransfer;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace InfluencersApp.Controllers
{
    public class ArticleController : Controller
    {        
        private readonly ILogger<ArticleController> _logger;

        private string _articleSubmitMessage = "";

        private readonly IArticleService _articleService;

        public ArticleController(ILogger<ArticleController> logger, IArticleService articleService)
        {            
            _logger = logger;

            _articleService = articleService;
        }     
            
        public IActionResult CreateArticle()
        {
            ViewData["Message"] = _articleSubmitMessage;

            return View();
        }       

        [HttpPost]        
        public async Task<IActionResult> CreateArticle(CreateArticleViewModel viewModel)
        {           
            if (viewModel.CreateArticleData.Title == null || 
                viewModel.CreateArticleData.Content == null || 
                viewModel.CreateArticleData.AuthorEmail == null ||
                viewModel.CreateArticleData.AuthorNickname == null ||
                viewModel.CreateArticleData.Tags == null)
            {
                _articleSubmitMessage = "Can't submit article, invalid input...";

                ViewData["Message"] = _articleSubmitMessage;

                return View();
            }

            await _articleService.AddArticle(viewModel.CreateArticleData);

            var emailViewModel = new EmailViewModel
            {
                To = viewModel.CreateArticleData.AuthorEmail,
                IsHtml = false,
                Subject = "Article added...",
                Content = $"Hi { viewModel.CreateArticleData.AuthorNickname }, " +
                $"we've sent you this confirmation email so that we can verify it's you"
            };            

            _articleSubmitMessage = "Article was submitted successfuly";

            ViewData["Message"] = _articleSubmitMessage;

            return View(); 
        }

        [HttpGet("article/articleDetails/{id}")]       
        public async Task<IActionResult> ArticleDetails(int id)
        {
            var viewModel = await _articleService.GetArticleDetailsViewModel(id);

            return View(viewModel);
        }

        //[HttpGet("article/articleDetails/{viewModel}")]
        //public IActionResult ArticleDetails(ArticleDetailsViewModel viewModel)
        //{
        //    return View(viewModel);
        //}

        [HttpGet]
        public IActionResult EditArticle(ArticleDetailsViewModel articleDetailsViewModel)
        {
            return View(new EditArticleViewModel
            {
                ArticleDetailsViewModel = articleDetailsViewModel
            });
        }

        public async Task<IActionResult> SubmitChanges(EditArticleViewModel viewModel)
        {
            viewModel.EmailViewModel = new EmailViewModel
            {
                To = viewModel.ArticleDetailsViewModel.ArticleDetails.AuthorEmail,
                IsHtml = false,
                Subject = $"Article content changed...",
                Content = $"Hi { viewModel.ArticleDetailsViewModel.ArticleDetails.AuthorNickname }, " +
                $"we've sent you this confirmation email so that we can verify it's you"
            };            

            await _articleService.UpdateArticle(viewModel.ArticleDetailsViewModel.ArticleDetails);

            RedirectToAction(actionName: "SendEmail", controllerName: "Email", viewModel.EmailViewModel);

            return Redirect($"article/articleDetails/{viewModel.ArticleDetailsViewModel.ArticleDetails.ArticleId}");
        }
    }
}
